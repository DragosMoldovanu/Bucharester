using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerState :State<Enemy>
{
    public override void OnEnter(Enemy agent)
    {
        //agent.hasAttacked = false;
        Debug.Log("Following Player State");
    }

    public override void Execute(Enemy agent)
    {
        agent.agent.SetDestination(agent.player.position);

        if (!agent.targetFound(agent.player))
            agent.ChangeState(new LookForPlayer());

        if (agent.IsInAttackingArea())
            agent.ChangeState(new AttackingState());

        if (agent.player.GetComponent<Player>().scareEnemies)
            agent.ChangeState(new AvoidPlayerState());
    }

    public override void OnExit(Enemy agent)
    {
        Debug.LogWarning("Im out");
    }
}
