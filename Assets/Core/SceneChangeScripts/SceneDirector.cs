using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChangeScripts
{
    public class SceneDirector : MonoBehaviour
    {
        [SerializeField]
        private SceneList[] scenesToLoad;

        // This is a comment!

        public void SingleSceneLoad(string levelName)
        {
            SceneList list = Array.Find(scenesToLoad, scenelist => scenelist.levelName == levelName);
            if (list == null)
            {
                Debug.Log("There are no levels with that name!");
                return;
            }
            else
            {
                SceneManager.LoadScene(list.mainScene, LoadSceneMode.Single);
            }
        }
    
        public void MultiSceneLoad(string levelName)
        {
            SceneList list = Array.Find(scenesToLoad, scenelist => scenelist.levelName == levelName);
            if (list == null)
            {
                Debug.Log("There are no levels with that name!");
                return;
            }
            else
            {
                SceneManager.LoadScene(list.mainScene, LoadSceneMode.Single);
                SceneManager.LoadScene(list.gameplayScene, LoadSceneMode.Additive);
                SceneManager.LoadScene(list.environmentScene, LoadSceneMode.Additive);
                SceneManager.LoadScene(list.audioScene, LoadSceneMode.Additive);
            }

        }

        public void QuitApplication()
        {
            // Bring up Warning Text
            // 0.5 - 1.0 second buffer Coroutine
            // if no, close warning text
            // if yes, close application
            // This will all go in the "Main Menu" script

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL("https://github.com/F-in-Chat/Escapism");
#else
         Application.Quit();
#endif
        }
    }
}
