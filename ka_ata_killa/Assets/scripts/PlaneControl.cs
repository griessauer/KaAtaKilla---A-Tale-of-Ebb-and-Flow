using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		GameObject moon = GameObject.Find ("Moon");

		float phi = Mathf.Atan2 (moon.transform.position.x, moon.transform.position.z);
		if (phi < 0) {
			phi += 2 * Mathf.PI;
		}
		phi = (phi * 180 / Mathf.PI) + 90;
		float dist = MoonMovement.dist;

		float planePan = 359 - dist/3;
		//Debug.Log (phi);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, phi, planePan);
	}
}
