using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects
{
    public class LevelLoader : ScriptableObject
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene(name);
        }
    }
}
