using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Forberedelsesfase : MonoBehaviour
{
    // script referanser
    private FaseGUI faseGUI;
	private SpawnpointManager spawnManager;

    // Use this for initialization
    void Start()
    {
        // cacher referanser
        faseGUI = GetComponent<FaseGUI>();
		spawnManager = GameObject.Find ("Spawnpoints").GetComponent<SpawnpointManager> ();
    }

    public void startForberedelsesFase()
    {
        // resetter nedtelleren
        GameManager.instance.nedteller = GameManager.instance.resetNedteller;

        // øker runde med 1
        GameManager.instance.runde++;

        // setter fase og runde tekst
        faseGUI.faseText.text = "Forberedelsesfase";
        faseGUI.rundeText.text = "# " + GameManager.instance.runde.ToString()+" ";

        // aktiverer gameobjektet som har GUI som kan brukes i denne fasen
        faseGUI.slotContainer.SetActive(true);
		faseGUI.faseTimer.SetActive (true);
		faseGUI.fiendeTeller.SetActive (false);

		// kjører metode som viser lys der fiendene skal komme fra i kampfasen
		spawnManager.settSpawnpointLys();

    }
}
