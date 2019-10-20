using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputMover : MonoBehaviour
{
  public float speed;
  public float sprintSpeed;
  public float angularSpeed;

  public float sprintPulseForce;
  public float sprintImpulseTime;

  private float currentSpeed;
  private UserInput input;
  private Vector2 axis;
  private Rigidbody rigidbody;
  private bool isSprinting;
  private bool justSprtinted;

  // Start is called before the first frame update
  void Start()
  {
    input = UserInput.Instance;
    if (rigidbody == null)
    {
      rigidbody = GetComponent<Rigidbody>();
      if (rigidbody == null) Debug.LogError("Input Mover couldn't find a Rigidbody");
    }
    currentSpeed = speed;
  }

  // Update is called once per frame
  void Update()
  {
    if (input.GetKeyButton(KeyCode.W, ButtonClickType.DoubleClick))
    {
      currentSpeed = sprintSpeed;
      isSprinting = true;
      justSprtinted = true;
    }

    if (input.GetKeyButton(KeyCode.W, ButtonClickType.Release) && isSprinting)
    {
      currentSpeed = speed;
      isSprinting = false;
    }
  }

  private void FixedUpdate()
  {
    if (justSprtinted) {
      StopCoroutine(SprintPulse());
      StartCoroutine(SprintPulse());
    }
    ProcessMovement();
  }

  #region

  private void ProcessMovement()
  {
    if (rigidbody == null) return;
    axis = input.DirAxis;

    //Apply forward movement
    rigidbody.AddForce(gameObject.transform.forward * (axis.x * speed), ForceMode.Force);

    //Apply rotation
    rigidbody.AddTorque(gameObject.transform.up * (axis.y * angularSpeed), ForceMode.Force);

    //Reset x and Z rotation of gameObject
    gameObject.transform.localRotation =  new Quaternion(0,gameObject.transform.localRotation.y,0,gameObject.transform.localRotation.w);

  }

  private IEnumerator SprintPulse() {

    rigidbody.AddForce(gameObject.transform.forward * (axis.x * sprintPulseForce), ForceMode.Impulse);
    justSprtinted = false;

    yield return new WaitForSeconds(sprintImpulseTime);
  }

  #endregion
}
