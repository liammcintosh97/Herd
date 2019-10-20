using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : Singleton<UserInput>
{
  private MouseMovementEvent _mouseMovementEvent;

  public MouseMovementEvent MouseMovementEvent
  {
    get
    {
      _mouseMovementEvent.Axis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
      return _mouseMovementEvent;
    }
    set
    {
      _mouseMovementEvent = value;
    }
  }

  public void Start()
  {
    MouseMovementEvent = new MouseMovementEvent();
  }

  public void OnGUI()
  {
    MouseMovementEvent.Position = Event.current.mousePosition;
  }

  #region Mouse Input

  public bool GetMousePress(int mouseIndex)
  {
    if (Input.GetMouseButtonDown(mouseIndex)) return true;
    return false;
  }

  public bool GetMouseHold(int mouseIndex)
  {
    if (Input.GetMouseButton(mouseIndex)) return true;
    return false;
  }

  public bool GetMouseRelease(int mouseIndex)
  {
    if (Input.GetMouseButtonUp(mouseIndex)) return true;
    return false;
  }

  #endregion

  #region KeInput

  public Vector2 GetDirectionalAxis()
  {
    float v = Input.GetAxis("Vertical");
    float h = Input.GetAxis("Horizontal");

    return new Vector2(v, h);
  }

  #endregion
}
