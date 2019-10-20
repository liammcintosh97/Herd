using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputMover : MonoBehaviour
{
  public float speed;

  private UserInput input;
  private Vector2 axis;
  private Rigidbody rigidbody;

  // Start is called before the first frame update
  void Start()
  {
    input = UserInput.Instance;
    if (rigidbody == null)
    {
      rigidbody = GetComponent<Rigidbody>();
      if (rigidbody == null) Debug.LogError("Input Mover couldn't find a Rigidbody");
    }
  }

  // Update is called once per frame
  void Update()
  {
    ProcessInput();
  }

  #region

  private void ProcessInput()
  {
    if (rigidbody == null) return;
    axis = input.GetDirectionalAxis();

    Debug.Log(axis);

    rigidbody.AddForce(axis * speed, ForceMode.Force); 
  }

  #endregion
}
