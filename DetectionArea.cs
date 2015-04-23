using UnityEngine;
using System.Collections;

public class DetectionArea : MonoBehaviour {
	private Transform target;
	private ForsvarselementAngrep forsvarangrepScript;
	// Use this for initialization

	//Finner skripet i hirarkiet
	void Awake (){
		forsvarangrepScript = GetComponentInParent<ForsvarselementAngrep> ();
	}

	//Kommer fienden inn i detectionsonen settes targett til fiendenden som har kommet inn.
	//Fiender er alle som har taggen Enemy
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Fiende") {
			target = other.gameObject.transform;
			forsvarangrepScript.Target(target);
		}
	}
	//Dersom fiendern forsvinner ut av detectionon sonen settes target til null
	void OnTriggerExit(Collider other){
		if (other.gameObject.transform == target) {
			target = null;
			forsvarangrepScript.Target(target);
		}
	}
	
}
