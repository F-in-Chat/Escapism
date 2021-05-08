using UnityEngine;

namespace InGame.Environment.Doors.Scripts
{
    public class DoorController : MonoBehaviour
    {
        public GameObject intructions;
        private void OnTriggerStay(Collider other)
        {
            if(other.tag == "Door")
            {
                intructions.SetActive(true);
                Animator anim = other.GetComponentInChildren<Animator>();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetTrigger("OpenClose");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Door")
            {
                intructions.SetActive(false);
            }
        }
    }
}
