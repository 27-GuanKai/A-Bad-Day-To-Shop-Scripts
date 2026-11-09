using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.Animations;
public class EnemyAiMovement : MonoBehaviour
{
    public GameObject Zombie;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;
    //Walking Around
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;
    //States
    public float sightRange;
    public bool PlayerInSightRange;
    //Animation
    public Animator animator;
    public AudioSource AS;
 
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = Zombie.GetComponent<Animator>();
        AS = Zombie.GetComponent<AudioSource>();
        animator.SetBool("IsRunningBool", false);
    }
    private void Update()
    {
        //Checking for States(a.k.a Sight range and stuff)
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        if (!PlayerInSightRange) Patroling();
        if (PlayerInSightRange) ChaseDown();
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            
            agent.SetDestination(walkpoint);
        
        animator.SetBool("IsRunningBool", false);
        AS.Stop();
        Vector3 distanceToWalkPoint = transform.position - walkpoint;
        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, Ground))
            walkPointSet = true;
    }
    private void ChaseDown()
    {
        
        animator.SetBool("IsRunningBool", true);
        agent.SetDestination(player.position);
        AS.Play();
    }
    
}
