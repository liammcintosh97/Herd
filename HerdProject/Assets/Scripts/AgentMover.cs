using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMover : MonoBehaviour
{
  public Transform[] navPoints;
  public NavMeshAgent agent;

  public void Start()
  {
    agent = (NavMeshAgent)Utility.ComponentCheck<NavMeshAgent>(gameObject, agent);
  }

  public void Update()
  {
   
  }

  #region Public Methods

  public void SetAgentGoal(Vector3 position) {
    agent.SetDestination(position);
  }

  #endregion
}
