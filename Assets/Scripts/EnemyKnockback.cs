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
                Enemy.GetComponent<Enemy>().CurrentState = EnemyState.stagger;

                // Disable kinematic so the objects movement is handle by the phsyics system (allows player to move the object)
                //Enemy.isKinematic = false;

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

            enemy.GetComponent<Enemy>().CurrentState = EnemyState.idle;

            // Enable kinematic so the movement is handled by code (stops player moving the object)
            //enemy.isKinematic = true;
        }
    }
}
