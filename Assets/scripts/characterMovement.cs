using UnityEngine;
using System.Collections;
using System;

public class characterMovement : MonoBehaviour {
	public Animator characterAnimator;
	public float maxSpeed = 10f;
	public bool textEnabled = false;
	public string texto = "";
	public string animal = "";
	public GameObject turtleTerminal;
	public GameObject dinamiteTerminal;
	public GameObject sharkTerminal;
	public GameObject warriorTerminal;
	public GameObject mountainTerminal;

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
			// Capturar las tabulaciones porque no las pilla el textarea
			if( Event.current.Equals( Event.KeyboardEvent("tab") ) )
			{
				texto += "\t";
				TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				editor.selectPos = texto.Length + 1;
				editor.pos = texto.Length + 1;
				Event.current.Use();
			}

			texto = GUI.TextArea(new Rect(Screen.width * 0.05f, Screen.height * 0.55f, 400, 200),texto);
			if(animal.Equals("tortuga"))
			{
				turtleTerminal.SetActive(true);
			}
			if(animal.Equals("dinamita"))
			{
				dinamiteTerminal.SetActive(true);
			}
			if(animal.Equals("tiburon"))
			{
				sharkTerminal.SetActive(true);
			}
			if(animal.Equals("guerrero"))
			{
				warriorTerminal.SetActive(true);
			}
			if(animal.Equals("montanya"))
			{
				mountainTerminal.SetActive(true);
			}
			if (GUI.Button (new Rect ((Screen.width * 0.05f), (Screen.height * 0.9f), 400, 50), "Comprobar"))
			{
				// Hacemos split de espacios tabulaciones y saltos de linea ya que en la programacion no influyen
				string [] split = texto.Split(new Char [] {' ', '\n', '\t'});
				string codigo = string.Join("", split);

				// Dependiendo de contra que colisionemos haremos unas acciones u otras
				if(animal.Equals("tortuga"))
				{
					if(codigo.Equals("cout<<\"Hola\";"))
					{
						textEnabled = false;
						Application.LoadLevel("selectlevel");
					}
				}
				if(animal.Equals("tiburon"))
				{
					if(codigo.Equals("tiburon--;"))
					{
						textEnabled = false;
						Application.LoadLevel("selectlevel");
					}
				}
				if(animal.Equals("guerrero"))
				{
					if(codigo.Equals("if(verOrco){cout<<\"¡FUEGO!\";}") || codigo.Equals("if(verOrco==1){cout<<\"¡FUEGO!\";}"))
					{
						textEnabled = false;
						Application.LoadLevel("selectlevel");
					}
				}
				if(animal.Equals("montanya"))
				{
					if(codigo.Equals("while(peldaño==finalMontaña){peldaño++;}"))
					{
						textEnabled = false;
						Application.LoadLevel("selectlevel");
					}
				}
				if(animal.Equals("dinamita"))
				{
					if(codigo.Equals("if(prepararDinamita&&encenderDinamita){destruirRoca();}"))
					{
						textEnabled = false;
						dinamiteTerminal.SetActive(false);
						GameObject stone = GameObject.Find("stone");
						stone.SetActive(false);
					}
				}
			}
		}
	}
}
