using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Image flagPlayer1 , starPlayer1;
    public Text txtValuePlayer1, namePlayer1;
    public Image flagPlayer2,  starPlayer2;
    public Text txtValuePlayer2, namePlayer2;

    public int valuePlayer1, valuePlayer2;
    // Start is called before the first frame update
    void Start()
    {
// valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2",1);
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1
        flagPlayer1.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer1", 1) - 1 ];
        namePlayer1.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        txtValuePlayer1.text = PlayerPrefs.GetInt("valuePlayer1",1).ToString() + "/8";
        GetStarPlayer1();

        // Player 2
        flagPlayer2.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];
        namePlayer2.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];
        txtValuePlayer2.text = PlayerPrefs.GetInt("valuePlayer2", 1).ToString() + "/8";
        GetStarPlayer2();
    }
    public void ButtonBack()
    {
        Application.LoadLevel("Menu");
    }

    // Player 1
    public void ButtonLeftPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer1", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer1", 8);
        }else
        {
            valuePlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
            valuePlayer1--;
            PlayerPrefs.SetInt("valuePlayer1",valuePlayer1);
        }
    }

    public void ButtonRightPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer1", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer1", 1);
        }
        else
        {
            int valuePlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
            valuePlayer1++;
            PlayerPrefs.SetInt("valuePlayer1", valuePlayer1);
        }
    }

    // Player 2
    public void ButtonLeftPlayer2()
    {
        if (PlayerPrefs.GetInt("valuePlayer2", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer2", 8);
        }
        else
        {
            valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
            valuePlayer2--;
            PlayerPrefs.SetInt("valuePlayer2", valuePlayer2);
        }
    }

    public void ButtonRightPlayer2()
    {
        if (PlayerPrefs.GetInt("valuePlayer2", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer2", 1);
        }
        else
        {
            int valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
            valuePlayer2++;
            PlayerPrefs.SetInt("valuePlayer2", valuePlayer2);
        }
    }
    public void GetStarPlayer1()
    {
        int vlPlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
        if (vlPlayer1 >= 1 && vlPlayer1 <= 3 || vlPlayer1 > 4)
        {
            starPlayer1.sprite = TeamUI.instance.Star[4];
        }
        else
        {
            starPlayer1.sprite = TeamUI.instance.Star[3];
        }
    }

    public void GetStarPlayer2()
    {
        int vlPlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
        if (vlPlayer2 >= 1 && vlPlayer2 <= 3 || vlPlayer2 > 4)
        {
            starPlayer2.sprite = TeamUI.instance.Star[4];
        }
        else
        {
            starPlayer2.sprite = TeamUI.instance.Star[3];
        }
    }
}
