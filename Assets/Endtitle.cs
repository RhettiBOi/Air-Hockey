using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endtitle : MonoBehaviour
{
    public Scorecode logic;
    public bool playerwins;

    [SerializeField] private GameObject playerPuck;
    [SerializeField] private GameObject aipuck;
    [SerializeField] private GameObject puck;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Truebutton;

    public GameObject Loserscreen;
    public GameObject Winnerscreen;

    private void Start()
    {
        Loserscreen.SetActive(false);
        Winnerscreen.SetActive(false);
    }

    //public void Aiwin()
    //{

    //}
    private void Update()
    {
        if (logic != null && logic.playscr == 5)
        {
            Time.timeScale = 0f;
            playerwins = true;

            playerPuck.SetActive(false);
            aipuck.SetActive(false);
            puck.SetActive(false);
            if (playerwins)
            {
                //Debug.Log("player wins");
                winscreen();
                Button.SetActive(true);
                Truebutton.SetActive(true);
            }

        }
        else
        if (logic != null && logic.aiscr == 5)
        {
            Time.timeScale = 0f;
            playerwins = false;

            playerPuck.SetActive(false);
            aipuck.SetActive(false);
            puck.SetActive(false);

            if (playerwins == false)
            {
                //Debug.Log("AI wins");
                LoseScreen();
                Button.SetActive(true);
                Truebutton.SetActive(true);
            }
        }
    }
    //IEnumerator ResetSceneAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    // Reset the scene
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void LoseScreen()
    {
        Loserscreen.SetActive(true);
    }
    public void winscreen()
    {
        Winnerscreen.SetActive(true);
    }
}


