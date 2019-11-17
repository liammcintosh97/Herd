using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : Animal
{
  public Sight sight;
  public AgentMover agentMover;

  private bool dogInView;
  private Animal chasedBy;

  private float multiplyBy = 10;

  // Start is called before the first frame update
  new void Start()
  {
    base.Start();

    agentMover = (AgentMover)Utility.ComponentCheck<AgentMover>(gameObject, agentMover);
    sight = (Sight)Utility.ComponentCheck<Sight>(gameObject, sight);
    sight.sightEvent = SheepSightEvent;
 
    animalType = AnimalType.Sheep;
  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Private Methods

  private void SheepSightEvent(Animal animal) {

    if (sight.InView(AnimalType.Dog))
    {
      dogInView = true;
      chasedBy = animal;
      Flee();
    }
    else dogInView = false;
  }

  private void Flee() {

    // store the starting transform
    Transform startTransform = transform;

    //temporarily point the object to look away from the player
    transform.rotation = Quaternion.LookRotation(transform.position - chasedBy.gameObject.transform.position);

    //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
    // for this if you want variable results) and store it in a new Vector3 called runTo
    Vector3 runTo = transform.position + transform.forward * multiplyBy;
    //Debug.Log("runTo = " + runTo);

    //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

    NavMeshHit hit;    // stores the output in a variable called hit

    // 5 is the distance to check, assumes you use default for the NavMesh Layer name
    NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Walkable"));
    Debug.Log("hit = " + hit + " hit.position = " + hit.position);

    // reset the transform back to our start transform
    transform.position = startTransform.position;
    transform.rotation = startTransform.rotation;

    // And get it to head towards the found NavMesh position
    agentMover.agent.SetDestination(hit.position);
  }

  #endregion

}
