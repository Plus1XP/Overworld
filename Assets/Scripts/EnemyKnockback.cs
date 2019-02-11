using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float KnockbackForce;
    public float KnockbackTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Smash method in Breakable is called when player hits the collision box tagged with breakable
        if (collision.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Breakable>().Smash();
        }

        // Checks if the tagged object is in the trigger zone
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D Hit = collision.GetComponent<Rigidbody2D>();

            // Checks if the object is hit
            if (Hit != null)
            {
                Vector2 difference = Hit.transform.position - transform.position;

                // Normailizing the vector so it has a length of 1 so it doesnt move to fast
                difference = difference.normalized * KnockbackForce;
                Hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy"))
                {
                    Hit.GetComponent<Enemy>().CurrentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(Hit, KnockbackTime);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    Hit.GetComponent<PlayerMovement>().CurrentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(KnockbackTime);
                }
            }
        }
    }
}

/*
    KnockBack.OnTriggerenter2D() method to use fewer getcomponent calls and no tags (also added a "Breakable" class that pot derives from). 
    it is a little more flexible because of the way tags are limited to one per object, and also somewhat error prone with the finding them by strings: 
    
    var player = other.GetComponent<PlayerMovement>(); 
    var hasPlayer = player != null; 
    var thisIsPlayer = this.GetComponentInParent<PlayerMovement>() != null; 
    var enemy = other.GetComponent<Enemy>(); 
    var hasEnemy = enemy != null; 
    var breakable = other.GetComponent<Breakable>(); 
    var targetHasBreakable = breakable != null; 
       
    if (targetHasBreakable && thisIsPlayer) 
    { 
        breakable.Smash(); 
    } 
    if (hasPlayer || hasEnemy) 
    { 
        Rigidbody2D hit = other.GetComponent<Rigidbody2D>(); 
        if (hit != null) 
        {
            Vector2 difference = hit.transform.position - transform.position; 
            difference = difference.normalized * thrust; 
            hit.AddForce(difference, ForceMode2D.Impulse); 
            if (hasEnemy && other.isTrigger) 
            { 
                enemy.currentState = EnemyState.stagger; 
                enemy.Knock(hit, knockTime, damage); 
            } 
            if (hasPlayer) 
            { 
                if (player.currentState != PlayerState.stagger) 
                { 
                player.currentState = PlayerState.stagger; 
                player.Knock(knockTime, damage); 
                } 
            } 
        } 
    }﻿
 */
