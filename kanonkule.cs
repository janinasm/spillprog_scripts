using UnityEngine;
using System.Collections;

public class kanonkule : MonoBehaviour {
	//Variabler for fart og rekkevidde
	private float fart = 1300;
	private float rekkevide = 1200;
	//For å se om prosjektilet har nådd sin mak rekkevidde.
	private float avstand;
	
	void Update () {
		//setter at porsjektilet skal bevege seg forover i gitt fart
		transform.Translate (Vector3.forward * Time.deltaTime * fart);
		//Fart ganger tid er av standen
		avstand += Time.deltaTime * fart;
		//Dersom avstanden blir lenger enn rekkevidden på pilen ødelegges den.
		if (avstand >= rekkevide) {
			Destroy(gameObject);
		}
	}
}
