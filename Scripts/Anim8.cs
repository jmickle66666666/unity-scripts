using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Anim8 {

	// Animation control
	float timer = 0;
	int spriteIndex = 0;

	// Name of animation set to use
	string animationSet;

	// Current animation information
	List<Sprite> currentAnim;
	float currentSpeed;
	
	// Stored animations
	Dictionary<string, List<Sprite>> animations;
	Dictionary<string, float> animationSpeeds;
	
	// SpriteRenderer reference
	SpriteRenderer spriteRenderer;
	
	// Initialization
	public Anim8(string animationSet, SpriteRenderer sr) {
		spriteRenderer = sr;
		this.animationSet = animationSet;
		animations = new Dictionary<string, List<Sprite>>();
		animationSpeeds = new Dictionary<string, float>();
	}

	// Load an animation
	public void Load(string name, float speed) {

		// Load all the frames for the 'name' animation
		Sprite frame = null;

		// We start at 1 lol!!!
		int num = 1;

		// Create the frame lists for the new animation
		animations.Add(name,new List<Sprite>());
		animationSpeeds.Add(name, speed);

		// "Never use while(true)" ~ Jonathan Blow probably?
		while (true) {
			// Build the frame path and get the frame
			string path = "Sprites/"+animationSet+"/"+name+"_"+num.ToString();
			frame = Resources.Load<Sprite>(path);

			// If the frame found, add it, if not we've got them all
			if (frame != null) {
				animations[name].Add(frame);
			} else {
				break;
			}

			// Go to next frame
			num += 1;
		}
	}

	// Play an animation
	public void Play(string name) {
		currentAnim = animations[name];
		currentSpeed = animationSpeeds[name];
	}
	
	// Update the anim8r
	public void Update () {
		if (currentAnim != null) {
			timer += Time.deltaTime * currentSpeed;
			spriteIndex = (int) Mathf.Floor(timer/16) % currentAnim.Count;
			spriteRenderer.sprite = currentAnim[spriteIndex];
		}
	}
}
