using UnityEngine;
using System.Collections;

public class MoonGravity : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		//rb.velocity = new Vector3 (0, -1, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		GameObject earth = GameObject.Find ("Earth");
		Vector3 earth_pos = earth.transform.position - transform.position;
		//Debug.Log (earth_pos.ToString ());
		rb.AddForce (earth_pos*5);
	}
}
