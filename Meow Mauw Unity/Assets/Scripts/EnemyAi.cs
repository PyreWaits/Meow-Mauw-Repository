using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking (won't be used but good for learning)
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        player =GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        //Check for sight and attack range
        playerInSightRange=Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        playerInAttackRange=Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling(){
        if(!walkPointSet) SearchWalkPoint();

    }
    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);
        walkPoint= new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    }
    private void ChasePlayer(){

    }

    private void AttackPlayer(){

    }



}
