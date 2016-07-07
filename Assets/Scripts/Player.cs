using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float speed;

	// Use this for initialization
	private void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	private void Update () {

	}

	// FixedUpdate is called once per physics cycle
	private void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");

		rigidBody.AddForce (new Vector2 (moveHorizontal*speed, 0));
	}

}
