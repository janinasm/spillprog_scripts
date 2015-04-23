using System.Collections.Generic;
using UnityEngine;

public class FaseSkifte : MonoBehaviour
{
    public List<GameObject> fienderListe = new List<GameObject>();

    // script referanser
    private Forberedelsesfase forberedelsesfase;
    private Kampfase kampfase;
    private FaseGUI faseGUI;
	private FasebytteGraphics fasebyttegraphics;
	private AudioManager audioManager;

	void Awake(){
		fasebyttegraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
		audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
	}

    void Start()
    {
        // cacher referanser
        forberedelsesfase = GetComponent<Forberedelsesfase>();
        kampfase = GetComponent<Kampfase>();
        faseGUI = GetComponent<FaseGUI>();

        // setter GUI
        faseGUI.faseText.text = "Forberedelsesfase";
    

        // starter spillet i forberedelsesfasen
        GameManager.instance.erForberedelsesFase = true;
        forberedelsesfase.startForberedelsesFase();

    }

    void Update()
    {
		if (GameManager.instance.gameHasStarted) {
			// teller ned til 0 hvis det er forberedelsesfase
			if (GameManager.instance.nedteller >= 0f && GameManager.instance.erForberedelsesFase) {
				GameManager.instance.nedteller -= Time.deltaTime;

				// oppdaterer nedtelleren i heltall
				faseGUI.nedtellerText.text = GameManager.instance.nedteller.ToString ("F0");
			}
			//Starter grafikkendringen til natt
			if (GameManager.instance.nedteller <= 5f && GameManager.instance.nedteller > 4f) {
				fasebyttegraphics.byttFase ();

			}
			// 
			if (GameManager.instance.nedteller <= 0f && GameManager.instance.erForberedelsesFase) {
				GameManager.instance.erForberedelsesFase = false;

				SkiftFase (GameManager.instance.erForberedelsesFase);
			}
		}

    }

    public void SkiftFase(bool b)
    {
        if (b)
        {
            forberedelsesfase.startForberedelsesFase();
			audioManager.TilDagAudio();
			fasebyttegraphics.byttFase();
            GameManager.instance.erForberedelsesFase = true;
            faseGUI.faseText.text = "Forberedelsesfase";
        }
        else
        {
            kampfase.startKampfase();
			audioManager.TilNatAudio();
            faseGUI.faseText.text = "Kampfase";
        }
    }

}
