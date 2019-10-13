using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMover : MonoBehaviour
{
  public NavMeshAgent agent;

  public void Start()
  {
    if (agent == null)
    {
      agent = GetComponent<NavMeshAgent>();
      if (agent == null) Debug.LogError("Nav Mesh agent couldn't be found");
    }
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
