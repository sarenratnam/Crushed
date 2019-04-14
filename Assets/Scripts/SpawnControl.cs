using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour 

{
	public Transform [] m_spawnPoint;
	public GameObject [] m_enemy;
	public static bool m_spawnAllowed;
	int m_randomSpawnPoint, m_randomEnemy;
	
	void Start () 
	{
		m_spawnAllowed = true;
		InvokeRepeating ("SpawnEnemy", 0f, 1f);
	}
	


	void SpawnEnemy () 
	{
		if (m_spawnAllowed)
		{
			m_randomSpawnPoint = Random.Range (0, m_spawnPoint.Length);
			m_randomEnemy = Random.Range (0, m_enemy.Length);
			// m_randomSpawnPoint = m_spawnPoint.Length;
			// m_randomEnemy = m_enemy.Length;
			Instantiate (m_enemy [m_randomEnemy], m_spawnPoint [m_randomSpawnPoint].position, Quaternion.identity);
		}
	}
}
