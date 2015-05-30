using UnityEngine;
using System.Collections;
using Assets;

public class PrologueController : MonoBehaviour {

  public GameObject fadeInPlane;
  public Material fadeInPlaneMaterial;

  public Vector3 camPanStart;
  public Vector3 camPanEnd;

  public float fadeInSpeed = 0.5f;
  public float panSpeed = 1f;

  private const int STATE_FADEIN = 0;
  private const int STATE_PAN = 1;
  private const int STATE_WAVE = 2;
  private const int STATE_TITLESCREEN = 3;

  private int currentState = -1;

	// Use this for initialization
	void Start () {
    fadeInPlaneMaterial = fadeInPlane.GetComponent<MeshRenderer>().material;
    setState(STATE_FADEIN);
	}

  private void setAlpha(float a)
  {
    Color black = fadeInPlaneMaterial.color;
    black.a = Mathf.Max(0f, a);
    fadeInPlaneMaterial.color = black;
    Debug.Log("Black alpha: "+fadeInPlaneMaterial.color.a);
  }
	
	// Update is called once per frame
	void Update () {
	  // If we don't want to skip the prologue, only check this in STATE_TITLESCREEN
    if (Input.anyKeyDown || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
    {
      Application.LoadLevel("moontest"); // start game
    }

    switch (currentState)
    {
      case STATE_FADEIN:
        // TODO fade out in black plane
        setAlpha(fadeInPlaneMaterial.color.a - Time.deltaTime * fadeInSpeed);
        if (fadeInPlaneMaterial.color.a == 0)
        {
          setState(STATE_PAN);
        }
        break;
      case STATE_PAN:
        // TODO pan camera over scroll, play narrator
        Camera.main.transform.Translate(Vector3.right * Time.deltaTime * panSpeed);
        if (Camera.main.transform.position.x > camPanEnd.x)
        {
          Camera.main.transform.position = camPanEnd;
          setState(STATE_WAVE);
        }
        break;
      case STATE_WAVE:
        // TODO move wave from the right above everything else
        if (true)
        {
          setState(STATE_TITLESCREEN);
        }
        break;
      case STATE_TITLESCREEN:
        // pan up to moon
        // show title

        // move water level slowly up and down (as unity animation?)

        
        break;
    }
	}

  void setState(int newState)
  {
    switch (newState)
    {
      case STATE_FADEIN:
        setAlpha(1);
        Camera.main.transform.position = camPanStart;
        GetComponent<AudioSource>().Play();
        break;
      case STATE_PAN:
        // start narrator audio
        // start music if not already running
        break;
    }

    currentState = newState;
  }
}
