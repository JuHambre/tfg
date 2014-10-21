using UnityEngine;
using System.Collections;

public class bottontitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Se llama en cada frame
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.2f, 200, 50), "Empezar el juego")) {
			Application.LoadLevel("selectlevel");
		}
	}
}
