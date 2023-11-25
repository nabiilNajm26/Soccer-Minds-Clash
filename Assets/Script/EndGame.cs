using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image flagLeft, flagRight;
    public TMP_Text nameLeft, nameRight;
    public TMP_Text score, matchResult;


    // Start is called before the first frame update
    void Start()
    {
        flagLeft.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        flagRight.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        nameLeft.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        nameRight.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        score.SetText(GameController.number_GoalsLeft + "-" + GameController.number_GoalsRight);

        if(GameController.number_GoalsRight > GameController.number_GoalsLeft)
        {
            matchResult.SetText("You Lose");
        }
        else
        {
            matchResult.SetText("You Win");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHome()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonRematch()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Play");
    }
}
