using ScriptableObjects;
using UnityEngine;

namespace InGame.Doors.Scripts
{
    public class ToggleDoor : Door
    {
        [SerializeField] private bool isOpen;

        private void OnEnable()
        {
            if (isOpen) AnimatorClip.Play(animator, openDoor);
        }

        public void Toggle()
        {
            if (isOpen)
            {
                isOpen = false;
                AnimatorClip.CrossFade(animator, closeDoor);
            }
            else
            {
                isOpen = true;
                AnimatorClip.CrossFade(animator, openDoor);
            }
        }
    }
}