using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animate : MonoBehaviour {

	// List of animations for the object
	Dictionary<string, Sprite> animations;
	// Internal timer
	float timer = 0;
	// Name of currently playing animation
	string currentAnim;
	// Sprite Renderer component so it can play animations dummy
	SpriteRenderer spriteRenderer;
	// Current frame
	int spriteIndex = 0;

	// Use this for initialization
	void Start () {
		InitializeList();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Initialize animations list
	void InitializeList() {
		if (animations == null) animations = new Dictionary<string, Sprite>();
	}

	// Adds a sprite frame to an animation, creating the animation if it doesn't already exist
	void Add (string name, Sprite frame) {
		if (animations.ContainsKey(name)) {
			// If the animation exists, add the new frame to the end.
			animations[name].Add(frame);
		} else {
			// If the animation doesn't exist, create a new animation for it.
			List<Sprite> newAnimation = new List<Sprite>();
			// Then add the frame
			newAnimation.Add(frame);
			animations.Add(name,newAnimation);
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 100;
		spriteIndex = (int) Mathf.Floor(timer/16) % animations[currentAnim].Count;
		spriteRenderer.sprite = animations[currentAnim][spriteIndex];
	}

	// Play a new animations, this resets the frame too.
	void Play (string animation) {
		currentAnim = animation;
		timer = 0;
	}
}
