using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForsvarselementManager : MonoBehaviour
{
    // basert på kode fra https://www.youtube.com/watch?v=OuqThz4Zc9c
    // 
	private TextBoxRefrence tb;


    // gameobject referanser
    public GameObject archerTower;
	public GameObject kanonTaarn;
	public GameObject roadBlock;

	public int prisArcherTower = 300;
	public int prisKanonTower = 500;
	public int prisRoadblock = 100;

    // script referanser
    private ForsvarselementPlacement forsvarselementPlacement;

	void Awake(){
		tb = GameObject.Find ("LanguageManager").GetComponent<TextBoxRefrence> ();
		tb.archerTowerCost.text = prisArcherTower.ToString ();
		tb.canontTowerCost.text = prisKanonTower.ToString ();
		tb.roadblockCost.text = prisRoadblock.ToString ();
	}

    void Start()
    {
        // cacher referanser
        forsvarselementPlacement = GetComponent<ForsvarselementPlacement>();

        // setter gui text
       // slotForsvarselement1KnappText.text = "";
    }

    // actionbarslot 1
    public void archerTowerbtn()
    {
        // kjører metoden for å lage nytt forsvarselement
        // tar imot prisen og type forsvarselement som parameter
        lagForsvarslement(prisArcherTower, archerTower);
    }

    // actionbarslot 2
    public void kanonTowerBtn()
    {
        // kjører metoden for å lage nytt forsvarselement
        // tar imot prisen og type forsvarselement som parameter
		//Debug.Log ("Prøver å lage kanon");
        lagForsvarslement(prisKanonTower, kanonTaarn);
    }

	public void roadBlockBtn()
	{
		// kjører metoden for å lage nytt forsvarselement
		// tar imot prisen og type forsvarselement som parameter
		lagForsvarslement(prisRoadblock, roadBlock);
	}
	
	public void lagForsvarslement(int pris, GameObject go)
    {
        // hvis det er forberedelsesfase og det er nok penger
       if (GameManager.instance.erForberedelsesFase &&
            pris <= GameManager.instance.antallPenger)
       {
            // kjører metode i script for instansiating og plassering av forsvarselement
            forsvarselementPlacement.SetItem(go);

            // kjører metode som fjerner prisen fra penger
            GameManager.instance.penger.fjernPenger(pris);
        }
    }
}

