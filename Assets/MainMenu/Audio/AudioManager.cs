using System;
using UnityEngine;
using UnityEngine.Audio;

namespace MainMenu.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixer mixer;
        AudioMixerGroup[] audioMixerGroup;
    
        public Sound[] music;
        public Sound[] sfx;
        public Sound[] voice;

        public static AudioManager instance;
    
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            audioMixerGroup = mixer.FindMatchingGroups("Master");
        
            //Change each "foreach" loop to a "for" loop
            foreach (Sound m in music)
            {
                m.source = gameObject.AddComponent<AudioSource>();
                m.source.clip = m.clip;

                m.source.volume = m.volume;
                m.source.pitch = m.pitch;

                m.source.loop = m.loop;
                m.source.outputAudioMixerGroup = audioMixerGroup[1];

                foreach (AudioMixerGroup group in audioMixerGroup)
                {
                    Debug.Log(group.name);
                }
            }
        
            // How do we create the Source component on the object calling the play function? Or how do we access the source component on the object, and use that instead?
            // This will be for tackling 3D sounds within the game.
            foreach (Sound s in sfx)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = audioMixerGroup[2];
            }

            // How do we create the Source component on the object calling the play function? Or how do we access the source component on the object, and use that instead?
            // This will be for tackling 3D sounds within the game.
            foreach (Sound v in voice)
            {
                v.source = gameObject.AddComponent<AudioSource>();
                v.source.clip = v.clip;

                v.source.volume = v.volume;
                v.source.pitch = v.pitch;
                v.source.spatialBlend = v.spatialBlend;

                v.source.loop = v.loop;
                v.source.outputAudioMixerGroup = audioMixerGroup[3];
            }

        }

        void Start()
        {
            PlayMusic("Theme");
        }

        public void PlayMusic(string name)
        {
            Sound s = Array.Find(music, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("That music name was not recognized!");
                return;
            }
            else
            {
                Debug.Log("Playing Music!");
                s.source.Play();
            }
        }

        public void PlaySFX(string name)
        {
            Sound s = Array.Find(sfx, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("That sound name was not recognized!");
                return;
            }
            else
            {
                Debug.Log("Playing SFX!");
                s.source.Play();
            }
        }

        public void PlayVoice(string name)
        {
            Sound s = Array.Find(voice, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("That voice name was not recognized!");
                return;
            }
            else
            {
                Debug.Log("Playing Voice!");
                s.source.Play();
            }
        }
    }
}
