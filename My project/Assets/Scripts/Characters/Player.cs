using Cinemachine;
using UnityEngine;

public class Player : Character
{
    private GameObject enemy;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        maxHealth = 10;
        
        movementSpeed = 1;
        rotationSpeed = 5;
        
        damage = 1;
        
        enemy = GameObject.Find("Enemy");
        CinemachineImpulseSource impulseSource = GetImpulseSource();

        if (impulseSource == null)
        {
            Debug.LogError("CinemachineImpulseSource component not found in children of the Character GameObject");
        }

        SetHealth();
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
