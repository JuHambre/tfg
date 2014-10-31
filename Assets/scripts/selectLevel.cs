using UnityEngine;
using System.Collections;

public class selectLevel : MonoBehaviour {
	public Texture coutTexture;
	public Texture finishTexture;
	public Texture contadorTexture;
	public Texture ifTexture;
	public Texture whileTexture;
	public Texture forTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width * 0.05f, Screen.height * 0.2f, coutTexture.width*0.4f, coutTexture.height*0.4f), coutTexture)) {
			Application.LoadLevel("cout");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.375f, Screen.height * 0.2f, coutTexture.width*0.4f, coutTexture.height*0.4f), contadorTexture)) {
			Application.LoadLevel("contador");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.2f, coutTexture.width*0.4f, coutTexture.height*0.4f), ifTexture)) {
			Application.LoadLevel("if");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.05f, Screen.height * 0.7f, coutTexture.width*0.4f, coutTexture.height*0.4f), whileTexture)) {
			Application.LoadLevel("while");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.375f, Screen.height * 0.7f, coutTexture.width*0.4f, coutTexture.height*0.4f), forTexture)) {
			Application.LoadLevel("for");
		}
		else if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.7f, coutTexture.width*0.4f, coutTexture.height*0.4f), finishTexture)) {
			Application.LoadLevel("finishlevel");
		}
	}
}
