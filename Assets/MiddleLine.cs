using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLine : MonoBehaviour
{
    public GameObject Puck;
    public GameObject Player;
    public GameObject Ai;

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
      /*if (Puck == true)
        {
            Debug.Log("Collision");
        }

        if (LayerMask != Player)
        {

        }*/
    }
}
