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

  #region

  public void OnCollisionStay(Collision collision)
  {
    objectsInView.Add(collision.gameObject);
  }

  public void OnCollisionExit(Collision collision)
  {
    objectsInView.Remove(collision.gameObject);
  }

  #endregion
}
