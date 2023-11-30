using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    public Image flagLeft, flagRight;
    public TMP_Text nameLeft, nameRight;
    public TMP_Text score, matchResult;

    private GameObject thePlayer, theOpponent;

    public static bool rematch;

    public SpriteRenderer headPlayer1, bodyPlayer1, leftHandsPlayer1, rightHandsPlayer1, leftShoePlayer1, rightShoePlayer1;
    public SpriteRenderer headPlayer2, bodyPlayer2, leftHandsPlayer2, rightHandsPlayer2, leftShoePlayer2, rightShoePlayer2;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");

        thePlayer.SetActive(false);
        theOpponent.SetActive(false);

        flagLeft.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        flagRight.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        nameLeft.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        nameRight.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        headPlayer1.sprite = TeamUI.instance.head[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        headPlayer2.sprite = TeamUI.instance.head[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        bodyPlayer1.sprite = TeamUI.instance.body[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        bodyPlayer2.sprite = TeamUI.instance.body[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        leftHandsPlayer1.sprite = TeamUI.instance.leftHands[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        leftHandsPlayer2.sprite = TeamUI.instance.leftHands[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        rightHandsPlayer1.sprite = TeamUI.instance.rightHands[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        rightHandsPlayer2.sprite = TeamUI.instance.rightHands[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        leftShoePlayer1.sprite = TeamUI.instance.leftShoe[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        leftShoePlayer2.sprite = TeamUI.instance.leftShoe[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        rightShoePlayer1.sprite = TeamUI.instance.rightShoe[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        rightShoePlayer2.sprite = TeamUI.instance.rightShoe[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        score.SetText(GameController.number_GoalsLeft + " - " + GameController.number_GoalsRight);

        if(GameController.number_GoalsRight > GameController.number_GoalsLeft)
        {
            matchResult.SetText("You Lose");
        }
        else if(GameController.number_GoalsRight == GameController.number_GoalsLeft)
        {
            matchResult.SetText("Draw");
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
        rematch = true;
        SceneManager.LoadScene("Qpemainpertama");
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Play");
    }
}
