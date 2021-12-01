using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Cannon = 0, Laser, Slow, Buff, }
public enum WeaponState { SearchTarget = 0, TryAttackCannon, TryAttackLaser, }

public class TowerWeapon : MonoBehaviour
{
    [Header("Cannons")]
    [SerializeField]
    private TowerTemplate towerTemplate;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private WeaponType weaponType;

    [Header("Cannons")]
    [SerializeField]
    private GameObject projectilePrefab;
    private AudioSource audioSource;  //소리 재생 컴포넌트 

    [Header("Laser")]
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform hitEffect;
    [SerializeField]
    private LayerMask targetLayer;

    private int level = 0;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private SpriteRenderer spriteRenderer;
    private TowerSpawner towerSpawner;
    private EnemySpawner enemySpawner;
    private PlayerGold playerGold;
    private Tile ownerTile;

    private float addedDamage;  //버프로 인해 추가된 데미지
    private int buffLevel;      //버프를 받는지 여부 설정 (0 : 버프 x, 1~3 받는 버프 레벨 변수 선언)
    
    public Sprite TowerSprite => towerTemplate.weapon[level].sprite;
    public float Damage => towerTemplate.weapon[level].damage;
    public float Rate => towerTemplate.weapon[level].rate;
    public float Range => towerTemplate.weapon[level].range;
    public int UpgradeCost => Level < MaxLevel ? towerTemplate.weapon[level+1].cost : 0;
    public int SellCost => towerTemplate.weapon[level].sell;
    public int Level => level + 1;
    public int MaxLevel => towerTemplate.weapon.Length;
    public float Slow => towerTemplate.weapon[level].slow;
    public float Buff => towerTemplate.weapon[level].buff;
    public WeaponType WeaponType => weaponType;  //프로퍼티 선언
    public float AddedDamage
    {
        set => addedDamage = Mathf.Max(0, value);
        get => addedDamage;
    }
    public int BuffLevel
    {
        set => buffLevel = Mathf.Max(0, value);
        get => buffLevel;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setup(TowerSpawner towerSpawner, EnemySpawner enemySpawner, PlayerGold playerGold, Tile ownerTile)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.towerSpawner = towerSpawner;
        this.enemySpawner = enemySpawner;
        this.playerGold = playerGold;
        this.ownerTile = ownerTile;

        if ( weaponType == WeaponType.Cannon || weaponType == WeaponType.Laser )
        {
            ChangeState(WeaponState.SearchTarget);
        }
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());

        weaponState = newState;

        StartCoroutine(weaponState.ToString());
    }

    //타워를 회전 시키면서 적을 공격하게 보여주는 함수
    /*private void Update()
    {
        if ( attackTarget != null )
        {
            RotateToTarget();
        }
    }*/

    /*private void RotateToTarget()
    {
        float dx = attackTarget.position.x - transform.position.x;
        float dy = attackTarget.position.y - transform.position.y;

        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }*/

    private IEnumerator SearchTarget()
    {
        while ( true )
        {
            attackTarget = FindClosestAttackTarget();

            if ( attackTarget != null )
            {
                if (weaponType == WeaponType.Cannon)
                {
                    ChangeState(WeaponState.TryAttackCannon);
                }
                else if ( weaponType == WeaponType.Laser )
                {
                    ChangeState(WeaponState.TryAttackLaser);
                }
            }

            yield return null;
        }
    }

    private IEnumerator TryAttackCannon()
    {
        while ( true )
        {
            if (IsPossibleToAttackTarget() == false )
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            yield return new WaitForSeconds(towerTemplate.weapon[level].rate);
            SpawnProjectile();

        }
    }

    private IEnumerator TryAttackLaser()
    {
        EnableLaser();

        while ( true )
        {
            if ( IsPossibleToAttackTarget() == false )
            {
                DisableLaser();
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            SpawnLaser();

            yield return null;
        }
    }

    public void OnBuffAroundTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");  //맵에 배치된 타워를 찾는다.

        for ( int i = 0; i < towers.Length; ++ i )
        {
            TowerWeapon weapon = towers[i].GetComponent<TowerWeapon>();

            if ( weapon.BuffLevel > Level )
            {
                continue;
            }

            if (Vector3.Distance(weapon.transform.position, transform.position) <= towerTemplate.weapon[level].range)
            {
                if ( weapon.WeaponType == WeaponType.Cannon || weapon.WeaponType == WeaponType.Laser )
                {
                    weapon.AddedDamage = weapon.Damage * (towerTemplate.weapon[level].buff);

                    weapon.BuffLevel = Level;
                }
            }
        }
    }

    private Transform FindClosestAttackTarget()
    {
        float closestDistSqr = Mathf.Infinity;

        for ( int i = 0; i < enemySpawner.EnemyList.Count; ++ i )
        {
            float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

            if ( distance <= towerTemplate.weapon[level].range && distance <= closestDistSqr )
            {
                closestDistSqr = distance;
                attackTarget = enemySpawner.EnemyList[i].transform;
            }
        }

        return attackTarget;
    }

    private bool IsPossibleToAttackTarget()
    {
        if ( attackTarget == null )
        {
            return false;
        }

        float distance = Vector3.Distance(attackTarget.position, transform.position);
        if ( distance > towerTemplate.weapon[level].range )
        {
            attackTarget = null;
            return false;
        }

        return true;
    }

    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        audioSource.Play();
        float damage = towerTemplate.weapon[level].damage + AddedDamage;
        clone.GetComponent<Projectile>().Setup(attackTarget, damage);
    }

    private void EnableLaser()
    {
        lineRenderer.gameObject.SetActive(true);
        hitEffect.gameObject.SetActive(true);
    }

    private void DisableLaser()
    {
        lineRenderer.gameObject.SetActive(false);
        hitEffect.gameObject.SetActive(false);
    }

    private void SpawnLaser()
    {
        Vector3 direction = attackTarget.position - spawnPoint.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(spawnPoint.position, direction,
                                                  towerTemplate.weapon[level].range, targetLayer);
        for ( int i = 0; i < hit.Length; ++ i)
        {
            if ( hit[i].transform == attackTarget )
            {
                lineRenderer.SetPosition(0, spawnPoint.position);

                lineRenderer.SetPosition(1, new Vector3(hit[i].point.x, hit[i].point.y, 0) + Vector3.back);

                hitEffect.position = hit[i].point;

                float damage = towerTemplate.weapon[level].damage + AddedDamage;
                attackTarget.GetComponent<EnemyHP>().TakeDamage(damage * Time.deltaTime);
            }
        }
    }

    public bool Upgrade()
    {
        if ( playerGold.CurrentGold < towerTemplate.weapon[level+1].cost)
        {
            return false;
        }

        level ++;

        spriteRenderer.sprite = towerTemplate.weapon[level].sprite;

        playerGold.CurrentGold -= towerTemplate.weapon[level].cost;

        if ( weaponType == WeaponType.Laser )
        {
            lineRenderer.startWidth = 0.05f + level * 0.05f;
            lineRenderer.endWidth = 0.05f;
        }

        //타워가 업그레이드 될 때 모든 버프 타워의 버프 효과 갱신 
        //현재 타워가 버프 타워인 경우, 현재 타워가 공격 타워인 경우
        towerSpawner.OnBuffAllBuffTowers();

        return true;
    }

    public void Sell()
    {
        playerGold.CurrentGold += towerTemplate.weapon[level].sell;
        ownerTile.IsBuildTower = false;

        Destroy(gameObject);
    }
}
