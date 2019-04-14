using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCTRL : MonoBehaviour {

	// public Animator m_Anim;
	private Camera m_cam;
	// Rigidbody2D m_RB;
	public GameObject m_enemy;
	void Start () 
	{
		m_cam = Camera.main;
		// m_Anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))

			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

				//if (hit.collider != null)
				if(hit.collider.gameObject == m_enemy)
				
				{
					Debug.Log(hit.collider.gameObject.name);
					// m_Anim.SetTrigger("Dead");
					// m_speed = 0f;
					// Object.Destroy(gameObject, 4.0f);
				}

			
				
					
				
			}
	}
}
