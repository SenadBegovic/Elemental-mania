using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private EffectiveHealth player1;
    [SerializeField]
    private EffectiveHealth player2;
    [SerializeField]
    private Text text;


    GameObject[] playerOne, playerTwo, finishObjects;

    // Use this for initialization
    void Start()
    {
        //text = GetComponent<Text>();

        playerOne = GameObject.FindGameObjectsWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectsWithTag("PlayerTwo");
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        hideFinished();

    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (player1.CurrentHealth <= 0)
            {
                foreach (GameObject g in playerOne)
                {
                    g.SetActive(false);
                }

                Time.timeScale = 0;
                WinScreen("Player 2");
            }

            if (player2.CurrentHealth <= 0)
            {
                foreach (GameObject g in playerTwo)
                {
                    g.SetActive(false);
                }

                Time.timeScale = 0;
                WinScreen("Player 1");
            }
        }
    }

    public void WinScreen(string winner)
    {
        showFinished();
        text.text = string.Format("GAME OVER!\n{0} WINS!", winner);
    }

    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    public void Reload()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadLevel(string level)
    { 
        Application.LoadLevel(level);
        Time.timeScale = 1;
    }
}
