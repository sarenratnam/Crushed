using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {	

	public Animator m_Anim;
	private Camera m_cam;
	Rigidbody2D m_RB;
	//______Enemy's Animation and Raycasting______

	public Transform m_target;
	public float m_speed = 1f;
	private float m_minDistance = 0f;
	private float m_range; 
	//______Enemy's speed and targeting_____

	private int m_Value = 1;
	// public GameControl m_GameControlScript;
	// public ScoreManager m_ScoreManagerScript;
	//________Script Refference__________
	
	
	void Start () {
		
		m_Anim = gameObject.GetComponent<Animator>();
		m_cam = Camera.main;
		m_RB = GetComponent <Rigidbody2D>();

	}

	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider.gameObject == this.gameObject) {
					
				m_Anim.SetTrigger("Dead");
				m_speed = 0f;
				GameManager.Instance.ClaimSoul();
				Object.Destroy(gameObject, 4.0f);
                this.GetComponent<Collider2D>().enabled = false;
				

				// m_GameControlScript.m_Kill += 1;
			}	
		}
		
		//______Mouse click detect and Raycasting______
		
		m_range = Vector2.Distance(transform.position, m_target.position);	
		if (m_range > m_minDistance) {
			//Debug.Log(m_range);
			transform.position = Vector2.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
		}
		
		//______Enemy moveing towards Tower______
		Vector3 m_playerPos = transform.position;
		m_Anim.SetFloat("MoveX", transform.position.y);
		m_Anim.SetFloat("MoveY", transform.position.x);
	}

}

