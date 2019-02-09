using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float KnockbackForce;
    public float KnockbackTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if object tagged with "Enemy" is in trigger zone
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D Enemy = collision.GetComponent<Rigidbody2D>();

            // Checks if enemy has a rigidbody
            if (Enemy != null)
            {
                // Disable kinematic so it will take the values from this script
                Enemy.isKinematic = false;
                Vector2 difference = Enemy.transform.position - transform.position;
                
                // Normailizing the vector so it has a length of 1 so it doesnt move to fast
                difference = difference.normalized * KnockbackForce;
                Enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(Enemy));
            }
        }
    }

    // Coroutine checks the enemy isnt dead then stops the enemy from moving after a set amount of time
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        // Checks the enemy isnt dead
        if (enemy != null)
        {
            yield return new WaitForSeconds(KnockbackTime);

            // Stops enemy from moving by resetting velocity
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}
