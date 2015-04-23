using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Landsby : MonoBehaviour
{
	public int oppgraderingKostnad = 1000;
	public int level = 1;
    public float helse;
	public float reparerTilHelse;

	public void Awake ()
    {
        helse = 1000f;
		reparerTilHelse = helse;
    }
}
