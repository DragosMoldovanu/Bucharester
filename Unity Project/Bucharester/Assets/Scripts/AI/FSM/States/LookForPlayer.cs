using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : State<Enemy>
{
    public override void OnEnter(Enemy agent)
    {
        agent.agent.SetDestination(agent.scoutingPoints[0].position);
    }

    public override void Execute(Enemy agent)
    {
        float distance = (agent.transform.position - agent.scoutingPoints[agent.nr].transform.position).sqrMagnitude;
        //first path
        if (agent.nr == 0)
        {
            agent.agent.SetDestination(agent.scoutingPoints[agent.nr].position);
            if (distance <= 4)
                agent.nr++;
        }

        //second path
        if (agent.nr == 1)
        {
            agent.agent.SetDestination(agent.scoutingPoints[agent.nr].position);
            distance = (agent.transform.position - agent.scoutingPoints[agent.nr].transform.position).sqrMagnitude;
            if (distance <= 4)
                agent.nr++;
        }

        //third path
        if (agent.nr == 2)
        {
            agent.agent.SetDestination( agent.scoutingPoints[agent.nr].position);
            distance = (agent.transform.position - agent.scoutingPoints[agent.nr].transform.position).sqrMagnitude;
            if (distance <= 4)
                agent.nr++;
        }

        //forth path
        if (agent.nr == 3)
        {
            agent.agent.SetDestination(agent.scoutingPoints[agent.nr].position);
            distance = (agent.transform.position - agent.scoutingPoints[agent.nr].transform.position).sqrMagnitude; //     distance = Vector3.Distance(agent.transform.position, agent.scoutingPoints[agent.nr].position);
            if (distance <= 4)
                agent.nr++;
        }

        //reset
        if (agent.nr > 3)
        {
            agent.nr = 0;
        }

        if (agent.targetFound(agent.player))
        {
            agent.ChangeState(new FollowPlayerState());
        }

        if (agent.player.GetComponent<Player>().scareEnemies)
            agent.ChangeState(new AvoidPlayerState());
    }

    public override void OnExit(Enemy agent)
    {
        Debug.LogWarning("about to chase this nigga");
    }
}
