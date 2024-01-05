using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AgentControl : MonoBehaviour
{
    public Transform player;
    private float fovDist = 20.0f;
    private float fovAngle = 360.0f;
    public GameObject computer;
    public Transform target;
    private bool agentCreated;
    public AgentMode mode;
    void Update()
    {
        if (Maze.surfaceBuilt && !agentCreated)
        {
            computer.AddComponent<NavMeshAgent>();
            agentCreated = true;
            mode = AgentMode.ChasingTarget;
        }

        if (agentCreated)
        {
            NavMeshAgent agent = computer.GetComponent<NavMeshAgent>();
            if (canSeePlayer(player))
            {
                agent.destination = player.position;
                Vector3 distance = computer.transform.position - player.position;
                if (distance.magnitude > 5)
                    agent.speed = 4f;
                mode = AgentMode.ChasingPlayer;
            }
            else
            {
                agent.destination = target.position;
                mode = AgentMode.ChasingTarget;
            }
        }
    }

    bool canSeePlayer(Transform player)
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        RaycastHit hit;
        if ((Physics.Raycast(this.transform.position, direction, out hit)) && hit.collider.CompareTag("Player")
                                                                           && angle < fovAngle &&
                                                                           direction.magnitude < fovDist)
            return true;
        return false;

    }
}

public enum AgentMode
{
    ChasingTarget,
    ChasingPlayer
}
