using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSenses : MonoBehaviour
{
  List<GameObject> objectsInView = new List<GameObject>();

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Private Methods

  private bool IsSensible(Collider c) {

    if (c.tag.Equals("Sheep") || c.tag.Equals("Dog")) return true;
    else return false;
 
  }

  #endregion

  #region Triggers

  public void OnTriggerStay(Collider other)
  {
    if (!IsSensible(other)) return;

    objectsInView.Add(other.gameObject);
  }

  public void OnTriggerExit(Collider other)
  {
    if (!IsSensible(other)) return;

    objectsInView.Remove(other.gameObject);
  }

  #endregion
}
