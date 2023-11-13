using System;
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

    private float singleShotTimer;
    private float tripleShotTimer;

    public static event Action OnPlayerPauseGame;

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

        playerControls.GamePlay.SingleShot.performed += SingleShot;
        playerControls.GamePlay.SingleShot.canceled += SingleShot;

        playerControls.GamePlay.SideTripleShot.performed += TripleShot;

        playerControls.GamePlay.PauseGame.performed += PauseGame;
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

        singleShotTimer -= Time.deltaTime;
        tripleShotTimer -= Time.deltaTime;
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

    private void SingleShot(InputAction.CallbackContext context) 
    {
        if (singleShotTimer < 0 && context.ReadValue<float>() == 1)
        {
            Vector3 shootDirection = singleShotEmitter.position - transform.position;

            GameObject shotProjectile = Instantiate(Stats.ProjectilePrefab, singleShotEmitter.position, Quaternion.identity);
            Rigidbody2D projectileRb = shotProjectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = shootDirection.normalized * Stats.ProjectileSpeed;

            StartCoroutine(DestroyProjectile(4f, shotProjectile)); 

            singleShotTimer = Stats.SingleShotCD;
        }
    }

    private void TripleShot(InputAction.CallbackContext context) 
    {
        if (tripleShotTimer < 0 && context.ReadValue<float>() == 1)
        {
            float spreadAngle = 0f;

            for (int i = 0; i <= 2; i++) 
            {
                Vector3 shootDirection = tripleShotEmitter.position - transform.position;
                GameObject shotProjectile = Instantiate(Stats.ProjectilePrefab, tripleShotEmitter.position, Quaternion.identity);
                Rigidbody2D projectileRb = shotProjectile.GetComponent<Rigidbody2D>();

                switch (i) 
                {
                    case 0:
                        spreadAngle = 15f;
                        break;
                    case 1:
                        spreadAngle = 0f;
                        break;
                    case 2:
                        spreadAngle = -15f;
                        break;
                }

                CalculateTripleShotSpread(shootDirection, spreadAngle, projectileRb);

                StartCoroutine(DestroyProjectile(0.4f, shotProjectile));
            }

            for (int i = 0; i <= 2; i++) 
            {
                Vector3 shootDirection = tripleShotEmitter2.position - transform.position;
                GameObject shotProjectile = Instantiate(Stats.ProjectilePrefab, tripleShotEmitter2.position, Quaternion.identity);
                Rigidbody2D projectileRb = shotProjectile.GetComponent<Rigidbody2D>();

                switch (i) 
                {
                    case 0:
                        spreadAngle = 15f;
                        break;
                    case 1:
                        spreadAngle = 0f;
                        break;
                    case 2:
                        spreadAngle = -15f;
                        break;
                }

                CalculateTripleShotSpread(shootDirection, spreadAngle, projectileRb);

                StartCoroutine(DestroyProjectile(0.4f, shotProjectile));
            }

            tripleShotTimer = Stats.TripleShotCD;
        }
    }

    private void CalculateTripleShotSpread(Vector3 shootDirection, float spreadAngle, Rigidbody2D projectileRb)
    {
        float rotateAngle = spreadAngle + (Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
        Vector2 ProjectileMovementDirection = new Vector2(Mathf.Cos(rotateAngle * Mathf.Deg2Rad), Mathf.Sin(rotateAngle * Mathf.Deg2Rad)).normalized;
        projectileRb.velocity = ProjectileMovementDirection * (Stats.ProjectileSpeed * 1.5f);
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        var playerInput = context.ReadValue<Vector2>();
        movement.x = playerInput.x;
        movement.y = playerInput.y;
    }

    IEnumerator DestroyProjectile(float timer, GameObject projectile)
    {
        yield return new WaitForSeconds(timer);

        if (projectile != null)
            Destroy(projectile);
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() == 1)
        {
            OnPlayerPauseGame.Invoke();
        }
    }
}
