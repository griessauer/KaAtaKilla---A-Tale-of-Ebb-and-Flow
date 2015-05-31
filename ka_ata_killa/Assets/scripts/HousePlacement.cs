using UnityEngine;
using System.Collections;

public class HousePlacement : MonoBehaviour {
	public TextAsset imageAsset;
	// Use this for initialization
	void Start () {

		string path = @"D:\Git\KaAtaKilla---A-Tale-of-Ebb-and-Flow\ka_ata_killa\Assets\textures\house_placeholder.png";
		if (System.IO.File.Exists (path)) {
			//Debug.Log ("Test");
			byte[] fileData = System.IO.File.ReadAllBytes (path);
			Texture2D tex = new Texture2D (2, 2);
			tex.LoadImage (fileData);
			GameObject.Find ("Moon").GetComponent<MeshRenderer> ().material.mainTexture = tex;
		}
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < PlaneMap.map.GetLength(0); i++)
        {
            for (int j = 0; j < PlaneMap.map.GetLength(1); j++)
            {



                
            }
        }   
	}
}
