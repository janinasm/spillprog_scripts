using UnityEngine;
using System.Collections;

public class okseSkript : MonoBehaviour {

	private int skade;
	private float tidmellomAngrep = 0;
	private Fiende fiende;
	public AudioClip oks;
	private AudioSource source;
	


	void Awake(){
		fiende = GetComponentInParent<Fiende> ();
		skade = fiende.skade;
		tidmellomAngrep = fiende.tidMellomAngrip;
		source = GetComponent<AudioSource> ();
	}

	// kjører når øksa kolliderer med gameobject
	void OnTriggerEnter(Collider other)
	{

		if (tidmellomAngrep > 0) {
			tidmellomAngrep -= Time.time;
		} else {
		
			// hvis Øksa kolliderer med Landsby eller Forsvarselement
			if (other.gameObject.tag == "Forsvarselement") {		
				// kjører metode til gameobject for skade tatt
				other.GetComponentInParent<ForsvarselementHelse> ().taSkade (skade);
				source.PlayOneShot(oks);
				tidmellomAngrep = fiende.tidMellomAngrip;
			}else if (other.gameObject.tag == "Landsby") {		
				// kjører metode til gameobject for skade tatt
				other.GetComponentInParent<LandsbyHelse> ().taSkade (skade);
				source.PlayOneShot(oks);
				tidmellomAngrep = fiende.tidMellomAngrip;
				Debug.Log("Prover å ta liv");
			}
		}
	}
}
