using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsMenu : MonoBehaviour
{
    public Material outline;
    LocalKeyword outlineEffect;

    public void Start()
    {
        outlineEffect = new LocalKeyword(outline.shader, "_OVERLAY");
    }
    public void SetFullscreen(bool isFullScreen) 
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex) 
    {
        Debug.Log("Setting quality level to: " + qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetGraphicsOutline(bool enable)
    {
        outline.SetKeyword(outlineEffect, enable);
    }
}
