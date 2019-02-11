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
    public int Health;
    public string EnemyName;
    public int BaseAttack;
    public float MoveSpeed;

    public void Knock(Rigidbody2D enemy, float knockbackTime)
    {
        StartCoroutine(KnockCo(enemy, knockbackTime));
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
