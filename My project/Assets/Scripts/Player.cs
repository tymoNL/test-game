using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    private GameObject enemy;

    private float horizontalInput;
    private float verticalInput;

    protected override void TakeDamage(int damageAmount)
    {
        // Add player-specific damage handling logic here
        base.TakeDamage(damage); // Call the base class method to handle common logic
    }

    private void Start()
    {
        enemy = GameObject.Find("Enemy");
        
        health = 10;
        movementSpeed = 1;
        rotationSpeed = 5;
        damage = 1;
    }

    private void Update()
    {
        PlayerMovement();

        // Mouse pressed
        if (Input.GetMouseButtonDown(0))
        {
            Attack(enemy, damage);
        }
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Time.deltaTime * verticalInput * Vector3.forward);
        transform.Translate(horizontalInput * Time.deltaTime * Vector3.right);

        transform.Rotate(horizontalInput * rotationSpeed * Time.deltaTime * Vector3.up);
    }


}
