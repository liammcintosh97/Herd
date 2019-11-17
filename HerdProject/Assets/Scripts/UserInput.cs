using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonClickType { Null, Press, Hold, Release, DoubleClick }

public class UserInput : Singleton<UserInput>
{
  //Key Input
  private Vector2 _dirAxis = new Vector2();
  private bool _isDirAxisMoving = false;

  //Mouse Input
  private Vector2 _MousePos;
  private Vector2 _MouseAxis;
  private bool _isMouseMoving;

  //Global
  private float clicked = 0;
  private float clickTime = 0;
  public float clickDelay = 0.75f;

  #region Getters and Setters

  public Vector2 MousePos { get; }
  public bool IsMouseMoving { get; }

  public bool IsDirAxisMoving {
    get {
      GetDirectionalAxis();
      return _isDirAxisMoving;
    }
  }

  public Vector2 MouseAxis
  {
    get{
      _MouseAxis = GetMouseDirectionalAxis();
      return _MouseAxis;
    }
  }

  public Vector2 DirAxis {
    get {
      _dirAxis = GetDirectionalAxis();
      return _dirAxis;
    } }

  #endregion

  public void OnGUI()
  {
    _MousePos = Event.current.mousePosition;
  }

  #region Mouse Input

  private Vector2 GetMouseDirectionalAxis() {

    Vector2 vec = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    if (VectorEpsilon(vec)) _isMouseMoving = true;
    else _isMouseMoving = false;

    return vec;

  }

  public bool GetMouseButton(int buttonIndex, ButtonClickType type) {

    //Mouse Press
    if (type == ButtonClickType.Press) {
      if (Input.GetMouseButtonDown(buttonIndex)) return true;
      return false;
    }
    //Mouse Hold
    else if (type == ButtonClickType.Hold)
    {
      if (Input.GetMouseButton(buttonIndex)) return true;
      return false;
    }
    //Mouse Release
    else if (type == ButtonClickType.Release)
    {
      if (Input.GetMouseButtonUp(buttonIndex)) return true;
      return false;
    }
    //Mouse Double Click
    else if (type == ButtonClickType.DoubleClick)
    {
      if (DoubleClickMouse(buttonIndex)) return true;
      return false;
    }

    return false;
  }

  #endregion

  #region KeInput

  private Vector2 GetDirectionalAxis()
  {
    Vector2 vec = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

    if (VectorEpsilon(vec)) _isDirAxisMoving = true;
    else _isDirAxisMoving = false;

    return vec;
  }

  public bool GetKeyButton(KeyCode keyCode, ButtonClickType type) {

    //Mouse Press
    if (type == ButtonClickType.Press)
    {
      if (Input.GetKeyDown(keyCode)) return true;
      return false;
    }
    //Mouse Hold
    else if (type == ButtonClickType.Hold)
    {
      if (Input.GetKey(keyCode)) return true;
      return false;
    }
    //Mouse Release
    else if (type == ButtonClickType.Release)
    {
      if (Input.GetKeyUp(keyCode)) return true;
      return false;
    }
    //Mouse Double Click
    else if (type == ButtonClickType.DoubleClick)
    {
      if (DoubleClickKey(keyCode)) return true;
      return false;
    }

    return false;
  }

  #endregion

  #region Utility 

  private bool VectorEpsilon(Vector2 v) {

    if ((v.x > Mathf.Epsilon || v.x < -Mathf.Epsilon) || 
      (v.y > Mathf.Epsilon || v.y < -Mathf.Epsilon)) return true;
    else return false;

  }

  private bool DoubleClickMouse(int buttoIndex) {

      if (Input.GetMouseButtonDown(buttoIndex))
      {
        clicked++;
        if (clicked == 1) clickTime = Time.time;
      }
      if (clicked > 1 && Time.time - clickTime < clickDelay)
      {
        clicked = 0;
        clickTime = 0;
        return true;
      }
      else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
      return false;
  }

  private bool DoubleClickKey(KeyCode keyCode)
  {

    if (Input.GetKeyDown(keyCode))
    {
      clicked++;
      if (clicked == 1) clickTime = Time.time;
    }
    if (clicked > 1 && Time.time - clickTime < clickDelay)
    {
      clicked = 0;
      clickTime = 0;
      return true;
    }
    else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
    return false;
  }

  #endregion
}

