using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class CharacterMovement : MonoBehaviour
{

    private InputMaster inputActions;
    public Vector2 inputMovement;
    private float movementSpeed = 5f;
    private CharacterController characterController;

    private void Awake()
    {
        inputActions = new InputMaster();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Debug.Log("Move");

        inputMovement = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 movement = (inputMovement.y * transform.forward) + (inputMovement.x * transform.right);
        characterController.Move(movement * movementSpeed * Time.deltaTime);
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
