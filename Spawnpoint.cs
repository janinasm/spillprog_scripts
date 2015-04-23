using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {

	public GameObject flamme;
	public GameObject varselLys;
	public GameObject spawnpoint;

	private GameObject fiendeHolder;

	void Awake(){
		fiendeHolder = GameObject.Find ("FiendeHolder");
	}

	public void stengAv(){
		flamme.SetActive(false);
		varselLys.SetActive(false);
	}

	public void tennLys(){
		flamme.SetActive(true);
		varselLys.SetActive(true);
	}

	public void SpawnFiende(GameObject fiende){
		Debug.Log ("Prøver å spawne i spawnpoint");
		//Lager et game objekt som skal instansieres
		GameObject fiendeInstance;
		
		// instantiater (spawner) fiende på plasseringen til spawnpoint fra listen med tilfeldige spawnpoints
		fiendeInstance = Instantiate(fiende, spawnpoint.transform.position, Quaternion.identity) as GameObject;
		
		// legger de i et annet gameobject (for orden i hierarkiet)
		fiendeInstance.transform.parent = fiendeHolder.transform;
	}
}
