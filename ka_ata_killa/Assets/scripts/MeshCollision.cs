using UnityEngine;
using System.Collections;

public class MeshCollision : MonoBehaviour {
	public MeshCollider coll;
	private int houses;
	GameObject house;
	private float radius = 50;
	private float[] thetas;

	// Use this for initialization
	void Start () {
		coll = GetComponent<MeshCollider> ();
		houses = 3;
		InvokeRepeating ("NewHouses", 0, 5);
		//Debug.Log ("Test", gameObject);
		thetas = new float[3];
		thetas [0] = 0;
		thetas [1] = Mathf.PI / 4;
		thetas [2] = -Mathf.PI/4;

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
		float phi = 0;
	if (houses-- > 0) {
//			float theta = Mathf.Asin(z/r);
//			float phi = Mathf.Atan2(y,x);

			float x = radius * Mathf.Cos(thetas[houses])*Mathf.Cos(phi);
			float y = radius * Mathf.Cos(thetas[houses])*Mathf.Sin(phi);
			float z = radius * Mathf.Sin(thetas[houses]);

			Debug.Log ("NewHouse");
//			
//			Debug.Log (houses);
//			Debug.Log (x);
//			Debug.Log (y);
//			Debug.Log (z);

			Vector3 centerOfSphere = transform.position;
			Vector3 placementPosition = new Vector3(x, y, z);
			Vector3 normal = ( placementPosition - centerOfSphere ).normalized; 
	
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
			house.transform.rotation=new Quaternion(normal.x, normal.y,normal.z,1);

	
		}
	}
}
