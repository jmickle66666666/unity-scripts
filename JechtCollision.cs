using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JechtCollision : MonoBehaviour {

	public float width;
	public float height;
	public string type;
	public const float minimumDistance = .01f;
	private static List<JechtCollision> colliders;

	// Use this for initialization
	void Start () {
		InitializeList();
		colliders.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		colliders.Remove(this);
	}

	public GameObject collides (JechtCollision collider, float x, float y, float width, float height) {
		if (x + width/2 > collider.transform.position.x - collider.width/2 &&
			y + height/2 > collider.transform.position.y - collider.height/2 &&
			x - width/2 <= collider.transform.position.x + collider.width/2 &&
			y - height/2 <= collider.transform.position.y + collider.height/2) {
			return collider.gameObject;
		}
		return null;
	}

	public GameObject collideAt (string collideType, float x, float y) {
		foreach (JechtCollision collider in colliders) {
			if (collider != this && collider.type == collideType) {
				if (collides(collider,x,y,width,height)) {
					return collider.gameObject;
				}
			}
		}
		return null;
	}

	public GameObject collideAt (string collideType) {
		foreach (JechtCollision collider in colliders) {
			if (collider != this && collider.type == collideType) {
				if (collides(collider,transform.position.x,transform.position.y,width,height)) return collider.gameObject;
			}
		}
		return null;
	}

	public GameObject collideAt (float x, float y) {
		foreach (JechtCollision collider in colliders) {
			if (collider != this) {
				if (collides(collider,x,y,width,height)) {
					return collider.gameObject;
				}
			}
		}
		return null;
	} 

	void InitializeList () {
		if (colliders == null) colliders = new List<JechtCollision>();
	}
}
