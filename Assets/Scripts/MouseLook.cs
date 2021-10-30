using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class MouseLook : MonoBehaviour
{
    private InputMaster inputActions;
    public Vector2 inputLook;
    private float xRotation;
    private Transform playerBody;


    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    private float minYClamp = -70f;
    private float maxYClamp = 80f;

    private void Awake()
    {
        inputActions = new InputMaster();
        playerBody = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    public void Look()
    {
        Debug.Log("Look");

        inputLook = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = inputLook.x * playerSettings.mouseSensitivity * Time.deltaTime;
        float mouseY = inputLook.y * playerSettings.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minYClamp, maxYClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
