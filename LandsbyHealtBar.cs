using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LandsbyHealtBar : MonoBehaviour {

	public Slider heltbar;
	private float health;
	private Landsby landsby;
	private float starthealth;
	public Image healthimage;
	public Sprite godHelse;
	public Sprite daarligHelse;
	public GameObject healthbar;
	public GameObject littDod;
	public GameObject veldignaredod;
	
	void Awake(){
		landsby= gameObject.GetComponentInParent<Landsby> ();

	}
	
	void Update (){
		//health = landsby.helse;

		float healtbarvalue = (landsby.helse/ landsby.reparerTilHelse)*100;
		heltbar.value = healtbarvalue;
		//Debug.Log ("HEaltbarStatus: " + healtbarvalue);
		if (healtbarvalue >= 100) {
			healthbar.SetActive (false);
		} else {
			healthbar.SetActive(true);
		}
		
		heltbar.value = healtbarvalue;
		if (healtbarvalue < 40) {
			healthimage.sprite = daarligHelse;
		} else {
			healthimage.sprite = godHelse;
		}

		if (healtbarvalue > 60) {
			littDod.SetActive(false);
			veldignaredod.SetActive(false);
		}
		else if (healtbarvalue < 60) {
			littDod.SetActive (true);
			if (healtbarvalue < 30) {
				veldignaredod.SetActive(true);
			}
		} 
	}
}
