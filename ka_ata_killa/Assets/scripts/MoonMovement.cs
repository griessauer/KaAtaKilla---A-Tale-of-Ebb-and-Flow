using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	public int followMouseSpeed = 8;
	private float radius_ref;


	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);

		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}

	void OnMouseDrag()
	{
		float x;
		float y;
		float phi = Mathf.Atan2 (transform.position.y, transform.position.x);
		Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	
		if (mouse.y == 0 && mouse.x == 0) {
			return;
		}

		float phiMouse = Mathf.Atan2 (mouse.y, mouse.x);

		if (phi < 0) {
			phi += 2 * Mathf.PI;
		}
		if (phiMouse < 0) {
			phiMouse += 2 * Mathf.PI;
		}

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
	
	}
	// Use this for initialization
	void Start () {
		radius_ref = Mathf.Sqrt (Mathf.Pow (transform.position.x, 2) + Mathf.Pow (transform.position.y, 2));
	}

}
