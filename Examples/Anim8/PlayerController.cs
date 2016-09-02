using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	AnimJtor anim;
	SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		anim = new AnimJtor("Player",spriteRenderer);
		anim.Load("Run", 200.0f);
		anim.Load("Idle", 200.0f);
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
