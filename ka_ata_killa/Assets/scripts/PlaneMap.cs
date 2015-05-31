using UnityEngine;
using System.Collections;

public class PlaneMap : MonoBehaviour {

    static public float[,] map = null;
    static public float step;

	// Use this for initialization
	void Start () {
        Vector3 size = GameObject.Find("FlatEarth").GetComponent<Renderer>().bounds.size;
        step = 5;
        int arraySize = (int)Mathf.Floor((float)(size.x/step));
        map = new float[arraySize,arraySize];

        for (int i = 0; i < arraySize; i ++)
        {
            for (int j = 0; j < arraySize; j++)
            {

                Ray ray = new Ray(new Vector3((i * step)-arraySize/2, 0f, (j * step)-arraySize/2), new Vector3(0, -1, 0));
                // create a plane at 0,0,0 whose normal points to +Y:
                Collider planeCollider = GameObject.Find("FlatEarth").GetComponent<Collider>();
                
                // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
                RaycastHit distance = new RaycastHit();
                // if the ray hits the plane...
                if (planeCollider.Raycast(ray, out distance, 200f))
                {
                     
                    map[i, j] = -distance.point.y;
                                          
                }
                else
                {
                    map[i, j] = -1;
                }
            }         
            
        }
        HousePlacement.PlaceHouses(new float[10, 10]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
