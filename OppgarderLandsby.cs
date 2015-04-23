using UnityEngine;
using System.Collections;

public class OppgarderLandsby : MonoBehaviour {

	// gameobject referanser
	public GameObject detectionArea;
	private int maxLevel = 4;
	private int oppgraderingKostnad;
	private float nyMaksHelse;
	
	// script referanser
	private Landsby landsby;
	
	void Start()
	{
		// cacher referanser
		landsby = GetComponent<Landsby>();
	}
	
	public void oppgrader()
	{
		// finner oppgraderingkostnad basert på level
		oppgraderingKostnad = landsby.oppgraderingKostnad * landsby.level;
		
		// hvis level er mindre enn maxlevel og det er nok penger til å oppgradere
		if (landsby.level < maxLevel && oppgraderingKostnad <= GameManager.instance.antallPenger)
		{
			// øker level med 1
			landsby.level++;
			
			// sjekker level og gjør ting basert på det
			// lot det være en switch her tilfelle levels skal ha unike karakteristikker
			switch (landsby.level)
			{
			case 2:
				nyMaksHelse = landsby.reparerTilHelse *1.3f;
				landsby.reparerTilHelse = nyMaksHelse;
				landsby.helse *=1.3f;
				// sender med nye verdier til metode som oppgraderer verdiene
				GameManager.instance.penger.fjernPenger( oppgraderingKostnad);
				break;
				
			case 3:
				nyMaksHelse = landsby.reparerTilHelse *1.45f;
				landsby.reparerTilHelse = nyMaksHelse;
				landsby.helse *=1.3f;
				// sender med nye verdier til metode som oppgraderer verdiene
				GameManager.instance.penger.fjernPenger( oppgraderingKostnad);
				break;
				
			case 4:
				nyMaksHelse = landsby.reparerTilHelse *1.60f;
				landsby.reparerTilHelse = nyMaksHelse;
				landsby.helse *=1.3f;
				// sender med nye verdier til metode som oppgraderer verdiene
				GameManager.instance.penger.fjernPenger( oppgraderingKostnad);
				
				break;
			}
		}
		
		else
		{
			// TODO gi feilmeldinger til spilleren
		}

	}
}
