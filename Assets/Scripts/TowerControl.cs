using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour {

	public GameObject m_DestroyObject;
	public int m_Life = 2;
	
	//_________________________________________

	public void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.tag == "Enemy")
		Destroy(other.gameObject);

		m_Life -= 1;
		
	}

	

}
