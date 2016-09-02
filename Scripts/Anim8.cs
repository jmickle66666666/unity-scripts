using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Anim8 {

	float timer = 0;
	string animationSet;
	List<Sprite> currentAnim;
	Dictionary<string, List<Sprite>> animations;
	Dictionary<string, float> animationSpeeds;
	SpriteRenderer spriteRenderer;
	int spriteIndex = 0;
	float currentSpeed;

	// Use this for initialization
	public Anim8(string animationSet, SpriteRenderer sr) {
		spriteRenderer = sr;
		this.animationSet = animationSet;
		animations = new Dictionary<string, List<Sprite>>();
		animationSpeeds = new Dictionary<string, float>();
	}

	public void Load(string name, float speed) {

		// Load all the frames for the 'name' animation
		Sprite frame = null;
		int num = 1;

		// Create the frame list for the new animation
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

	public void Play(string name) {
		currentAnim = animations[name];
		currentSpeed = animationSpeeds[name];
	}
	
	// Update is called once per frame
	public void Update () {
		if (currentAnim != null) {
			timer += Time.deltaTime * currentSpeed;
			spriteIndex = (int) Mathf.Floor(timer/16) % currentAnim.Count;
			spriteRenderer.sprite = currentAnim[spriteIndex];
		}
	}
}
