using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType {Null, Sheep, Dog}

public class Animal : MonoBehaviour
{
  public int id;
  public AnimalType animalType;

  public void Start()
  {
    id = Random.Range(0,100000000);
  }
}
