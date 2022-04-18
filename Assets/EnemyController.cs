using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator animator;
    public Transform target;
    enum STATE
    {
        IDLE,ATTACK,RUN,DEAD
    }
    STATE state = STATE.IDLE;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                Idle();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            case STATE.RUN:
                Run();
                break;
            case STATE.DEAD:
                break;
            default:
                break;
        }

    }
    public void Idle()
    {
        AllAnimationFalse();
        if(Vector3.Distance(target.position,this.transform.position)<15f)
        {
            state = STATE.RUN;
        }
    }
    public void Run()
    {
        AllAnimationFalse();
        animator.SetBool("IsWalk", true);
        agent.stoppingDistance = 6f;
        agent.SetDestination(target.transform.position);
        
        if(GetDistance()<agent.stoppingDistance+1f)
        {
            state = STATE.ATTACK;
        }
        if (GetDistance() > 20f)
        {
            state = STATE.IDLE;
        }


    }
    public void Attack()
    {
        AllAnimationFalse();
        animator.SetBool("IsAttack", true);
        if (GetDistance() >agent.stoppingDistance)
        {
            state = STATE.IDLE;
        }
       

    }
    public void AllAnimationFalse()
    {
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsDead", false);

    }
    public float GetDistance()
    {
        return (Vector3.Distance(target.position, this.transform.position));
    }
}
