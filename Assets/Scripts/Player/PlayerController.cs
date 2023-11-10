using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        playerControls.GamePlay.Move.performed += ReadInput;
        playerControls.GamePlay.Move.canceled += ReadInput;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += movement * Stats.Speed * Time.deltaTime;
    }

    private void ReadInput(InputAction.CallbackContext context)
    {
        var playerInput = context.ReadValue<Vector2>();
        movement.x = playerInput.x;
        movement.y = playerInput.y;
    }
}
