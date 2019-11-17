using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : Animal
{
  public Sight sight;
  public AgentMover agentMover;

  // Start is called before the first frame update
  new void Start()
  {
    base.Start();

    agentMover = (AgentMover)Utility.ComponentCheck<AgentMover>(gameObject, agentMover);
    sight = (Sight)Utility.ComponentCheck<Sight>(gameObject, sight);
 
    animalType = AnimalType.Sheep;
  }

  // Update is called once per frame
  void Update()
  {
    //TODO needs to ne optomized
    if (sight.InView(AnimalType.Dog)) 
    {
      Debug.Log("Sheep can see dog");
    }

  }

  #region Private Methods
  /*
  private void Flee() {

    GameObject dog = sight.animalsInView.

    Vector3 dir =  sigh 
  }*/

  #endregion

}
