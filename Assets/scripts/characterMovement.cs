using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {
	public Animator characterAnimator;
	public float maxSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		characterAnimator.SetFloat ("Velocidad", rigidbody2D.velocity.x); 
	}
}
