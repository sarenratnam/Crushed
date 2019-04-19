using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour {

	// This script is attached to the tower. 
	public GameObject m_DestroyObject;
	
	void Start(){
		
	}


	public void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			GameManager.Instance.TakeDamage(1); 	// i'm using 1 here but this could easily scale to different "enemys" and damage
			Destroy(other.gameObject);				// this script just updates the GameManager that it took damage and how much
		}											// and then destroys the enemy from the scene
	}

}
