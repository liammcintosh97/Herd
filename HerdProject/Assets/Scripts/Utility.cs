using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
  public static Component ComponentCheck<T>(GameObject g, Component c) {

    if (c == null)
    {
      c = FindComponent<T>(g);
      if (c == null) return null;
      else return c;
    }
    return c;
  }

  #region Private Methods
  private static Component FindComponent<T>(GameObject g) {
    //Goes through all methods of component retreaval until it finds the requested component or returns null
    Component c;

    c = g.GetComponent(typeof(T));
    if (c == null) c = g.GetComponentInChildren(typeof(T));
    if (c == null) c = g.GetComponentInParent(typeof(T));

    return c;
  }
  #endregion

}
