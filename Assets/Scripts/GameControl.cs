using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public TowerControl m_TowerScript;
	public Enemy m_EnemyScript;
	public int m_Damage;
	// private bool m_GameOver = false;
	
	public int m_Kill;
	// public Text m_MoneyText;
	
	void Start () 
	{
		ResetKills();
		
		
	}
	
	
	void Update () 
	{
	 	
		m_Damage = m_TowerScript.m_Life;

		
		if (m_Damage == 0)
		{
			ResetKills();
			Restart();
			Debug.Log("Restart");
			
			
		}

		
		
		
	}




	void Restart ()
	{
	
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}

	void ResetKills()
	{
		m_Kill = 0;
	}
}

