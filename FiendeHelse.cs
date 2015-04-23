using UnityEngine;
using System.Collections;

public class FiendeHelse : MonoBehaviour
{
    // script referanser
    private Fiende fiende;
	private Kampfase kampfase;

    void Start()
    {
        // cacher referanser
        fiende = GetComponent<Fiende>();
		kampfase = GameObject.Find ("ScriptHolder").GetComponent<Kampfase> ();
    }

    public void taSkade(float skadeInn)
    {
        // trekker skaden fra HP
        fiende.helse -= skadeInn;
        // sjekker om HP er lik eller større enn 0
        if (fiende.helse <= 0)
        {
			StartCoroutine("FiendeDie");
        }
    }
	public IEnumerator FiendeDie()
    {
		// legger til poeng
		GameManager.instance.poeng.SendMessage("leggTilPoeng", fiende.poengVerdi);
		
		// legger til penger
		GameManager.instance.penger.SendMessage("leggTilPenger", fiende.poengVerdi);
        // sletter gameobjektet
		kampfase.DreptFiende ();
		yield return new WaitForSeconds (1);
        Destroy(transform.gameObject);

   
    }
}
