using System.Collections;
using UnityEngine;

namespace InGame.Environment.Doors.Scripts
{
    public class DoorLogic : MonoBehaviour
    {
        private bool drawGUI = false;
        private bool isClosed = true;
        private float xPos = Screen.width*0.5f-51f;
        private float yPos = Screen.height*0.25f-51f;
        public Transform interactiveDoor;
        // public Collider doorInteraction;
        void Update()
        {
            if(drawGUI == true && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("keycode E");
                if(isClosed == true)
                {
                    openDoor();
                }else if(isClosed == false)
                {
                    closeDoor();
                }
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                Debug.Log("Enter");
                drawGUI = true;
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if(collider.tag == "Player")
            {
                Debug.Log("Exit");
                drawGUI = false;
            }
        }
        private void OnGUI()
        {
            if(drawGUI == true)
            {
                GUI.Box(new Rect(xPos, yPos, 102, 22), "Press E to Open");
            }
        }

        // private void changeDoorState()
        // {
        //     if(isClosed == true)
        //     {
        //         interactiveDoor.GetComponent<Animation>().CrossFade("Open");
        //         isClosed = false;
        //         Debug.Log(isClosed);
        //         // Task.Delay(3000);
        //         // yield WaitForSeconds(3);
        //         StartCoroutine(getSeconds());
        //         // Debug.Log("waited");
        //         interactiveDoor.GetComponent<Animation>().CrossFade("Close");
        //         isClosed = true;
        //     }
        // }

        private void openDoor()
        {
            interactiveDoor.GetComponent<Animation>().CrossFade("Open");
            Debug.Log("Open");
            isClosed = false;
        }

        private void closeDoor()
        {
            interactiveDoor.GetComponent<Animation>().CrossFade("Close");
            Debug.Log("close");
            isClosed = true;
        }

        private IEnumerator getSeconds()
        {
            Debug.Log("time starts at " + Time.time);
            yield return new WaitForSeconds(3);
            Debug.Log("time ends at " + Time.time);
        }


    }
}
