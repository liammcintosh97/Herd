using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : Singleton<AnimalManager>
{
  public Animal[] animals;

  // Start is called before the first frame update
  void Start()
  {
    FindAnimals();
  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Public Methods

  public Animal GetAnimal(int id) {
    foreach (Animal a in animals) if (a.id == id) return a;
    return null;
  }

  #endregion

  #region Private Methods

  private void FindAnimals() {
    animals = FindObjectsOfType<Animal>();
  }

  #endregion

}
