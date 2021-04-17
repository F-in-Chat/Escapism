using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public bool inInterface = false;
    private Character character;
    private Camera _camera;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        character = Character.GetCharacter(this);
        _camera = Character.GetComponent<Camera>(this);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HexagonPuzzleManager.onHasEnteredInterface += InInterface;
        OptionsMenu.onOpenOptionMenu += InInterface;
        FirstLevelManager.onFadingInLevel += InInterface;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character) return;
        if (!_camera) return;
        if (inInterface) return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        character.transform.Rotate(Vector3.up * mouseX);
    }

    void InInterface(bool hasEntered)
    {
        if (hasEntered)
        {
            inInterface = hasEntered;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            inInterface = hasEntered;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}