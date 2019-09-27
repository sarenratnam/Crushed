using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    private float m_timeBtwSpawns;
    public float m_startTimeBtwSpawns;
    public GameObject m_trail;

   
    void Update()
    {
        if(m_timeBtwSpawns <= 0)
        {
           GameObject instace = (GameObject)Instantiate(m_trail, transform.position, Quaternion.identity);
            Destroy(instace, 8f);
           m_timeBtwSpawns = m_startTimeBtwSpawns;
         
        }
        else
        {
            m_timeBtwSpawns -= Time.deltaTime;
        }
    }
}
