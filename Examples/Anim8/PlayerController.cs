using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	AnimJtor anim;
	SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[0];

		anim = new AnimJtor("Player",spriteRenderer);
		anim.Load("Run");
		anim.Load("Idle");
		anim.speed = 200.0f;
	}
	
	void Update () {
		bool moving = !(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0);

		if (moving) {
			anim.Play("Run");
		} else {
			anim.Play("Idle");
		}

		anim.Update();
	}
}
