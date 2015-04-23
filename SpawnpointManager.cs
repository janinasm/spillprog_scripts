using UnityEngine;
using System.Collections;

public class SpawnpointManager : MonoBehaviour {
	public GameObject spawnpoint1;
	public GameObject spawnpoint2;
	public GameObject spawnpoint3;
	public GameObject spawnpoint4;
	public GameObject spawnpoint5;
	public GameObject spawnpoint6;
	public GameObject spawnpoint7;
	public GameObject spawnpoint8;

	private int antallFienderPerWave;
	private int antallWave;
	private int antallFiender;
	private float ventMedGruppe;
	private float ventMedFiende;

	private GameManager gameManager;
	private Kampfase kampfase;
	private int level;

	private bool erForsteWave;

	private int antallSpawnpoints;

	public int antallfiender;

	void Awake(){
		gameManager = GameObject.Find ("ScriptHolder").GetComponent<GameManager> ();
		kampfase = GameObject.Find ("ScriptHolder").GetComponent<Kampfase> ();

		antallFienderPerWave = 3;
		antallWave = 1;
		antallFiender = 0;
		
		ventMedGruppe = 15f;
		ventMedFiende = 4f;
	}
	
	public void settSpawnpointLys(){
		level = gameManager.runde;
		if(level < 3){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 1;
		}
		else if(level>3 && level < 7){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 2;
		}else if(level>7 && level < 14){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 3;
		}else if(level>14 && level <20){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			spawnpoint4.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 4;
		}else if(level>20 && level <30){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			spawnpoint4.GetComponent<Spawnpoint>().tennLys();
			spawnpoint5.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 5;
		}else if(level>30 && level <45){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			spawnpoint4.GetComponent<Spawnpoint>().tennLys();
			spawnpoint5.GetComponent<Spawnpoint>().tennLys();
			spawnpoint6.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 6;
		}else if(level>45 && level <65){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			spawnpoint4.GetComponent<Spawnpoint>().tennLys();
			spawnpoint5.GetComponent<Spawnpoint>().tennLys();
			spawnpoint6.GetComponent<Spawnpoint>().tennLys();
			spawnpoint7.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 7;
		}else if(level>65){
			spawnpoint1.GetComponent<Spawnpoint>().tennLys();
			spawnpoint2.GetComponent<Spawnpoint>().tennLys();
			spawnpoint3.GetComponent<Spawnpoint>().tennLys();
			spawnpoint4.GetComponent<Spawnpoint>().tennLys();
			spawnpoint5.GetComponent<Spawnpoint>().tennLys();
			spawnpoint6.GetComponent<Spawnpoint>().tennLys();
			spawnpoint7.GetComponent<Spawnpoint>().tennLys();
			spawnpoint8.GetComponent<Spawnpoint>().tennLys();
			antallSpawnpoints = 8;
		}

	}


	public IEnumerator spawnFiender()
	{
		level = gameManager.runde;

		settSpawnpointLys ();
		// for antall runder som har gått skal det kjøres en egen for loop
		for (int i = 0; i < GameManager.instance.runde; i++)
		{
			// dersom det ikke er den første gruppen av fiender skal det ventes før neste gruppe
			if (!erForsteWave)
			{
				// venter med neste gruppe
				yield return new WaitForSeconds(ventMedGruppe);
				
			}
			// det er ikke lenger første wave av fiender
			erForsteWave = false;
			Debug.Log("Maks spawnpoint er: "+antallSpawnpoints);
			// det velges et eget spawnpoint for hver gruppe (wave) av fiender i per kampfase
			int randomSpawnpoint = Mathf.FloorToInt(Random.Range(1, antallSpawnpoints));
			Debug.Log("Random Spawnpoint er:" + randomSpawnpoint);
			// denne loopen kjøres for hver fiende vi har i en gruppe (wave)
			for (int j = 0; j < antallFienderPerWave; j++)
			{

				// venter med å lage neste fiende
				yield return new WaitForSeconds(ventMedFiende);
				//Finner ut hvilken type fiende som skal spawnes
				GameObject fiende = RandomFiende();

				//Sender videre til å behandle random data.
				SpawnFiende(randomSpawnpoint, fiende);
				// øker for hver fiende vi legger til
				kampfase.SettAntallFiender();
				
				// vi er i gang med spawning
				kampfase.ErIgangMedSpwaning (true);
			}
		
		// vi er ferdige med spawning
		kampfase.ErIgangMedSpwaning(false);
		}
	}

	void SpawnFiende(int i, GameObject fiende){
		int caseSwitch = i;
		switch (caseSwitch)
		{
		case 1: spawnpoint1.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 2: spawnpoint2.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 3: spawnpoint3.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 4: spawnpoint4.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 5: spawnpoint5.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 6: spawnpoint6.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 7: spawnpoint7.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		case 8: spawnpoint8.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		default: spawnpoint1.GetComponent<Spawnpoint>().SpawnFiende(fiende);
			break;
		}
	}

	private GameObject RandomFiende(){
		if (antallSpawnpoints <= 2) {
			return gameManager.fiende;
		} else if (antallSpawnpoints > 2 && antallSpawnpoints <= 4) {
			int rand = Random.Range (0, 2);
			if (rand < 1) {
				return gameManager.fiende;
			} else {
				return gameManager.fiende2;
			}
		} else {
			int rand = Random.Range(0,3);
			if(rand<1){
				return gameManager.fiende;
			}else if(rand>1&& rand<2){
				return gameManager.fiende2;
			}else{
				return gameManager.fiende3;
			}
		}
	}

	public void ErForsteFase(bool b){
		erForsteWave = b;
	}


}
