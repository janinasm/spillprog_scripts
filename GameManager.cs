using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // verdier som blir brukt og forandret i flere script
    // verdier 
    public int runde;
    public float nedteller;
    public float resetNedteller;
    public bool erForberedelsesFase = false;
    public int antallPenger = 600;
    public int antallPoeng = 0;
	public string sprak = "Engelsk";
	public int startpenger = 600;
	public string playerName;
	public Text player;

    // lister

    // prefabs
    public GameObject fiende;
	public GameObject fiende2;
	public GameObject fiende3;

    // referanser
    public Penger penger;
    public Poeng poeng;

	//Til lagrin
	public Transform fiendeholder;
	public Transform forsvarelementholder;

	//Har startetspillet
	public bool gameHasStarted = false;

	//For å resette spillet
	private Kampfase kampfase;
	private FasebytteGraphics fasebyttegraphics;
	private CameraSwitching cameraSwitch;
	private MenuGui menuGui;
	public GameObject village;
	private GameOver gameOver;


    void Awake()
    {	
		antallPenger = startpenger;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        runde =30;
        nedteller = 30f;
        resetNedteller = 10f;

		fasebyttegraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics>();
		kampfase = GetComponent<Kampfase> ();
		cameraSwitch = GetComponent<CameraSwitching> ();
		menuGui = GetComponent<MenuGui> ();
		gameOver = GameObject.Find ("gameController").GetComponent<GameOver>();
    }

    void Start()
    {
        penger = GetComponent<Penger>();
        poeng = GetComponent<Poeng>();
    }


	public void StartNewGame(string player){

		erForberedelsesFase = true;
		gameHasStarted = true;
		playerName = player;
		ResetSpill ();
	}

	public void ResetSpill(){
		if (fasebyttegraphics.getErDag()) {
		}else{
			fasebyttegraphics.byttFase();
		}
		kampfase.slettAlleFiender();
		fjernForsvarsElementer ();
		antallPoeng = 0;
		antallPenger = 600;
		player.text = playerName;
		nedteller = resetNedteller;

		if (menuGui.pause) {
			menuGui.PauseGame();
		}
		village.GetComponent<Landsby> ().Awake ();
		gameOver.erGameOver = false;
		village.GetComponent<LandsbyHelse> ().isGameOver = false;
	}

	public void fjernForsvarsElementer(){
		// henter antall fiender i fiendeholderen
		int childs = forsvarelementholder.childCount;
		
		// sletter fiendene
		for (int i = 0; i < childs; i++)
		{
			GameObject.Destroy(forsvarelementholder.GetChild(i).gameObject);
		}
	}


}
