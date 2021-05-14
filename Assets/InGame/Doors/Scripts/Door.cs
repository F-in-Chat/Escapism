using ScriptableObjects;
using UnityEngine;

namespace InGame.Doors.Scripts
{
    public class Door : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimatorClip openDoor;
        [SerializeField] protected AnimatorClip closeDoor;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void Open()
        {
            AnimatorClip.CrossFade(animator, openDoor);
        }

        public void Close()
        {
            AnimatorClip.CrossFade(animator, closeDoor);
        }
    }
}
