using UnityEngine;
using System.Collections;

public class ForsvarselementHelse : MonoBehaviour
{
    // script referanser
    private Forsvarselement forsvarselement;


    void Start()
    {
        // cache
        forsvarselement = GetComponentInParent<Forsvarselement>();

    }

    public void taSkade(int skadeInn)
    {
        // trekker skaden fra HP
        forsvarselement.helse -= skadeInn;
        // sjekker om HP er lik eller større enn 0
        if (forsvarselement.helse <= 0)
        {
			StartCoroutine("Die");
        }
    }

	public IEnumerator Die()
    {
		transform.Translate (Vector3.up * 10000);
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
     }
}
