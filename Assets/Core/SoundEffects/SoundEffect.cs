using UnityEngine;

namespace SoundEffects
{
    public class SoundEffect : ScriptableObject
    {
        public AudioClip audioClip;
        public float volume = 1;
        public float pitch = 1;

        public void Play() => Play(Vector3.zero);
        
        public void Play(Vector3 position)
        {
            var newGameObject = new GameObject(audioClip.name);
            newGameObject.transform.position = position;
            var audioSource = newGameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.Play();
            Destroy(newGameObject, audioClip.length);
        }
        
        public void Play(Vector3 position, float volumeMultiplier)
        {
            var newGameObject = new GameObject(audioClip.name);
            newGameObject.transform.position = position;
            var audioSource = newGameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = volume * volumeMultiplier;
            audioSource.pitch = pitch;
            audioSource.Play();
            Destroy(newGameObject, audioClip.length);
        }
        
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(SoundEffect)), UnityEditor.CanEditMultipleObjects]
    public class Editor : UnityEditor.Editor
    {
        public GameObject gameObject;
        public AudioSource audioSource;
        private float startTime;
        private float endTime;

        private void OnEnable()
        {
            UnityEditor.EditorApplication.update += OnEditorUpdate;
        }

        private void OnDisable()
        {
            UnityEditor.EditorApplication.update -= OnEditorUpdate;
        }

        private void OnEditorUpdate()
        {
            if (audioSource && audioSource.isPlaying && Time.realtimeSinceStartup > endTime)
                audioSource.Stop();
        }

        public override void OnInspectorGUI()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            base.OnInspectorGUI();

            if (!gameObject)
            {
                gameObject = new GameObject("AudioClip") {hideFlags = HideFlags.HideAndDontSave};
            }

            if (!audioSource)
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            if (GUILayout.Button("Play Sound"))
            {
                foreach (var soundEffects in targets)
                {
                    SoundEffect soundEffect = (SoundEffect) soundEffects;
                    audioSource.clip = soundEffect.audioClip;
                    audioSource.pitch = soundEffect.pitch;
                    audioSource.volume = soundEffect.volume;
                    //audioSource.time = soundEffect.start;
                    startTime = Time.realtimeSinceStartup;
                    endTime = startTime + audioSource.clip.length;
                    //endTime = soundEffect.stop > 0 ? startTime + (soundEffect.stop - soundEffect.start) : endTime;
                    //endTime = soundEffect.duration > 0 ? startTime + soundEffect.duration : endTime;
                    audioSource.Play();
                }
            }

            if (GUILayout.Button("Stop Sound"))
            {
                audioSource.Stop();
            }
        }
    }
#endif
    }
}