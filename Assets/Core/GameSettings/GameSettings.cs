using UnityEngine;
using UnityEngine.Audio;

namespace GameSettings
{
    public class GameSettings : ScriptableObject
    {
        private const string SfxVolume = "SFX";
        private const string MusicVolume = "Music";

        public string Version => $"{majorVersion}.{minorVersion}.{microVersion}";
        public int majorVersion;
        public int minorVersion;
        public int microVersion;
        public float audioVolume = 1f;
        public float musicVolume = 0.5f;
        public AudioMixer mixer;
        
        public void LoadSettings()
        {
            audioVolume = GetOrInitializeProperty(SfxVolume, 1f);
            musicVolume = GetOrInitializeProperty(MusicVolume, 0.5f);
            mixer.SetFloat(MusicVolume, Mathf.Log10(musicVolume) * 20);
            mixer.SetFloat(SfxVolume, Mathf.Log10(audioVolume) * 20);
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetFloat(SfxVolume, audioVolume);
            PlayerPrefs.SetFloat(MusicVolume, musicVolume);
        }

        private static float GetOrInitializeProperty(string property, float defaultValue)
        {
            if (PlayerPrefs.HasKey(property))
                return PlayerPrefs.GetFloat(property);
            else
            {
                PlayerPrefs.SetFloat(property, defaultValue);
                return defaultValue;
            }
        }

        private static string GetOrInitializeProperty(string property, string defaultValue)
        {
            if (PlayerPrefs.HasKey(property))
                return PlayerPrefs.GetString(property);
            else
            {
                PlayerPrefs.SetString(property, defaultValue);
                return defaultValue;
            }
        }

        private static Color GetOrInitializeProperty(string property, Color defaultValue)
        {
            if (PlayerPrefs.HasKey(property))
            {
                return ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(property), out var loadedColor) ? loadedColor : defaultValue;
            }
            else
                return defaultValue;
        }
    }
}