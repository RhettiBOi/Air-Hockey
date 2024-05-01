using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject puck;
    [SerializeField]
    GameObject PLayer;
    [SerializeField]
    GameObject Ai;
    [SerializeField]
    GameObject Button;
    [SerializeField]
    private Text Playerscore;
    [SerializeField]
    private Text Aiscore;
    [SerializeField]
    GameObject buttonrestart;

    //[SerializeField] private Text timer1;
    [SerializeField] private int scoreplayer;
    [SerializeField] private int scoreai;

    [SerializeField] private float CurrentTime = 0f;
    [SerializeField] private float StartTime = 5f;
    [SerializeField] private Text Count;
    [SerializeField] private GameObject timer;
    //[SerializeField] private Rigidbody2D rb;
    [SerializeField] GameObject Reset;
    //[SerializeField] private bool timerstarted = false;

    private Coroutine timerCoroutine;

    void Start()
    {
        scoreplayer = 0;
        scoreai = 0;
        puck.SetActive(false);
        PLayer.SetActive(false);
        Ai.SetActive(false);
        Button.SetActive(true);
        buttonrestart.SetActive(false);
        timer.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void buttonclick()
    {
        Button.SetActive(false);
        Debug.Log("BUtton is clicked");

        if (timerCoroutine != null )
        {
            StopCoroutine("StartTimerCoroutine");
        }
        StartCoroutine(StartTimerCorountine());
        //timer.SetActive(true)
    }

    private IEnumerator StartTimerCorountine()
    {
        timer.SetActive(true);
        CurrentTime = StartTime;
       

        while (CurrentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            CurrentTime -= 1f;
            Count.text = CurrentTime.ToString("0");
        }

        timer.SetActive(false);
        puck.SetActive(true );
        PLayer.SetActive(true );
        Ai.SetActive(true); 
        Playerscore.text = scoreplayer.ToString();
        Aiscore.text = scoreai.ToString();

        Time.timeScale= 1f;

    }

    public void Gamerestart()
    {


        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);


    }
}
