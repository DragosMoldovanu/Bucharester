using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayerState : State<Enemy>
{
    public override void OnEnter(Enemy agent)
    {
        agent.escapeDirection.Normalize();
        agent.agent.speed = 100;
    }

    public override void Execute(Enemy agent)
    {
        agent.escapeDirection = -agent.player.transform.forward;
        agent.agent.SetDestination(agent.escapeDirection);
        
        if(!agent.player.GetComponent<Player>().scareEnemies)
            agent.ChangeState(new LookForPlayer());

        if (!agent.targetFound(agent.player.transform))
            agent.ChangeState(new LookForPlayer());
    }

    public override void OnExit(Enemy agent)
    {
        agent.agent.speed = 8;
        agent.player.GetComponent<Player>().scareEnemies = false;
    }
}
