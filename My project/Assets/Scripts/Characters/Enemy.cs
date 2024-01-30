using Cinemachine;
using UnityEngine;

public class Enemy : Character
{
    private GameObject player;
    private Transform playerLocation;

    private float distanceToPlayer;

    private void Start()
    {
        movementSpeed = 1;
        maxHealth = 10;

        damage = 1;
        attackRange = 3f;
        attackSpeed = 1f;
        attackCooldown = 3f;
        attackTime = 0;

        player = GameObject.Find("Player");
        playerLocation = player.GetComponent<Transform>();
        CinemachineImpulseSource impulseSource = GetImpulseSource();

        SetHealth();
    }

    private void Update()
    {
        attackTime += Time.deltaTime;

        if (playerLocation != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, playerLocation.position);
            
            Move(playerLocation.position, movementSpeed);
        }

        if (distanceToPlayer <= attackRange)
        {
            if(attackTime > attackCooldown)
            {
                Attack(player, damage);
                attackTime = 0;
            }
        }
    }
}