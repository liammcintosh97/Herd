using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class InputMover : MonoBehaviour
{
  public float speed;
  public float sprintSpeed;
  public float turnSpeed;

  public float sprintPulseForce;
  public float sprintImpulseTime;

  private float currentSpeed;
  private UserInput input;
  private Vector3 axis;
  private NavMeshAgent agent;
  private bool isSprinting;
  private bool justSprtinted;

  // Start is called before the first frame update
  void Start()
  {
    input = UserInput.Instance;
    agent = (NavMeshAgent)Utility.ComponentCheck<NavMeshAgent>(gameObject, agent);
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
    if (agent == null) return;
    axis = input.DirAxis;

    if (input.IsDirAxisMoving) {

      Vector3 forward = gameObject.transform.forward.normalized;

      agent.Move(forward * ((axis.x * currentSpeed) * Time.deltaTime));

      Turn();
    }
  }

  private void Turn() {

      Vector3 rotation = new Vector3(0, axis.y, 0);
      gameObject.transform.Rotate(rotation * turnSpeed * Time.deltaTime); 
  }

  private IEnumerator SprintPulse() {

    justSprtinted = false;

    yield return new WaitForSeconds(sprintImpulseTime);
  }

  #endregion
}
