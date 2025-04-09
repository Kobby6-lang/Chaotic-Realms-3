using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro; // Import the TextMesh Pro namespace
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullScreenToggle; // UI toggle remains unchanged
    public TMP_Dropdown resolutionDropdown; // TextMesh Pro dropdown
    public TMP_Dropdown textureQualityDropdown; // TextMesh Pro dropdown
    public TMP_Dropdown antialiasingDropdown; // TextMesh Pro dropdown
    public TMP_Dropdown vSyncDropdown; // TextMesh Pro dropdown
    public Slider musicVolumeSlider; // Slider remains unchanged
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    private void OnEnable()
    {
        gameSettings = new GameSettings();

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions) 
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }
    public Material outline;
    LocalKeyword outlineEffect;

    public void Start()
    {
        outlineEffect = new LocalKeyword(outline.shader, "_OVERLAY");
    }
    public void OnFullscreenToggle()
    {
       gameSettings.fullscreen = Screen.fullScreen = fullScreenToggle.isOn;
    }
    public void OnResolutionChange() 
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnTextureQualityChange() 
    {
        QualitySettings.globalTextureMipmapLimit = gameSettings.textureQuality = resolutionDropdown.value;
    }

    public void OnAntialiasingChange() 
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2, antialiasingDropdown.value);
    }

    public void OnVSyncChange() 
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnMusicVolumeChange() 
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void OnApplyButtonClick() 
    {
        SaveSettings();
    }

    public void SaveSettings() 
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings() 
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        musicVolumeSlider.value = gameSettings.musicVolume;
        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullScreenToggle.isOn = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }

    public void OnGraphicsOutlineToggle(bool enable)
    {
        outline.SetKeyword(outlineEffect, enable);
    }
}
