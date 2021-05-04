using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class PlayerController : CharacterBase
    {
        #region Temp Variables
        [SerializeField]
        private float speed = 10;
        private Vector3 direction;
        #endregion

        public float mouseSensitivityX = 100f;
        public float mouseSensitivityY = 100f;
        private Rigidbody rBody;
        private Transform playerTransform;
        public Camera playerCamera;
        private float xRotation = 0f;

        #region User Input
        private float x;
        private float z;
        private float mouseX;
        private float mouseY;
        #endregion
    

        void Start()
        {
            rBody = GetComponent<Rigidbody>();
            playerTransform = GetComponent<Transform>();
            //playerCamera = GetComponentInChildren<Camera>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        /* The player movement and camera movement are fighting with each other! How do I fix this? */
        void Update()
        {
            PlayerRotationVersion1();
            PlayerMovementVersion1();
        }

        void PlayerMovementVersion1()
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            direction = (transform.right * x + transform.forward * z).normalized;
            rBody.velocity = direction * speed;
        }

        void PlayerRotationVersion1()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;
        
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            rBody.rotation *= Quaternion.Euler(0, mouseX, 0);
        }

        /* 
    Need the following States:
        1. Walk
            a. Standing - Normal movement
            b. Crouched - Slower movement
            c. Using Ability - Slower movement
            d. Attacking - ???
        2. Run
            a. Standing - Fast movement
            b. Crouching - Transition to Standing
            c. Using Ability - Slow to Walk
            d. Attacking - Slow to Walk
        3. Attack
            a. Can you attack with movement?
            b. How fast and how often can you attack?
        4. Abilities
            a. Use Ability
            b. Change Ability
            c. Dependancy on Energy
            d. Affect on Infection
    */

    }
}
