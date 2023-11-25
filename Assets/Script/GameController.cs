using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text txt_GoalsRight, txt_GoalsLeft, txt_timeMatch;
    public static int number_GoalsRight, number_GoalsLeft;
    public bool isScore, endMatch, winPlayer;
    public float timeMatch;
    private GameObject theBall;
    public GameObject kickOffMsg;
    public GameObject panelPause;
    private GameObject thePlayer, theOpponent;

    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;
    public SpriteRenderer headPlayer1, bodyPlayer1, leftHandsPlayer1, rightHandsPlayer1, leftShoePlayer1, rightShoePlayer1;
    public SpriteRenderer headPlayer2, bodyPlayer2, leftHandsPlayer2, rightHandsPlayer2, leftShoePlayer2, rightShoePlayer2;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(false);
        timeMatch = 90;
        Instantiate(kickOffMsg, new Vector3(0, -1, 0), Quaternion.identity);
        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");

        //Mengambil value dari play scene, dan diterapkan pada object player 1 serta player 2
        flagLeft.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        flagRight.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        nameLeft.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        nameRight.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];

        nameLeft.gameObject.SetActive(false);
        nameRight.gameObject.SetActive(false);

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

        

        StartCoroutine(BeginMatch());
    }

    // Update is called once per frame
    void Update()
    {
        txt_GoalsLeft.text = number_GoalsLeft.ToString();
        txt_GoalsRight.text = number_GoalsRight.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }

    IEnumerator BeginMatch()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (timeMatch > 0)
            {
                timeMatch--;
            }
            else
            {
                endMatch = true;
                break;
            }
        }
    }

    public void ContinueMatch(bool winPlayer)
    {
        StartCoroutine(WaitContinueMatch(winPlayer));
    }

    IEnumerator WaitContinueMatch(bool winPlayer)
    {
        thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
        
        thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(2f);
        isScore = false;
        if(endMatch == false)
        {
            theBall.transform.position = new Vector3(0, 0, 0);

            thePlayer.gameObject.transform.position = new Vector2(0, 0);
            theOpponent.gameObject.transform.position = new Vector2(10, 0);
            if(winPlayer == true)
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
            }
            else
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
            }
        }

    }

    public void ButtonPause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonResume()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void ButtonEnd()
    {
        timeMatch = 0;
        panelPause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(WaitEndGame()); 
    }

    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndGame");
    }
}
