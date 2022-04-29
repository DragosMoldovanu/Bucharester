using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State<Enemy>
{
    public override void OnEnter(Enemy agent)
    {
        Debug.Log("Attacking...");
    }

    public override void Execute(Enemy agent)
    {
        if (!agent.targetFound(agent.player))
            agent.ChangeState(new LookForPlayer());

        agent.agent.SetDestination(agent.player.position);

        if (!agent.hasAttacked)
        {
            agent.player.GetComponent<Player>().TakeDMG(1);
            agent.hasAttacked = true;
        }
        else
            agent.ChangeState(new FollowPlayerState());


        if (agent.player.GetComponent<Player>().scareEnemies)
            agent.ChangeState(new AvoidPlayerState());
    }

    public override void OnExit(Enemy agent)
    {
        Debug.LogWarning("Im out");
    }
}
