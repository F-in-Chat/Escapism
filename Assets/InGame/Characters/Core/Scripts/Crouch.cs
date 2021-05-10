using Parents;
using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class Crouch : MonoBehaviour
    {
        // Test Change

        public CharacterController playerController;
        public float originalHeight;
        public float crouchHeight = 1.0f;
        // Start is called before the first frame update
        
        public bool IsCrouching { get; private set; }
        void Start()
        {
            playerController = Parent.GetComponent<CharacterController>(this);
            if (playerController) originalHeight = playerController.height;    
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerController) return;
            if(Input.GetButtonDown("Crouch"))
            {
                PlayerCrouch();
            } else if(Input.GetButtonDown("Stand"))
            {
                StandUp();
            }
        }

        void PlayerCrouch()
        {
            IsCrouching = true;
            playerController.height = crouchHeight;
        }

        void StandUp()
        {
            IsCrouching = false;
            playerController.height = originalHeight;
        }
    }
}
