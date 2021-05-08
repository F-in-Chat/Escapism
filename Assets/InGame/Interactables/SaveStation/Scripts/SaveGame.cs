using UnityEngine;

namespace InGame.Interactables.SaveStation.Scripts
{
    public class SaveGame : MonoBehaviour
    {
        public static SaveGame instance;

        void awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void Save()
        {
        
        }
    }
}
