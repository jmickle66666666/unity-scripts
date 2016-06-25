using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimJtor : MonoBehaviour {

	float timer = 0;

	
	List<Sprite> currentAnim;
	List<Sprite> downAnim;
	List<Sprite> upAnim;
	List<Sprite> sideAnim;
	List<Sprite> downIdle;
	List<Sprite> upIdle;
	List<Sprite> sideIdle;

	int dir = 0;

	SpriteRenderer spriteRenderer;
	
	int spriteIndex = 0;

	// Use this for initialization
	void Start () {


		downAnim = new List<Sprite>();
		sideAnim = new List<Sprite>();
		upAnim = new List<Sprite>();

		downIdle = new List<Sprite>();
		sideIdle = new List<Sprite>();
		upIdle = new List<Sprite>();

		downAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_down2"));
		downAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_down3"));
		downAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_down4"));
		downAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_down1"));

		upAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_up2"));
		upAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_up3"));
		upAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_up4"));
		upAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_up1"));

		sideAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_side2"));
		sideAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_side3"));
		sideAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_side4"));
		sideAnim.Add(Resources.Load<Sprite>("Sprites/Player/player_side1"));

		sideIdle.Add(Resources.Load<Sprite>("Sprites/Player/player_side1"));
		downIdle.Add(Resources.Load<Sprite>("Sprites/Player/player_down1"));
		upIdle.Add(Resources.Load<Sprite>("Sprites/Player/player_up1"));

		currentAnim = downIdle;

		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 100;
		
		spriteIndex = (int) Mathf.Floor(timer/16) % currentAnim.Count;
		spriteRenderer.sprite = currentAnim[spriteIndex];

		if (Input.GetAxisRaw("Vertical") > 0) dir = 1;
		if (Input.GetAxisRaw("Horizontal") > 0) dir = 0;
		if (Input.GetAxisRaw("Vertical") < 0) dir = 3;
		if (Input.GetAxisRaw("Horizontal") < 0) dir = 2;
		if (Input.GetAxisRaw("Horizontal") != 0) spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;

		bool moving = !(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0);

		if (moving) {
			if (dir == 0) currentAnim = sideAnim;
			if (dir == 1) currentAnim = upAnim;
			if (dir == 2) currentAnim = sideAnim;
			if (dir == 3) currentAnim = downAnim;
		} else {
			timer = 0;
			if (dir == 0) currentAnim = sideIdle;
			if (dir == 1) currentAnim = upIdle;
			if (dir == 2) currentAnim = sideIdle;
			if (dir == 3) currentAnim = downIdle;
			spriteRenderer.sprite = currentAnim[spriteIndex];
		}
	}
}
