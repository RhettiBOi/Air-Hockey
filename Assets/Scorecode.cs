using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorecode : MonoBehaviour
{
    public int playscr;
    public int aiscr;
    public Text playerscoretext;
    public Text Aiscoretext;


    [ContextMenu("Increase Score")]
    public void addscore()
    {
        playscr = playscr + 1;
        playerscoretext.text = playscr.ToString();
    }

    public void Aiaddscore()
    {
        aiscr = aiscr + 1;
        Aiscoretext.text = aiscr.ToString();
    }
}
