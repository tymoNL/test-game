using Cinemachine;
using UnityEngine;

public class Player : Character
{
    private GameObject enemy;

    public CharacterController controller;
    public Transform cam;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        maxHealth = 10;
        
        movementSpeed = 6;
        rotationTime = 0.1f;

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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, rotationTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);

            Debug.Log("Player position: " + transform.position);
            Debug.Log("Move direction: " + moveDir);
        }
    }
}
