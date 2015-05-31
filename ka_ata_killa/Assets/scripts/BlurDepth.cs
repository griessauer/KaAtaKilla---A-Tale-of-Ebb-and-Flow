using UnityEngine;
using System.Collections;

public class BlurDepth : MonoBehaviour {

	public int blurDepth = 2;
	public float sigma = 2;
	public float r = 2;
	public int phi = 2;
	public int tau = 2;
	private float[,] g_blur;
	public static ArrayList population = new ArrayList();
	bool initPopulation = true;

	// Use this for initialization
	void Start () {
		g_blur = new float[blurDepth, blurDepth];
		for (int i = 0; i < blurDepth; i++) 
		{
			for(int j = 0; j < blurDepth; j++)
			{
				g_blur[i,j] = Mathf.Exp(-(Mathf.Pow(i,2)+Mathf.Pow(j,2))/(2*Mathf.Pow(sigma,2)))*1/(2*Mathf.Pow(sigma,2));
			}
		}
		population = new ArrayList (Mathf.Max (phi, tau) + 1);

//		Debug.Log (g_blur.GetLength(0));
//		Debug.Log (g_blur.GetLength(1));
	}

	float getBlur(int x, int y)
	{
		if (Mathf.Abs (x) >= blurDepth || Mathf.Abs (y) >= blurDepth) {
			return 0;
		}
//		Debug.Log ("Test");
//		Debug.Log (x);
//		Debug.Log (y);
		return g_blur [Mathf.Abs (x), Mathf.Abs (y)];
	}

	float[,] update_population(float[,] k, float[,] n, float[,] n_phi, float[,] n_tau)
	{
		int x = k.GetLength (0);
		int y = k.GetLength (1);
		float[,] ret = new float[x,y];
		float new_n;

		for (int i = 0; i < x; i++) 
		{
			for(int j = 0; j < y; j++)
			{
				new_n = n[i,j]+1+r*n_phi[i,j]*(k[i,j]-n_tau[i,j])/k[i,j];
				new_n = Mathf.Max(new_n, 0);
				ret[i,j] += new_n;

				
				for (int l = -blurDepth; l < blurDepth; l++) 
				{
					if(i+l<0 || i+l>=x)
					{
						continue;
					}
					for(int m = -blurDepth; m < blurDepth; m++)
					{
						if(j+m<0 || j+m>=y)
						{
							continue;
						}
						ret[i+l,j+m] += new_n * getBlur(l,m);
					}
				}
			}
		}

		return ret;

	}


	// Update is called once per frame
	void Update () {
		if (MoonMovement.WaterLvl == null) {
			return;
		}
		if (initPopulation) {
			
			for (int i = 0; i <= Mathf.Max (phi, tau); i++) {
				population.Add (new float[MoonMovement.WaterLvl.GetLength(0), MoonMovement.WaterLvl.GetLength(1)]);
			}
			initPopulation = false;
		}
		float[,] k = MoonMovement.WaterLvl; 
		//Debug.Log (k[0,0]);
		float[,] n = (float[,])population[population.Count-1]; 
		float[,] n_phi = (float[,])population[population.Count-1-phi];
		float[,] n_tau = (float[,])population[population.Count-1-tau];
        float[,] current_population =       update_population (k, n, n_phi, n_tau);
		population.Add (current_population);
        HousePlacement.PlaceHouses(current_population);
		while (population.Count > (Mathf.Max (phi, tau)+1)) {
			population.RemoveAt(0);
		}
                   
	}
}




