using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    float health = 50f;
    float speed = 5f;
    public float lookRadius = 2f;
    public float attackRadius = .5f;
    public float attackCooldown;
    public Transform player;
    public Transform[] scoutingPoints;
    State<Enemy> currentState = null;
    public int nr;
    public bool hasAttacked = false;
    int threatLevel = 1;
    public Vector3 escapeDirection = Vector3.zero;

    private bool timerStarted = false;

    void Awake()
    {
        ChangeState(new LookForPlayer());
        agent.stoppingDistance = 3.25f;
        escapeDirection.Normalize();
    }

    

    private void FixedUpdate()
    {
        currentState.Execute(this);
    }

    private void Update()
    {
        if (hasAttacked && !timerStarted)
        {
            timerStarted = true;
            StartCoroutine(TimerCoroutine(attackCooldown));
        }
    }

    IEnumerator TimerCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        hasAttacked = false;
        timerStarted = false;
    }

    public void ChangeState(State<Enemy> newState)
    {
        if (currentState != null)
            currentState.OnExit(this);

        currentState = newState;
        currentState.OnEnter(this);
           
    }

    public bool IsInAttackingArea()
    {
        float distance = (player.position - transform.position).sqrMagnitude;

        if (distance <= attackRadius * attackRadius)
            return true;
        else
            return false;
    }


    /// <summary>
    /// Checks to see if the target is within the sight radius
    /// </summary>
    public bool targetFound(Transform target)
    {
        float distance = (target.position - transform.position).sqrMagnitude;
        if (distance <= lookRadius * lookRadius)
            return true;
        else
            return false;
    }

    /// <summary>
    /// used to draw the perception sight sphere
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
