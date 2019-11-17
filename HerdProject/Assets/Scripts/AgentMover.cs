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
}
