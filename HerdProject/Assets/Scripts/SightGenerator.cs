using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightGenerator : MonoBehaviour
{

  public MeshCollider meshCollider;
  private Mesh mesh;

  [SerializeField]
  private float _length;
  [SerializeField]
  private float _height;
  [SerializeField]
  private float _spread;

 
  public float Length
  {
    get { return _length; }
    set
    {
      _length = value;
      meshCollider.sharedMesh = GenerateMesh();
    }
  }
  public float Height
  {
    get { return _height; }
    set
    {
      _height = value;
      meshCollider.sharedMesh = GenerateMesh();
    }
  }
  public float Spread
  {
    get { return _spread; }
    set
    {
      _spread = value;
      meshCollider.sharedMesh = GenerateMesh();
    }
  }

  Vector3[] verts;
  int[] tris;

  // Start is called before the first frame update
  void Start()
  {
    if (meshCollider == null) {
      meshCollider = GetComponent<MeshCollider>();
      if (meshCollider == null)
      {
        Debug.LogError("Cannot find Mesh Collider");
        return;
      }
  
    }

    meshCollider.sharedMesh = GenerateMesh();
  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Init

  public void InitVertices() {

    float a = Length;
    float b = Spread / 2;
    float c = Mathf.Sqrt((Mathf.Pow(a,2) + Mathf.Pow(b,2)));


    verts = new Vector3[] {

      new Vector3(0,0,0),
      new Vector3(b, 0, Length),
      new Vector3(-b, 0, Length),

      new Vector3(0, -Height, 0),
      new Vector3(b, -Height, Length),
      new Vector3(-b, -Height, Length),
    };
    mesh.vertices = verts;
  }

  public void InitTris() {

    tris = new int[] {

      //Top
      0,2,1,

      //Right1
      0,4,3,

      //Right2
      0,1,4,

      //Back1
      1,2,4,

      //Back2
      2,4,5,
    
      //Bottom
      3,5,4,

      //Left1
      0,3,2,

      //Left2
      3,5,2

    };
    mesh.triangles = tris;
  }

  #endregion

  #region Public Methods

  public Mesh GenerateMesh() {
    mesh = new Mesh();
    InitVertices();
    InitTris();

    return mesh;
  }

  #endregion

}
