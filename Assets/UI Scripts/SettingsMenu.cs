using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
  public void SetFullscreen(bool isFullScreen) 
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
