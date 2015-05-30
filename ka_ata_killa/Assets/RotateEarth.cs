using UnityEngine;
using System.Collections;

public class RotateEarth : MonoBehaviour {

  public Vector3 axis;

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
    gameObject.transform.Rotate(axis, Time.deltaTime * 10);
	}
}
