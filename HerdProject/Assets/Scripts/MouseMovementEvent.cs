using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementEvent
{
  private Vector2 _position;
  private Vector2 _axis;
  private bool _isMoving;

  public Vector2 Position { get; set; }

  public Vector2 Axis
  {
    get { return _axis; }
    set {
      _axis = value;
      if (_axis.x == 0 || _axis.y == 0) IsMoving = false;
      else IsMoving = true;
    }
  }

  public bool IsMoving { get; set; }

}
