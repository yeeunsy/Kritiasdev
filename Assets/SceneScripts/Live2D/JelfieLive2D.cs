using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
//using live2d;
//using live2d.framework;
//using Live2D.Cubism.Framework.Raycasting;
//using Live2D.Cubism.Rendering;

/*[ExecuteInEditMode]

public class JelfieLive2D : MonoBehaviour
{
    public String path = "";
    public int sceneNo = 0;

    private LAppModel model;

    private bool isVisible = false;

    void Awake()
    {
        if (path == "") return;
        model = new LAppModel(this);

        LAppLive2DManager.Instance.AddModel(this);

        var filename = FileManager.getFilename(path);
        var dir = FileManager.getDirName(path);

        Debug.Log("Load " + dir + "  filename:" + filename);
        model.LoadFromStreamingAssets(dir, filename);
    }


    void OnRenderObject()
    {
        if (!isVisible) return;
        if (model == null) return;
        if (model.GetLive2DModelUnity().getRenderMode() == Live2D.L2D_RENDER_DRAW_MESH_NOW)
        {
            model.Update();
            model.Draw();
        }

        if (LAppDefine.DEBUG_DRAW_HIT_AREA)
        {
            model.DrawHitArea();
        }
    }


    void Update()
    {
        if (!isVisible) return;
        if (model == null) return;

        if (model.GetLive2DModelUnity().getRenderMode() == Live2D.L2D_RENDER_DRAW_MESH)
        {
            model.Update();
            model.Draw();
        }
    }


    public void GetModel()
    {
        return model;
    }


    public void SetVisible(bool isVisible)
    {
        this.isVisible = isVisible;
    }


    public bool GetVisible()
    {
        return isVisible;
    }


    public void ResetAudioSource()
    {
        Component[] components = gameObject.GetComponents<AudioSource>();
        for (int i = 0; i < components.Length; i++)
        {
            Destroy(components[i]);
        }
    }
}*/