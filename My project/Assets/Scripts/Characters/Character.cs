using Cinemachine;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [Header("Attack")]
    [SerializeField] protected int damage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected float attackTime;

    [Header("Movement")]
    [SerializeField] protected int movementSpeed;
    [SerializeField] protected int rotationSpeed;

    protected CinemachineImpulseSource GetImpulseSource()
    {
        return GetComponentInChildren<CinemachineImpulseSource>();
    }

    public virtual void Move(Vector3 destination, float speed)
    {
        // Move towards the destination position
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    protected void SetHealth()
    {
        health = maxHealth;
    }

    protected virtual void Attack(GameObject target, int damage)
    {
        if (target != null)
        {
            Character targetCharacter = target.GetComponent<Character>();

            Debug.Log($"Attacking {target.name} with {damage} damage");

            if (damage > 0)
            {
                targetCharacter.TakeDamage(damage);
            }
        }
    }

    protected virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Death();
        }

        CameraShake();
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    protected void CameraShake()
    {
        CinemachineImpulseSource impulseSource = GetComponentInChildren<CinemachineImpulseSource>();

        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse(); // Adjust parameters as needed
        }
    }
}