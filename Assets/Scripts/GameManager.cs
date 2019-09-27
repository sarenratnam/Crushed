using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public GameObject m_StartPanel;
    public GameObject m_RestartPanel;
    
    private int m_health; 
    private int m_kills;

    private bool m_Activate = true; 

    // Singleton Pattern (only ONE GameManager can exist in the game)
    // This pattern allow you to call the GameManager from anywhere 
    // with GameManager.Instance.MethodName(); (See Enemy / HUDManager and TowerController)
    private static GameManager m_instance; 
	public static GameManager Instance { get { return m_instance; } }

	public void Awake() {

		if(m_instance != this && m_instance != null) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
        
        

    }
    // End of Singleton Pattern
    

    void Start()
    {
        Restart(); // pro-tip control it all through the Restart method which is accessible anytime

        Time.timeScale = 0;

        m_Activate = true;
        m_StartPanel.gameObject.SetActive(m_Activate);
    }

    public void Restart()
    {
        m_health = 10;
        m_kills = 0;

        Time.timeScale = 1;

        if (m_Activate == true)
        {
            m_Activate = false;
        }
        m_StartPanel.gameObject.SetActive(m_Activate);
        m_RestartPanel.gameObject.SetActive(m_Activate);
    }
    



    public void ReLoadTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        // Restart(); 
        // The above isn't the best way to "start over" it works now, while there are no menus but I fear
        // it's sending you down the wrong path. 

        // If you update your SpawnControl to use object pooling, the controller can keep tabs on which enemies 
        // it owns and a Reset() in the spawnner could clear all the existing enemies ... a Pause() and Resume() 
        // could make it more robust and let you build in rounds or waves ... 

        // adding an enum for different types of enemies with different hit values is a simple addition, I rewrote 
        // the way you take damage on the tower so you can hit it harder if you wanted (1). 

        // giving the enemies "health" requiring a number of taps would be fun too ... You could even add a 
        // health bar above the enemy heads or the tower(s) like in Starcraft II - See https://i.imgur.com/rZ8CrHr.jpg 


    }

    public void Quite()
    {
        Application.Quit();
    }

   
    void Update() {
        if(m_health <= 0)
        { // Game Over 
            //ReLoadTheScene();
            Time.timeScale = 0;
            m_RestartPanel.gameObject.SetActive(true);
        }

        
    }


    public int GetHealth() {
        return m_health;
    }

    public int GetKills() {
        return m_kills;
    }

    public void TakeDamage(int damage){
        m_health -= damage;     // apply the damage passed in (scales for bigger enemies)

        if(m_health < 0) {
            m_health = 0;       // if the damage took us blow 0, just put it back to 0
        }
    }

    public void ClaimSoul() {
        m_kills++;
    }


}
