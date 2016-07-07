using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private Rigidbody2D rigidBody;
	private Animator animator;

	private bool grounded = false;

	// Use this for initialization
	private void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	private void Update () {
		// || means OR
		if(Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
			//Does this code if the statement is true
			Jump ();
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			Attack ();
		}
	}

	// FixedUpdate is called once per physics cycle
	private void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		if (moveHorizontal != 0) {
			animator.SetBool ("playerWalking", true);
		} else {
			animator.SetBool ("playerWalking", false);
		}

		rigidBody.velocity = new Vector2 (moveHorizontal*speed, rigidBody.velocity.y);


		Vector3 groundCheck = transform.position;
		groundCheck.y -= 1;
		grounded = Physics2D.Linecast (transform.position, groundCheck, 1 << 
			LayerMask.NameToLayer ("Ground"));
	}

	private void Jump(){
		if(grounded){
			rigidBody.AddForce(new Vector2(0f, jumpForce));
		}
	}

	private void Attack(){
		animator.SetTrigger ("playerAttack");
	}

}
