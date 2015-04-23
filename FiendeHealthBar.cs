using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FiendeHealthBar : MonoBehaviour {

	public Slider heltbar;
	private float health;
	private Fiende fiende;
	private float starthealth;
	public Image healthimage;
	public Sprite godHelse;
	public Sprite daarligHelse;
	public GameObject healthbar;

	void Awake(){
		fiende = gameObject.GetComponentInParent<Fiende> ();
		starthealth = fiende.helse;
	}

	void Update (){
		health = fiende.helse;
		float healtbarvalue = (health / starthealth)*100;

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
	}

}
