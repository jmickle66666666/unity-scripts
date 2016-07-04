using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperCollider : MonoBehaviour {

	public float width;
	public float height;
	public string type;
	public const float minimumDistance = .01f;
	private static List<SuperCollider> colliders;

	void Start () {
		// Initialize list of colliders if not done already
		InitializeList();

		// Add this collider to the master list
		colliders.Add(this);
	}

	void OnDestroy() {
		// When the object is removed from the scene, remove the collider from the master list
		colliders.Remove(this);
	}

	// Main collision check
	public GameObject collides (SuperCollider collider, float x, float y, float width, float height) {
		if (x + width/2 > collider.transform.position.x - collider.width/2 &&
			y + height/2 > collider.transform.position.y - collider.height/2 &&
			x - width/2 <= collider.transform.position.x + collider.width/2 &&
			y - height/2 <= collider.transform.position.y + collider.height/2) {
			return collider.gameObject;
		}
		return null;
	}

	// Check collision with specific type, at specific position.
	public GameObject collideWithAt (string collideType, float x, float y) {
		foreach (SuperCollider collider in colliders) {
			if (collider != this && collider.type == collideType) {
				if (collides(collider,x,y,width,height)) {
					return collider.gameObject;
				}
			}
		}
		return null;
	}

	// Check collision with specific type, at current position
	public GameObject collideWith (string collideType) {
		foreach (SuperCollider collider in colliders) {
			if (collider != this && collider.type == collideType) {
				if (collides(collider,transform.position.x,transform.position.y,width,height)) return collider.gameObject;
			}
		}
		return null;
	}

	// Check collision with anything else at specific position
	public GameObject collideAt (float x, float y) {
		foreach (SuperCollider collider in colliders) {
			if (collider != this) {
				if (collides(collider,x,y,width,height)) {
					return collider.gameObject;
				}
			}
		}
		return null;
	} 

	// Create the master list of colliders if it doesn't exist already
	void InitializeList () {
		if (colliders == null) colliders = new List<SuperCollider>();
	}
}
