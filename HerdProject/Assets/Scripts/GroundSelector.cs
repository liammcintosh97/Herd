using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSelector : MonoBehaviour
{
  public Camera camera;

  private UserInput input;

  // Start is called before the first frame update
  void Start()
  {
    camera = (Camera)Utility.ComponentCheck<Camera>(gameObject, camera);
    input = UserInput.Instance;
  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Public Methods

  public Vector3 SelectGroundPosition()
  {
    RaycastHit hit;
    Ray ray = camera.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit))
    {
      Transform objectHit = hit.transform;

      if (objectHit.gameObject.tag == Tags.ground) {

        Vector3 selectedPostion = hit.point;

        return selectedPostion;
      }
    }

    return Vector3.zero;
  }

  #endregion
}
