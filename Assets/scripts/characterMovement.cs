using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {
	public Animator characterAnimator;
	public float maxSpeed = 10f;
	public bool textEnabled = false;
	public string texto = "";
	public string animal = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!textEnabled){
			float move = Input.GetAxis ("Horizontal");
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		}
		
		characterAnimator.SetFloat ("Velocidad", rigidbody2D.velocity.x);
	}

	public void activarTexto(string animal)
	{
		textEnabled = true;
		this.animal = animal;
	}

	void OnGUI()
	{
		if(textEnabled)
		{
			texto = GUI.TextField(new Rect(Screen.width * 0.05f, Screen.height * 0.5f, 400, 250),texto);
			if (GUI.Button (new Rect ((Screen.width * 0.05f), (Screen.height * 0.9f), 400, 50), "Comprobar")) {
				if(animal.Equals("tortuga"))
				{
					if(texto.Equals("prueba"))
					{

					}
				}
			}
			// IF GUI.Button... blabla
			// textEnabled = false;
			// comprobar que el texto coincida

		}

	}
}
