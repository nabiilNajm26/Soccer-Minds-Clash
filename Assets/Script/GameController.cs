using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static int number_GoalsRight, number_GoalsLeft;

    public Text txt_GoalsRight, txt_GoalsLeft, txt_timeMatch;

    public bool isScore, endMatch, winPlayer, isPaused;
    public bool skillAvailP1, skillAvailP2;

    public float timeMatch;

    private GameObject theBall;
    public GameObject kickOffMsg, matchOverMsg;
    public GameObject panelPause, panelHelp;
    private GameObject thePlayer, theOpponent;

    public string rematch;
    public string replay;

    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;
    public SpriteRenderer headPlayer1, bodyPlayer1, leftHandsPlayer1, rightHandsPlayer1, leftShoePlayer1, rightShoePlayer1;
    public SpriteRenderer headPlayer2, bodyPlayer2, leftHandsPlayer2, rightHandsPlayer2, leftShoePlayer2, rightShoePlayer2;

    public AudioSource backSound, backSoundEnd;
    public AudioSource matchBegin, matchEnd;

    public Sprite[] versiButtonSkill1, versiButtonSkill2;

    public Image buttonSkillPlayer, buttonSkillOpp;
    public GameObject btnSkillPlayer, btnSkillOpp;

    SimpanJawaban1 simpan1;
    SimpanJawaban2 simpan2;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        simpan1 = FindObjectOfType<SimpanJawaban1>();
        simpan2 = FindObjectOfType<SimpanJawaban2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        panelPause.SetActive(false);

        

        btnSkillPlayer.SetActive(true);
        btnSkillOpp.SetActive(true);


        if (simpan1.GetJawaban() == "benar")
        {
            skillAvailP1 = true;
        }
        else
        {
            skillAvailP1 = false;
        }

        if (simpan2.GetJawaban() == "benar")
        {
            skillAvailP2 = true;
        }
        else
        {
            skillAvailP2 = false;
        }


        if (skillAvailP1 == true)
        {
            buttonSkillPlayer.sprite = versiButtonSkill1[0];
        }
        else if (skillAvailP1 == false)
        {
            buttonSkillPlayer.sprite = versiButtonSkill1[1];
        }

        if (skillAvailP2 == true)
        {
            buttonSkillOpp.sprite = versiButtonSkill2[0];
        }
        else if (skillAvailP2 == false)
        {
            buttonSkillOpp.sprite = versiButtonSkill2[1];
        }

        matchBegin.Play();
        backSound.Play();

        number_GoalsRight = 0;
        number_GoalsLeft = 0;
        Time.timeScale = 1;
        timeMatch = 90;
        Instantiate(kickOffMsg, new Vector3(0, -1, 0), Quaternion.identity);
        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");

        nameLeft.gameObject.SetActive(false);
        nameRight.gameObject.SetActive(false);

        //Mengambil value dari play scene, dan diterapkan pada object player 1 serta player 2
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

        
        StartCoroutine(BeginMatch());
        

        backSound.Play();
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
        backSound.Pause();
        Time.timeScale = 0;
        panelHelp.SetActive(true);

        yield return new WaitForSeconds(5);

        panelHelp.SetActive(false);
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

                //Start memutar audio
                backSound.Stop();
                backSoundEnd.Play();
                matchEnd.Play();

                StartCoroutine(WaitEndGame());

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
        if (endMatch == false)
        {
            theBall.transform.position = new Vector3(0, 0, 0);

            thePlayer.gameObject.transform.position = new Vector2(0, 0);
            theOpponent.gameObject.transform.position = new Vector2(10, 0);
            if (winPlayer == true)
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
            }
            else
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
            }
        }
        else if (endMatch == true)
        {
            //Start memutar audio
            backSound.Stop();
            backSoundEnd.Play();
            matchEnd.Play();

            StartCoroutine(WaitEndGame());
        }

    }

    public void ButtonPause()
    {
        /* if (isPaused == false)
         {
             panelPause.SetActive(true);
             btnSkillPlayer.SetActive(false);
             btnSkillOpp.SetActive(true);
             backSound.Pause();
             Time.timeScale = 0;

             isPaused = true;
         }

         if (isPaused == true)
         {
             isPaused = false;
             ButtonResume();
         }
 */
        panelPause.SetActive(true);
        btnSkillPlayer.SetActive(false);
        btnSkillOpp.SetActive(true);
        backSound.Pause();
        Time.timeScale = 0;


    }
    public void ButtonResume()
    {
        backSound.UnPause();
        panelPause.SetActive(false);
        btnSkillPlayer.SetActive(true);
        btnSkillOpp.SetActive(true);


        Time.timeScale = 1;
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene("Qpemainpertama");
    }
    public void ButtonEnd()
    {
        timeMatch = 0;
        panelPause.SetActive(false);
        Time.timeScale = 1;
        /*StartCoroutine(WaitEndGame()); */

    }

    public void ButtonSkill1()
    {
        if (skillAvailP1 == true)
        {
            thePlayer.GetComponent<Player>().speed += 4f;
            thePlayer.GetComponent<Player>().jumpingPower += 2;
            thePlayer.GetComponent<Player>().shootingPowerY += 200;
            thePlayer.GetComponent<Player>().shootingPowerX += 100;

            skillAvailP1 = false;
            buttonSkillPlayer.sprite = versiButtonSkill1[1];
            StartCoroutine(WaitSkill1());
        }

    }

    public void ButtonSkill2()
    {
        if (skillAvailP2 == true)
        {
            theOpponent.GetComponent<Transform>().position += new Vector3(3f, 0.68f, 0f);
            theOpponent.GetComponent<Transform>().localScale += new Vector3(0.4f, 0.4f, 0.4f);

            skillAvailP2 = false;

            buttonSkillOpp.sprite = versiButtonSkill2[1];
            StartCoroutine(WaitSkill2());
        }

    }

    IEnumerator WaitEndGame()
    {


        //Untuk freeze posisi dan rotasi P1 dan P2
        thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
        thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionY;
        thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionY;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;

        //Memunculkan popup text MatchOver
        Instantiate(matchOverMsg, new Vector3(0, -1, 0), Quaternion.identity);

        //Menunggu 3 detik dilanjutkan dengan pindah scene ke result atau scoreboard
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EndGame");
    }

    IEnumerator WaitSkill1()
    {
        yield return new WaitForSeconds(5);

        thePlayer.GetComponent<Player>().speed -= 4f;
        thePlayer.GetComponent<Player>().jumpingPower -= 2;
        thePlayer.GetComponent<Player>().shootingPowerY -= 200;
        thePlayer.GetComponent<Player>().shootingPowerX -= 100;

    }
    IEnumerator WaitSkill2()
    {

        yield return new WaitForSeconds(5);

        theOpponent.GetComponent<Transform>().localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        theOpponent.GetComponent<Transform>().position -= new Vector3(3f, 0.68f, 0f);
    }

    
}
