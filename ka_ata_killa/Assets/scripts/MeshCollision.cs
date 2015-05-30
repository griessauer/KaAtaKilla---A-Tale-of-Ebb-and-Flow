using UnityEngine;
using System.Collections;

public class MeshCollision : MonoBehaviour {
	public MeshCollider coll;
	private int houses;
	GameObject house;
	private float radius = 50.5f;
	private float[] thetas;
	private float[] phis;

	// Use this for initialization
	void Start () {
		coll = GetComponent<MeshCollider> ();
		houses = 24;
		InvokeRepeating ("NewHouses", 0, 0.5f);
		//Debug.Log ("Test", gameObject);
		thetas = new float[8];
		thetas [0] = 0;
		thetas [1] = Mathf.PI / 4;
		thetas [2] = -Mathf.PI/4;
		thetas [3] = -Mathf.PI/2;
		thetas [4] = Mathf.PI/2;
		thetas [5] = 3*Mathf.PI/2;
		thetas [6] = -3*Mathf.PI/2;
		thetas [7] = Mathf.PI;
		
		phis = new float[3];
		phis [0] = 0;
		phis [1] = Mathf.PI / 4;
		phis [2] = -Mathf.PI/4;
	}

	void OnCollisionEnter(Collision collision)
	{
		//Vector3 coll_pos = coll.ClosestPointOnBounds (collision.transform.position);
//		Debug.Log ("Collision");
//		Debug.Log (collision.transform.position);
//		Debug.Log (coll_pos);
	}
	// Update is called once per frame
	void NewHouses () {
		//float phi = 0;
	if (houses-- > 0) {
//			float theta = Mathf.Asin(z/r);
//			float phi = Mathf.Atan2(y,x);

//			
//			Debug.Log (houses);
//			Debug.Log (houses%8);

			//int phi_ind = houses/3;
			float x = radius * Mathf.Cos(thetas[houses%8])*Mathf.Cos(phis[houses%3]);
			float y = radius * Mathf.Cos(thetas[houses%8])*Mathf.Sin(phis[houses%3]);
			float z = radius * Mathf.Sin(thetas[houses%8]);

			Debug.Log ("NewHouse");
//			
//			Debug.Log (houses);
//			Debug.Log (houses%8);
//			Debug.Log (x);
//			Debug.Log (y);

			Vector3 centerOfSphere = transform.position;
			Vector3 placementPosition = new Vector3(x, y, z);
			Vector3 normal = ( placementPosition - centerOfSphere ).normalized; 
			
						//Debug.Log (normal);
//			house = new GameObject("house");
//
//			house.AddComponent<Rigidbody>();
//			house.AddComponent<BoxCollider>();
//			house.transform.position = new Vector3(x,y,z);

			house = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			house = new GameObject("house");
//			MeshFilter meshFilter = house.AddComponent<MeshFilter>();
//			house.AddComponent<MeshRenderer>();
			house.transform.position = new Vector3(x,y,z);
			house.transform.rotation= Quaternion.FromToRotation(Vector3.right,normal);
			//house.transform.eulerAngles = normal*90;

	
		}
	}
}
