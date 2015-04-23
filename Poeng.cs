using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Poeng : MonoBehaviour
{
    // gui referanse
    public Text poengTekst;

    // Use this for initialization
    void Start()
    {
        // setter poeng text
        poengTekst.text = GameManager.instance.antallPoeng.ToString();
		Debug.Log (GameManager.instance.antallPenger);
    }

    public void leggTilPoeng(int add)
    {
        // legger til verdi som kommer in som parameter
        GameManager.instance.antallPoeng += add;

        // setter poeng text
        poengTekst.text = GameManager.instance.antallPoeng.ToString();
    }
}
