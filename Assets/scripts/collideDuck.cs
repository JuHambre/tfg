using UnityEngine;
using System.Collections;

public class collideDuck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		collision.gameObject.SendMessage ("activarTexto", "pato");
	}
}
