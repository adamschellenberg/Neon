using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float jump;
	public float moveSpeed;
	public Text scoreText;

	float move;
	int score;

	bool onGround;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		onGround = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxis ("Horizontal") != 0) {
			Move ();
		}

		if (Input.GetKeyDown ("space")) {
			Jump ();
		}

		scoreText.text = "Score: " + score;

	}

	void Move(){
		move = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		transform.Translate (move, 0, 0);
	}

	void Jump(){
		if (onGround) {
			rb.AddForce (transform.up * jump * 100);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Collectable") {
			Destroy (other.gameObject);
			score += 1;
		}
	}

	void OnCollisionStay2D (Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			onGround = true;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			onGround = false;
		}
	}
		
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			onGround = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			onGround = false;
		}
	}

}
