using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : ScriptableObject
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(name);
    }
}
