using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private Vector3 movement;
    private PlayerControls playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();

    }

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.GamePlay.Move.performed += ReadMoveInput;
        playerControls.GamePlay.Move.canceled += ReadMoveInput;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        transform.position += movement * Stats.Speed * Time.deltaTime;
    }

    private void RotatePlayer()
    {
        if(movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Stats.RotationSpeed * Time.deltaTime);
        }
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        var playerInput = context.ReadValue<Vector2>();
        movement.x = playerInput.x;
        movement.y = playerInput.y;
    }
}
