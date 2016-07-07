using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private Animator animator;
	public float speed;
	public float jumpForce;

	private bool grounded = false;

	// Use this for initialization
	private void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	private void Update () {
		//If user presses a button, make the character jump

		if (Input.GetKeyDown (KeyCode.Space)) {
			Attack ();
		}

		// || means OR
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
			Jump ();
		}

	}

	// FixedUpdate is called once per physics cycle
	private void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//If moveHorizontal is not 0, set playerWalking to true.
		//Otherwise, set playerWalking to false.
		if (moveHorizontal != 0) {
			animator.SetBool ("playerWalking", true);
		} else {
			animator.SetBool ("playerWalking", false);
		}

		rigidBody.AddForce (new Vector2 (moveHorizontal*speed, 0));

		Vector3 groundCheck = transform.position;
		groundCheck.y -= 1;
		grounded = Physics2D.Linecast (transform.position, groundCheck,
		                               1 << LayerMask.NameToLayer ("Ground"));
	}

	private void Jump(){
		if (grounded) {
			rigidBody.AddForce (new Vector2 (0, jumpForce));
		}
	}

	private void Attack(){
		animator.SetTrigger ("playerAttack");
	}

}
