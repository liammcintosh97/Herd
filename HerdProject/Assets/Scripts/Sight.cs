using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
  public List<Animal> animalsInView = new List<Animal>(); //All the animals in sight of the object

  public delegate void SightEvent(Animal animal);
  public SightEvent sightEvent;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    DebugSight();
  }

  #region Public Methods

  public void AddAnimalToView(Animal animal) {

    //If the animal is already in view then it doesn't need to be added
    if (animalsInView.Contains(animal)) return;

    //Add the animal to view of the object
    animalsInView.Add(animal);
    sightEvent(animal);
  }

  public void RemoveAnimalFromView(Animal animal) {

    if (!animalsInView.Contains(animal)) return;

    //Remove the animal from the sight of the object
    animalsInView.Remove(animal);
    sightEvent(animal);
  }

  public bool InView(AnimalType type) {

    bool typeInView = false;

    foreach (Animal a in animalsInView) {
      if (a.animalType == type) typeInView = true;
    }

    return typeInView;
  }

  #endregion

  #region Triggers

  public void OnTriggerStay(Collider other)
  {
    Animal animal = other.gameObject.GetComponentInParent<Animal>();

    //The object that has entered the trigger is not an animal so return
    if (animal == null ) return; 
    
    RaycastHit hit;
    Vector3 direction = other.transform.position - gameObject.transform.position;

    //Shoot a raycast towards the animal that's in the line of sight
    if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
    {
      //If the raycast hits the animal it is in sight of this object
      if (hit.collider.Equals(other)) AddAnimalToView(animal);
      // If the raycast hits something that isn't the animal the animal in the trigger is behind something so remove it from sight
      else RemoveAnimalFromView(animal);
    }
  }

  public void OnTriggerExit(Collider other)
  {
    Animal animal = other.gameObject.GetComponent<Animal>();

    if (animal == null) return; //If the object that leaves the trigger is not an animal return
    RemoveAnimalFromView(animal);
  }

  #endregion

  #region Debug

  private void DebugSight() {
    //Used for debugging animals in sight of the object

    //If the animals in view is null or the count is zero retunr
    if(animalsInView == null || animalsInView.Count == 0) return;

    //Loop over all the animals in view and then draw a ray to it.
    foreach (Animal a in animalsInView) {
      Vector3 direction = a.transform.position - gameObject.transform.position;

      float distance = Vector3.Distance(a.transform.position, gameObject.transform.position);
      Debug.DrawRay(transform.position, direction * distance, Color.yellow);
    }

  }

  #endregion
}
