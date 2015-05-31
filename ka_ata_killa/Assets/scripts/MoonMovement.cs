using UnityEngine;
using System.Collections;

public class MoonMovement : MonoBehaviour {

	private Vector3 screenPoint;
	//private Vector3 offset;
	public int followMouseSpeed = 8;
	private float radius;
	public static float dist = 0;
    public static float[,] WaterLvl = null;
	//public float distance = 0;


	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);

		//offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, screenPoint.y, Input.mousePosition.z));
	}
    void OnMouseUp()
    {
        //float[,] map_local;
        float step = PlaneMap.step;
        
        if (PlaneMap.map != null)
        {
            //map_local = PlaneMap.map;
            if (WaterLvl == null)
            {
                WaterLvl = new float[PlaneMap.map.GetLength(0), PlaneMap.map.GetLength(1)];
            }
           
            Vector2 moonpos = new Vector2(GameObject.Find("Moon").transform.position.x, GameObject.Find("Moon").transform.position.z);
            float moonPosLenght = Mathf.Sqrt(moonpos.x*moonpos.x+ moonpos.y*moonpos.y);
            for (int i = 0; i < PlaneMap.map.GetLength(0); i++)
            {
                for (int j = 0; j < PlaneMap.map.GetLength(1); j++)
                {
                    
                    float h = 10;
                    float c = 10;

                    if (PlaneMap.map[i, j] > 0)
                    {
                        WaterLvl[i,j] = Mathf.Max(Vector2.Dot(moonpos, new Vector2(i * step, j * step)) / moonPosLenght * c + h - PlaneMap.map[i, j], 0);
                    }
                    else
                    { WaterLvl[i, j] = 0; 
                    }
                }
            }
        }
    }

	void OnMouseDrag()
	{
		float x;
		float z;
		float phi = Mathf.Atan2 (transform.position.x, transform.position.z);
		Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	
		if (mouse.z == 0 && mouse.x == 0) {
			return;
		}
		float phiMouse = Mathf.Atan2 (mouse.x, mouse.z);
		float radMouse = Mathf.Sqrt (Mathf.Pow (mouse.x, 2) + Mathf.Pow (mouse.z, 2));

		if (phi < 0) {
			phi += 2 * Mathf.PI;
		}
		if (phiMouse < 0) {
			phiMouse += 2 * Mathf.PI;
		}

		float radius_ref = Mathf.Clamp (radMouse, radius - 30, radius);
		dist = radius - radius_ref;

		if (Mathf.Abs (phi - phiMouse) > Mathf.PI / followMouseSpeed
		    && Mathf.Abs (phi - phiMouse) < (2*followMouseSpeed-1)*Mathf.PI / followMouseSpeed) {

			if(Mathf.Abs (phi - phiMouse) > Mathf.PI/2&&
			   (phi < Mathf.PI/2 || phi > 3*Mathf.PI/2) &&
			   (phiMouse < Mathf.PI/2 || phiMouse > 3*Mathf.PI/2))
			{				
				if(phi-phiMouse<0)
				{
					z = radius_ref * Mathf.Cos (phi-Mathf.PI / followMouseSpeed);
					x = radius_ref * Mathf.Sin (phi-Mathf.PI / followMouseSpeed);
				}
				else
				{
					z = radius_ref * Mathf.Cos (phi+Mathf.PI / followMouseSpeed);
					x = radius_ref * Mathf.Sin (phi+Mathf.PI / followMouseSpeed);
				}
			}
			else{
				if(phi-phiMouse<0)
				{
					z = radius_ref * Mathf.Cos (phi+Mathf.PI / followMouseSpeed);
					x = radius_ref * Mathf.Sin (phi+Mathf.PI / followMouseSpeed);
				}
				else
				{
					z = radius_ref * Mathf.Cos (phi-Mathf.PI / followMouseSpeed);
					x = radius_ref * Mathf.Sin (phi-Mathf.PI / followMouseSpeed);
				}
			}
		} else {

			z = radius_ref * Mathf.Cos (phiMouse);
			x = radius_ref * Mathf.Sin (phiMouse);
		}

		transform.position = new Vector3 (x, transform.position.y, z);
	
	}
	// Use this for initialization
	void Start () {
		radius = Mathf.Sqrt (Mathf.Pow (transform.position.x, 2) + Mathf.Pow (transform.position.z, 2));
	}
	void Update()
	{
	}
}
