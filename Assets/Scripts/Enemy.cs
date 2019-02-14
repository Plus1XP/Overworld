using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState CurrentState;
    public FloatValue MaxHealth;
    public float Health;
    public string EnemyName;
    public int BaseAttack;
    public float MoveSpeed;

    private void Awake()
    {
        Health = MaxHealth.InitialValue;
    }

    private void takeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            // Set game object to false hides object rather than destroying object which calls the garbage collector 
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D enemy, float knockbackTime, float damage)
    {
        StartCoroutine(KnockCo(enemy, knockbackTime));
        takeDamage(damage);
    }

    // Coroutine checks the enemy isnt dead then stops the enemy from moving after a set amount of time
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockbackTime)
    {
        // Checks the enemy isnt dead
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);

            // Stops enemy from moving by resetting velocity
            myRigidbody.velocity = Vector2.zero;
            CurrentState = EnemyState.idle;
            //myRigidbody.velocity = Vector2.zero;
        }
    }
}
