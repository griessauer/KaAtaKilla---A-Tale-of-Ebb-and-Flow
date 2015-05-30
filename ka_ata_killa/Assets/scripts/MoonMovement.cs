using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	private bool isDragging;
	public int followMouseSpeed = 16;



	void OnMouseDown(){
		//Destroy (gameObject);
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);

		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		isDragging = true;
		}

	void OnMouseDrag()
	{
		float radius_ref = 110;
		float x;
		float y;
		float radius = Mathf.Sqrt (Mathf.Pow (transform.position.x, 2) + Mathf.Pow (transform.position.y, 2));
		float phi = Mathf.Atan2 (transform.position.y, transform.position.x);


		Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	
		if (mouse.y == 0 && mouse.x == 0) {
			return;
		}

		float phiMouse = Mathf.Atan2 (mouse.y, mouse.x);

//		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//
//		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;


		/*
		if (radius < radius_ref-10 || radius >radius_ref+10) {
			Debug.Log(radius);
			x = radius_ref*Mathf.Cos(phi);
			float y = radius_ref*Mathf.Sin(phi);
			
			transform.position = new Vector3(x, y, transform.position.z);
			//isDragging = false;
			return;
		}
		*/

//		float phic = Mathf.Clamp (phi, 0, 2 * Mathf.PI);
//		Debug.Log ("Test");
//		Debug.Log (phi);
//		Debug.Log (phic);

		if (phi < 0) {
			phi += 2 * Mathf.PI;
		}
		if (phiMouse < 0) {
			phiMouse += 2 * Mathf.PI;
		}
//				Debug.Log ("Test");
//			 //   Debug.Log (phi);
//		Debug.Log (Mathf.Abs (phi - phiMouse));
//		Debug.Log (15*Mathf.PI / 8);

		//transform.position = curPosition;

		if (Mathf.Abs (phi - phiMouse) > Mathf.PI / followMouseSpeed
		    && Mathf.Abs (phi - phiMouse) < (2*followMouseSpeed-1)*Mathf.PI / followMouseSpeed) {

			if(Mathf.Abs (phi - phiMouse) > Mathf.PI/2&&
			   (phi < Mathf.PI/2 || phi > 3*Mathf.PI/2) &&
			   (phiMouse < Mathf.PI/2 || phiMouse > 3*Mathf.PI/2))
			{
				
				if(phi-phiMouse<0)
				{
					x = radius_ref * Mathf.Cos (phi-Mathf.PI / followMouseSpeed);
					y = radius_ref * Mathf.Sin (phi-Mathf.PI / followMouseSpeed);
				}
				else
				{
					x = radius_ref * Mathf.Cos (phi+Mathf.PI / followMouseSpeed);
					y = radius_ref * Mathf.Sin (phi+Mathf.PI / followMouseSpeed);
				}


			}
			else{

				if(phi-phiMouse<0)
				{
					x = radius_ref * Mathf.Cos (phi+Mathf.PI / followMouseSpeed);
					y = radius_ref * Mathf.Sin (phi+Mathf.PI / followMouseSpeed);
				}
				else
				{
					x = radius_ref * Mathf.Cos (phi-Mathf.PI / followMouseSpeed);
					y = radius_ref * Mathf.Sin (phi-Mathf.PI / followMouseSpeed);
				}
			}

		
		} else {
			
			x = radius_ref * Mathf.Cos (phiMouse);
			y = radius_ref * Mathf.Sin (phiMouse);
		}



		transform.position = new Vector3 (x, y, transform.position.z);

//		if (radius != 200) {
//			transform.position = new Vector3(x+1, transform.position.y, transform.position.z);
//
//			isDragging = false;
//		}
	
	
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown (0)) {
//			Debug.Log("Test");
//		}
		//Destroy (gameObject);
	}
}
