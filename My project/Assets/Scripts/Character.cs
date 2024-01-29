using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected int damage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected float attackTime;

    [SerializeField] protected int movementSpeed;
    [SerializeField] protected int rotationSpeed;



    public virtual void Move(Vector3 destination, float speed)
    {
        // Move towards the destination position
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    protected void SetHealth(int maxHealth)
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
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}