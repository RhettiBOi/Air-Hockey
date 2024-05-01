using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimertoStart : MonoBehaviour
{
    [SerializeField] private float CurrentTime = 0f;
    [SerializeField] private float StartTime = 5f;
    [SerializeField] private Text Count;
    [SerializeField] private GameObject timer;
   // [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        Count.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            timer.SetActive(false);
        }
    }
}
