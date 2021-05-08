using UnityEngine;

namespace SoundEffects
{
    public class SoundEffect : ScriptableObject
    {
        public AudioClip audioClip;

        public void Play() => Play(Vector3.zero);
        
        public void Play(Vector3 position)
        {
            var newGameObject = new GameObject(audioClip.name);
            newGameObject.transform.position = position;
            var audioSource = newGameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            Destroy(newGameObject, audioClip.length);
        }
    }
}