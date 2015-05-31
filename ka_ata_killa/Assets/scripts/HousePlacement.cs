using UnityEngine;
using System.Collections;

public class HousePlacement : MonoBehaviour {
	public TextAsset imageAsset;
	// Use this for initialization
	void Start () {


		string path = @"D:\Git\KaAtaKilla---A-Tale-of-Ebb-and-Flow\ka_ata_killa\Assets\textures\Haus3.png";

		if (System.IO.File.Exists (path)) {
			//Debug.Log ("Test");
			byte[] fileData = System.IO.File.ReadAllBytes (path);
			//Texture2D tex = new Texture2D (2, 2,TextureFormat.RGB24,false);
            Texture2D tex = Resources.Load("Haus3") as Texture2D;
            tex.alphaIsTransparency = true;
            
			//.LoadImage (fileData);
			GameObject.Find ("Moon").GetComponent<MeshRenderer> ().material.mainTexture = tex;
		}
	}
    static private GameObject[,] local_planes;
	
	// Update is called once per frame
	void Update () {
        
        
	}
    public static void PlaceHouses(float[,] population)
    {
       if(local_planes == null)
       {
           local_planes = new GameObject[PlaneMap.map.GetLength(0),PlaneMap.map.GetLength(1)];
           float temp_step = PlaneMap.step;
           for (int i = 0; i < PlaneMap.map.GetLength(0); i++)
           {
               for (int j = 0; j < PlaneMap.map.GetLength(1); j++)
               {
                   Vector3 temp = new Vector3(i * temp_step - PlaneMap.map.GetLength(0) * temp_step / 2, 4, j * temp_step - PlaneMap.map.GetLength(1) * temp_step / 2);
                   GameObject temp_plane = GameObject.CreatePrimitive(PrimitiveType.Plane);       
                   temp_plane.transform.position = temp;
                   temp_plane.transform.localScale.Scale(new Vector3(temp_step, 1, temp_step));
                   
                   
                   
                   
                    //Debug.Log ("Test");
                    Texture2D tex = Resources.Load("Haus3") as Texture2D;
                       
                    tex.alphaIsTransparency = true;
                    temp_plane.GetComponent<Renderer>().material.mainTexture = tex;
                    temp_plane.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
                       

                       
                   local_planes[i, j] = temp_plane;
               }
           }   
       }

       for (int i = 0; i < local_planes.GetLength(0); i++)
        {
            for (int j = 0; j < local_planes.GetLength(1); j++)
            {
                local_planes[i,j].SetActive(population[i,j] > 0f);
            }
        }   
    }
}
