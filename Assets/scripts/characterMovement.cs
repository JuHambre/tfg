using UnityEngine;
using System.Collections;
using System;

public class characterMovement : MonoBehaviour {
	public Animator characterAnimator;
	public float maxSpeed = 10f;
	public bool textEnabled = false;
	public bool mensajeError = false;
	public string texto = "";
	public string animal = "";
	public string resultado = "";
	public GameObject turtleTerminal;
	public GameObject dinamiteTerminal;
	public GameObject sharkTerminal;
	public GameObject warriorTerminal;
	public GameObject mountainTerminal;
	public GameObject stairsTerminal;
	public GameObject monsterTerminal;
	public GameObject vegetablesTerminal;
	public GameObject duckTerminal;
	public GameObject forestTerminal;
	public GUIStyle styleError;

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

	public void cargarNivel(string nivel)
	{
		GameObject correct = GameObject.Find("correct");
		correct.renderer.enabled = true;
		StartCoroutine (cargarNivelPausa (nivel));
	}

	public IEnumerator cargarNivelPausa(string nivel)
	{
		yield return new WaitForSeconds (2);
		Application.LoadLevel (nivel);
	}

	public void activarTexto(string animal)
	{
		textEnabled = true;
		this.animal = animal;
		texto = "";
	}

	public string conditionCout(string code)
	{
		string result = "";

		if(!(code.Contains("cout<<")))
		{
			result = "Parece que no has escrito correctamente o no has puesto la palabra cout, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("cout<<\"")))
		{
			result = "Parece que has olvidado las comillas despues del cout, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("\";")))
		{
			result = "Parece que has olvidado las comillas del final del cout o el punto y coma, modifica tu codigo e intentalo de nuevo";
		}

		return result;
	}

	public string conditionIf(string code)
	{
		string result = "";

		if(!(code.Contains("if")))
		{
			result = "Parece que no has escrito correctamente o no has puesto la palabra if, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("if(")))
		{
			result = "Parece que has olvidado el parentesis despues del if, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("){")))
		{
			result = "Parece que has olvidado el parentesis de cierre o la llave de apertura, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("}")))
		{
			result = "Parece que has olvidado la llave de cierre, modifica tu codigo e intentalo de nuevo";
		}

		return result;
	}

	public string conditionFor(string code)
	{
		string result = "";

		if(!(code.Contains("for")))
		{
			result = "Parece que no has escrito correctamente o no has puesto la palabra for, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("for(")))
		{
			result = "Parece que has olvidado el parentesis despues del for, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("){")))
		{
			result = "Parece que has olvidado el parentesis de cierre o la llave de apertura, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("}")))
		{
			result = "Parece que has olvidado la llave de cierre, modifica tu codigo e intentalo de nuevo";
		}

		return result;
	}

	public string conditionWhile(string code)
	{
		string result = "";

		if(!(code.Contains("while")))
		{
			result = "Parece que no has escrito correctamente o no has puesto la palabra while, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("while(")))
		{
			result = "Parece que has olvidado el parentesis despues del while, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("){")))
		{
			result = "Parece que has olvidado el parentesis de cierre o la llave de apertura, modifica tu codigo e intentalo de nuevo";
		}
		else if(!(code.Contains("}")))
		{
			result = "Parece que has olvidado la llave de cierre, modifica tu codigo e intentalo de nuevo";
		}

		return result;
	}

	void OnGUI()
	{		
		if(textEnabled)
		{
			// Capturar las tabulaciones porque no las pilla el textarea
			if( Event.current.Equals( Event.KeyboardEvent("tab") ) )
			{
				TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				String comienzoCadena = texto.Substring(0, editor.selectPos);
				String finalCadena = texto.Substring(editor.selectPos, texto.Length-editor.selectPos);
				texto = comienzoCadena + "\t" + finalCadena;
				editor.selectPos++;
				editor.pos++;
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
			if(animal.Equals("monstruo"))
			{
				monsterTerminal.SetActive(true);
			}
			if(animal.Equals("verduras"))
			{
				vegetablesTerminal.SetActive(true);
			}
			if(animal.Equals("pato"))
			{
				duckTerminal.SetActive(true);
			}
			if(animal.Equals("bosque"))
			{
				forestTerminal.SetActive(true);
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
			if(animal.Equals("escaleras"))
			{
				stairsTerminal.SetActive(true);
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
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "";
						resultado = conditionCout(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("tiburon"))
				{
					if(codigo.Equals("tiburon--;"))
					{
						textEnabled = false;
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						mensajeError=true;
					}
				}
				if(animal.Equals("guerrero"))
				{
					if(codigo.Equals("if(verOrco){cout<<\"¡FUEGO!\";}") || codigo.Equals("if(verOrco==1){cout<<\"¡FUEGO!\";}"))
					{
						textEnabled = false;
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "";
						resultado = conditionCout(codigo);
						if(resultado == "")
						{
							resultado = conditionIf(codigo);
							if(resultado == "")
							{
								resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
							}
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("montanya"))
				{
					if(codigo.Equals("while(peldaño==finalMontaña){peldaño++;}"))
					{
						textEnabled = false;
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "";
						resultado = conditionWhile(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("escaleras"))
				{
					if(codigo.Equals("for(escalon=0;escalon==finalEscaleras;escalon++){cout<<escalon;}"))
					{
						textEnabled = false;
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "";
						resultado = conditionCout(codigo);
						if(resultado == "")
						{
							resultado = conditionFor(codigo);
							if(resultado == "")
							{
								resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
							}
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("dinamita"))
				{
					if(codigo.Equals("if(prepararDinamita&&encenderDinamita){roca--;}") ||
					   codigo.Equals("if(prepararDinamita==1&&encenderDinamita){roca--;}") ||
					   codigo.Equals("if(prepararDinamita&&encenderDinamita==1){roca--;}") ||
					   codigo.Equals("if(prepararDinamita==1&&encenderDinamita==1){roca--;}"))
					{
						textEnabled = false;
						dinamiteTerminal.SetActive(false);
						GameObject stone = GameObject.Find("stone");
						stone.SetActive(false);
						resultado = "";
						mensajeError = false;
					}
					else
					{
						resultado = "";
						resultado = conditionIf(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("monstruo"))
				{
					if(codigo.Equals("if(escaparMonstruo||eliminarMonstruo){monstruo--;}") ||
					   codigo.Equals("if(escaparMonstruo==1||eliminarMonstruo){monstruo--;}") ||
					   codigo.Equals("if(escaparMonstruo||eliminarMonstruo==1){monstruo--;}") ||
					   codigo.Equals("if(escaparMonstruo==1||eliminarMonstruo==1){monstruo--;}"))
					{
						textEnabled = false;
						monsterTerminal.SetActive(false);
						GameObject monster = GameObject.Find("monster");
						monster.SetActive(false);
						resultado = "";
						mensajeError = false;
					}
					else
					{
						resultado = "";
						resultado = conditionIf(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("verduras"))
				{
					if(codigo.Equals("if(gustarVerduras){comer++;}else{comer--;}") ||
					   codigo.Equals("if(gustarVerduras==1){comer++;}else{comer--;}"))
					{
						textEnabled = false;
						vegetablesTerminal.SetActive(false);
						GameObject vegetables = GameObject.Find("vegetables");
						vegetables.SetActive(false);
						resultado = "";
						mensajeError = false;
					}
					else
					{
						resultado = "";
						resultado = conditionIf(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("pato"))
				{
					if(codigo.Equals("for(fila=0;fila==ultimaFila;fila++){" +
						"for(columna=0;columna==ultimaColumna;columna++){pato--;}}"))
					{
						textEnabled = false;
						duckTerminal.SetActive(false);
						GameObject duck = GameObject.Find("duck");
						duck.SetActive(false);
						resultado = "";
						mensajeError = false;
					}
					else
					{
						resultado = "";
						resultado = conditionFor(codigo);
						if(resultado == "")
						{
							resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
						}
						mensajeError=true;
					}
				}
				if(animal.Equals("bosque"))
				{
					if(codigo.Equals("for(arbol=0;arbol==ultimoArbol;arbol++){if(verEnemigo){huir++;}}") ||
					   codigo.Equals("for(arbol=0;arbol==ultimoArbol;arbol++){if(verEnemigo==1){huir++;}}"))
					{
						textEnabled = false;
						resultado = "";
						mensajeError = false;
						cargarNivel("selectlevel");
					}
					else
					{
						resultado = "";
						resultado = conditionIf(codigo);
						if(resultado == "")
						{
							resultado = conditionFor(codigo);
							if(resultado == "")
							{
								resultado = "Parece que la sintaxis de tu codigo no es correcta, modifica tu codigo e intentalo de nuevo";
							}
						}
						mensajeError=true;
					}
				}
			}
			if(mensajeError == true)
			{
				GUI.Label(new Rect(Screen.width * 0.6f, Screen.height * 0.55f, 100, 100), resultado, styleError);
			}
		}
	}
}
