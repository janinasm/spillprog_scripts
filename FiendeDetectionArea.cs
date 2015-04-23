using UnityEngine;
using System.Collections;

public class FiendeDetectionArea : MonoBehaviour {

	private GameObject target;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "forsvarselement") {
		
		}
	}
}
