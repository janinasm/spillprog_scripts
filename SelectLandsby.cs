using UnityEngine;
using System.Collections;

public class SelectLandsby : MonoBehaviour {

	public bool erValgt;
	public GameObject feCanvas;
	private float buttonOffset = 20f;
	private float buttonWidth = 80f;
	
	// script referanser
	private GameObject scriptHolder;
	private ForsvarselementPlacement forsvarselementPlacementScript;
	private MeshRenderer detectAreaMesh;

	void Start()
	{
		// cacher referansr
		scriptHolder = GameObject.Find("ScriptHolder");
	}
	
	public void settSomValgt(bool v)
	{
		if (v) {
			erValgt = v;
			detectAreaMesh.enabled = true;
			//feCanvas.SetActive (true);
		} else {
			erValgt = v;
			detectAreaMesh.enabled = false;
			//feCanvas.SetActive (false);
			
		}
		
		
	}
	//Gammel Gui kode
	
	void OnGUI()
	{
		if (erValgt && GameManager.instance.erForberedelsesFase)
		{
			
			
			
			
			Vector2 targetPos;
			targetPos = Camera.main.WorldToScreenPoint(transform.position);
			
			if (GUI.Button(new Rect(targetPos.x + buttonOffset, Screen.height - targetPos.y + buttonOffset, buttonWidth, 30), "Flytt"))
			{
				Debug.Log("Flytt " + name);
				
				scriptHolder.GetComponent<ForsvarselementPlacement>().holdtForsvarselement = this.transform;
				scriptHolder.GetComponent<ForsvarselementPlacement>().erPlassert = false;
				
			}
			
			if (GUI.Button(new Rect(targetPos.x + buttonOffset + (buttonWidth * 1), Screen.height - targetPos.y + buttonOffset, buttonWidth, 30), "Oppgrader"))
			{
				Debug.Log("Oppgrader");
				
				GetComponent<OppgraderForsvarselement>().oppgrader();
				
			}
			
			if (GUI.Button(new Rect(targetPos.x + buttonOffset + (buttonWidth * 2), Screen.height - targetPos.y + buttonOffset, buttonWidth, 30), "Selg"))
			{
				Debug.Log("Selg");
				
				GetComponent<SlettForsvarselement>().Selg();
			}
		}
	} 
}
