using UnityEngine;
using System.Collections;

public class OppgraderForsvarselement : MonoBehaviour
{	
	// gameobject referanser
	public GameObject detectionArea;
    private int maxLevel = 4;
    private int oppgraderingKostnad;
    private Vector3 nyStorrelse;

	//referanser til originalstørrelse
	private float rangeScaleX;
	private float rangeScalez;
	
    // script referanser
    private Forsvarselement forsvarselement;

    void Start()
    {
        // cacher referanser
        forsvarselement = GetComponent<Forsvarselement>();
    }

    public void oppgrader()
    {
        // finner oppgraderingkostnad basert på level
        oppgraderingKostnad = forsvarselement.oppgraderingKostnad * forsvarselement.level;

        // hvis level er mindre enn maxlevel og det er nok penger til å oppgradere
        if (forsvarselement.level < maxLevel && oppgraderingKostnad <= GameManager.instance.antallPenger)
        {
            // øker level med 1
            forsvarselement.level++;

            // sjekker level og gjør ting basert på det
            // lot det være en switch her tilfelle levels skal ha unike karakteristikker
            switch (forsvarselement.level)
            {
                case 2:
				//Henter nåværende størrelse;
				Vector3 SwAndRange = detectionArea.transform.localScale;
				// lager ny størrelse til skyterange-gameobjekt
				SwAndRange.x = (detectionArea.transform.localScale.x *1.5f);
				SwAndRange.z = (detectionArea.transform.localScale.z *1.1f);
				detectionArea.transform.localScale = SwAndRange;
				// sender med nye verdier til metode som oppgraderer verdiene
				oppgraderVerdier( oppgraderingKostnad);
				break;
				
			case 3:
				//Henter nåværende størrelse;
				Vector3 SwAndRange2 = detectionArea.transform.localScale;
				// lager ny størrelse til skyterange-gameobjekt
				SwAndRange2.x = (detectionArea.transform.localScale.x *1.8f);
				SwAndRange2.z = (detectionArea.transform.localScale.z *1.15f);
				detectionArea.transform.localScale = SwAndRange2;
				// sender med nye verdier til metode som oppgraderer verdiene
				oppgraderVerdier( oppgraderingKostnad);
				break;
				
			case 4:
				//Henter nåværende størrelse;
				Vector3 SwAndRange3 = detectionArea.transform.localScale;
				// lager ny størrelse til skyterange-gameobjekt
				SwAndRange3.x = (detectionArea.transform.localScale.x *1.6f);
				SwAndRange3.z = (detectionArea.transform.localScale.z *1.2f);
				detectionArea.transform.localScale = SwAndRange3;
				// sender med nye verdier til metode som oppgraderer verdiene
				oppgraderVerdier( oppgraderingKostnad);
				
				break;
			}
		}
		
		else
		{
			// TODO gi feilmeldinger til spilleren
        }
    }

    public void oppgraderVerdier(int oPris)
    {
        // øker statistikk verdier
        forsvarselement.skade *= 1.5f;
        forsvarselement.helse *= 1.5f;

        // gir skyterange-gameobject ny størrelse

        // fjerner oppgraderingskostnad fra penger
        GameManager.instance.penger.fjernPenger(oPris);
    }
}
