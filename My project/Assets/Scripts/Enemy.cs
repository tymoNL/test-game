using UnityEngine;

public class Enemy : Character
{
    private GameObject player;
    private Transform playerLocation;

    private float distanceToPlayer;

    public Enemy()
    {

    }

    private void Start()
    {
        health = 10;
        movementSpeed = 1;

        damage = 1;
        attackRange = 3f;
        attackSpeed = 1f;
        attackCooldown = 3f;
        attackTime = 0;

        player = GameObject.Find("Player");

        playerLocation = player.GetComponent<Transform>();
    }

    private void Update()
    {
        attackTime += Time.deltaTime;

        if (playerLocation != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, playerLocation.position);
            
            // Beweeg naar de speler
            Move(playerLocation.position, movementSpeed);
        }

        if (distanceToPlayer <= attackRange)
        {
            if(attackTime > attackCooldown)
            {
                Attack(player, damage);
                attackTime = 0;
                Debug.Log("test");
            }
            
        }
    }

    protected override void TakeDamage(int damageAmount)
    {
        // Add enemy-specific damage handling logic here
        base.TakeDamage(damage); // Call the base class method to handle common logic
    }
}