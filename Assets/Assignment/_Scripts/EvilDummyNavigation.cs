using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EvilDummyNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public string position;
    public float attackRange;
    public float attackDamage;
    public float timeBetweenAttacks;
    //public LayerMask whatIsPlayer;

    private GameObject player;
    private Enemy enemy;
    private bool inAttackRange = false;
    private bool alreadyAttacked = false;
    void Start()
    {
        //agent.updateRotation = false;
        player = GameObject.Find("FPSController");
        enemy = GetComponent<Enemy>();
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance > agent.stoppingDistance) //if the agent has not reached its destination
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(transform.position, false, false);
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.Equals(player))
    //    {
    //        //AttackPlayer();
    //    }
    //}

    //private void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.Equals(player))
    //    {
    //        //AttackPlayer();
    //    }
    //}

    void AttackPlayer()
    {
        agent.SetDestination(enemy.transform.position); //stop moving
        transform.LookAt(player.transform);
        
        if (!alreadyAttacked)
        {
            //play attack animation
            //play attack sound
            enemy.animator.CrossFadeInFixedTime("punchRt", 0.01f);

            player.GetComponent<PlayerController>().TakeDamage(attackDamage);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void CheckInAttackRange()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, attackRange); // check if the player is in attack range
        bool found = false;
        foreach (Collider collider in collidersInRange)
        {
            if (collider.gameObject.Equals(player))
            {
                found = true;
            }
        }
        if (found)
        {
            inAttackRange = true;
        }
        else
        {
            inAttackRange = false;
        }
    }

    void Update()
    {
        // if the player is in the same building with the enemy
        if (PlayerController.location.Equals(enemy.location))
        {
            CheckInAttackRange();
            if (inAttackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }

    }
}
