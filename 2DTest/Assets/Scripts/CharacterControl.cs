using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {


	public float moveSpeed = 2.0f;
	private bool facingRight = true;
	public Animator theAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal");
		if (h != 0) {
			theAnimator.SetBool ("isMoving", true);
			transform.Translate(new Vector2(h * moveSpeed * Time.deltaTime, 0));
		} else {
			theAnimator.SetBool ("isMoving", false);
		}


		if (h < 0 && facingRight)
			Flip ();
		if (h > 0 && !facingRight)
			Flip ();
		if (Input.GetButtonDown("Jump")) {
			theAnimator.SetTrigger("Jump");
			rigidbody2D.AddForce (new Vector2(0, 1000));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
	}
}
