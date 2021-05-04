using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI.Settings
{
    public class Settings : MonoBehaviour
    {

        public AudioMixer audioMixer;
        public TMPro.TMP_Dropdown resolutionDropdown;
        public Toggle fullscreenToggle;
        private Resolution[] resolutions;

        void Awake()
        {
            //Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            //Checking and Populating Resolutions
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            //Checking Screen Mode for Fullscreen Settings Toggle
            CheckFullScreen();
        }

        public void CheckFullScreen()
        {
            if(Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
            {
                fullscreenToggle.isOn = true;
            }
            else
            {
                fullscreenToggle.isOn = false;
            }
        }

        public void SetMasterVolume(float volume)
        {
            audioMixer.SetFloat("Master", volume);
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("Music", volume);
        }

        public void SetSFXVolume(float volume)
        {
            audioMixer.SetFloat("SFX", volume);
        }

        public void SetVoiceVolume(float volume)
        {
            audioMixer.SetFloat("Voice", volume);
        }

        /* Set-up the "Quality Settings" under "Project Settings" for each quality. Also, consider allowing the user to edit each individual "Quality Setting" for each quality. */
        public void SetQuality(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }

        /* How many resolutions do we want to have? How do we automatically detect the user's screen resolution? */
        public void SetResolution(int index)
        {
            Resolution resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Debug.Log("Hello there!");
            if (isFullScreen)
            {
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Debug.Log("I'm now in fullscreen mode!");
            }
            else if (!isFullScreen)
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Debug.Log("I'm now in windowed mode!");
            }
            else
            {
                Debug.Log("There is an error!");
            }
        }

        /* Set the player x and y sensitivity to be editable in the settings */
        public void SetMouseSensitivity(float sensitivity)
        {

        }

    }
}
