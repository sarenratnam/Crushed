using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour {
    
    public GameManager m_gm;
    public Text m_MoneyAmount;  // Essentially the kills
	public Text m_LifeAmount;   // The players health 
 
    void Update() {
        m_MoneyAmount.text = "$" + GameManager.Instance.GetKills().ToString();
		m_LifeAmount.text =  GameManager.Instance.GetHealth().ToString(); 
    }
}
