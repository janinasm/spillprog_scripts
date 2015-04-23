using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	
	public Text finalscore;
	private MenuGui menugui;
	private FaseGUI fasegui;
	public bool erGameOver = false;
	
	void Awake(){
		menugui = GameObject.Find ("ScriptHolder").GetComponent<MenuGui> ();
		fasegui = GameObject.Find ("ScriptHolder").GetComponent<FaseGUI> ();
	}
	

	public void gameOverTime(){
		finalscore.text = GameManager.instance.antallPoeng.ToString();
		menugui.GameOver ();
		fasegui.slotContainer.SetActive (false);
		fasegui.fiendeTeller.SetActive (false);
		erGameOver = true;
	}

}
