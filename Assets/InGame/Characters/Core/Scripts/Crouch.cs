using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    // Test Change

    public CharacterController playerController;
    public float originalHeight;
    public float crouchHeight = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        originalHeight = playerController.height;    
    }

    // Update is called once per frame
    void Update()
    {
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
        playerController.height = crouchHeight;
    }

    void StandUp()
    {
        playerController.height = originalHeight;
    }
}
