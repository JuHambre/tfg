using UnityEngine;
using System.Collections;

public class selectLevel : MonoBehaviour {
	public Texture coutTexture;
	public Texture finishTexture;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width * 0.1f, Screen.height * 0.2f, coutTexture.width*0.5f, coutTexture.height*0.5f), coutTexture)) {
			Application.LoadLevel("cout");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.7f, coutTexture.width*0.5f, coutTexture.height*0.5f), finishTexture)) {
			Application.LoadLevel("finishlevel");
		}
	}
}
