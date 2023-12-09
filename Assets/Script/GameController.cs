using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //Tambahan
    public LevelLoader Ld;

    public static GameController instance;

    public static int number_GoalsRight, number_GoalsLeft;

    public Text txt_GoalsRight, txt_GoalsLeft, txt_timeMatch;

    public bool isScore, endMatch, winPlayer, isPaused, isHelp;
    public bool skillAvailP1, skillAvailP2;

    public float timeMatch;

    private GameObject theBall;
    public GameObject kickOffMsg, matchOverMsg;
    public GameObject panelPause, panelHelp;
    private GameObject thePlayer, theOpponent;
    public GameObject frozenP1, frozenP2;


    public string rematch;
    public string replay;

    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;
    public SpriteRenderer headPlayer1, bodyPlayer1, leftHandsPlayer1, rightHandsPlayer1, leftShoePlayer1, rightShoePlayer1;
    public SpriteRenderer headPlayer2, bodyPlayer2, leftHandsPlayer2, rightHandsPlayer2, leftShoePlayer2, rightShoePlayer2;

    public AudioSource backSound, backSoundEnd;
    public AudioSource matchBegin, matchEnd;

    public Sprite[] versiButtonSkill1, versiButtonSkill2, versiButtonSkill3;

    public Image buttonSkillPlayer, buttonSkillOpp;
    public GameObject btnSkillPlayer, btnSkillOpp;

    public int randomSkillP1, randomSkillP2;
    public int skillP1, skillP2;

    SimpanJawaban1 simpan1;
    SimpanJawaban2 simpan2;

    [Header("First Selected Options")]
    [SerializeField] public GameObject _pauseMenuFirst;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        simpan1 = FindObjectOfType<SimpanJawaban1>();
        simpan2 = FindObjectOfType<SimpanJawaban2>();

        isPaused = false;
        isHelp = false;

        RandomizeSkill();

        frozenP1.SetActive(false);
        frozenP2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginMatch());


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

        btnSkillPlayer.SetActive(skillAvailP1);
        btnSkillOpp.SetActive(skillAvailP2);

        Debug.Log(randomSkillP1 + " " + randomSkillP2);

        GetSkillP1(skillAvailP1);
        GetSkillP2(skillAvailP2);


        /*EventSystem.current.SetSelectedGameObject(null);*/
        /*        EventSystem.current.SetSelectedGameObject(_pauseMenuFirst);
        */

        panelPause.SetActive(false);
        panelHelp.SetActive(false);

        matchBegin.Play();
        backSound.Play();

        number_GoalsRight = 0;
        number_GoalsLeft = 0;
        Time.timeScale = 1;
        timeMatch = 10;
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

        
        
        

        backSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        txt_GoalsLeft.text = number_GoalsLeft.ToString();
        txt_GoalsRight.text = number_GoalsRight.ToString();
        txt_timeMatch.text = timeMatch.ToString();

        /*if(isPaused)
        {
            OpenPause();
        }
        
        if(!isPaused)
        {
            ClosePause();
        }*/

        if(EventSystem.current.currentSelectedGameObject == _pauseMenuFirst)
        {
            Debug.Log("bener cok");
        }

    }

    IEnumerator BeginMatch()
    {
        /*backSound.Pause();
        Time.timeScale = 0;
        panelHelp.SetActive(true);

        yield return new WaitForSeconds(5);

        panelHelp.SetActive(false);*/
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

    public void OpenPause()
    {
        panelPause.SetActive(true);
        btnSkillPlayer.SetActive(false);
        btnSkillOpp.SetActive(false);
        backSound.Pause();

        


        /*if (panelPause.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(_pauseMenuFirst);
        }*/
        
    }

    public void ClosePause()
    {
        backSound.UnPause();
        panelPause.SetActive(false);
        btnSkillPlayer.SetActive(true);
        btnSkillOpp.SetActive(true);

        
    }

    public void ButtonPause()
    {
        if (isPaused == false)
        {
            isPaused = true;
            OpenPause();
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_pauseMenuFirst);
        }

        else if (isPaused == true)
        {
            isPaused = false;
            ButtonResume();
            
        }

        /*panelPause.SetActive(true);
        btnSkillPlayer.SetActive(false);
        btnSkillOpp.SetActive(true);
        backSound.Pause();
        Time.timeScale = 0;
*/

    }

    public void ButtonHelp()
    {
        if(isHelp == false)
        {
            panelHelp.SetActive(true);
            btnSkillPlayer.SetActive(false);
            btnSkillOpp.SetActive(true);
            backSound.Pause();
            Time.timeScale = 0;

            isHelp = true;
        }
        else if(isHelp == true)
        {
            backSound.UnPause();
            panelHelp.SetActive(false);
            btnSkillPlayer.SetActive(true);
            btnSkillOpp.SetActive(true);


            Time.timeScale = 1;
        }
        
    }
    public void ButtonResume()
    {
        EventSystem.current.SetSelectedGameObject(_pauseMenuFirst);
        EventSystem.current.SetSelectedGameObject(null);

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

            if(skillP1 == 0)
            {
                thePlayer.GetComponent<Player>().speed += 4f;
                thePlayer.GetComponent<Player>().jumpingPower += 2;
                thePlayer.GetComponent<Player>().shootingPowerY += 200;
                thePlayer.GetComponent<Player>().shootingPowerX += 100;

                skillAvailP1 = false;
                buttonSkillPlayer.sprite = versiButtonSkill1[1];
                StartCoroutine(WaitSkill1P1());
            }
            if(skillP1 == 1)
            {
                thePlayer.GetComponent<Transform>().position += new Vector3(3f, 0.68f, 0f);
                thePlayer.GetComponent<Transform>().localScale += new Vector3(0.4f, 0.4f, 0.4f);

                skillAvailP1 = false;

                buttonSkillPlayer.sprite = versiButtonSkill2[1];
                StartCoroutine(WaitSkill2P1());
            }
            if(skillP1 == 2)
            {
                theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
                theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionY;
                frozenP2.SetActive(false);

                skillAvailP1 = false;

                buttonSkillPlayer.sprite = versiButtonSkill3[1];
                StartCoroutine(WaitSkill3P1());
            }
            
        }

    }

    public void ButtonSkill2()
    {
        if (skillAvailP2 == true)
        {

            if (skillP1 == 0)
            {
                theOpponent.GetComponent<PlayerTwo>().speed += 4f;
                theOpponent.GetComponent<PlayerTwo>().jumpingPower += 2;
                theOpponent.GetComponent<PlayerTwo>().shootingPowerY += 200;
                theOpponent.GetComponent<PlayerTwo>().shootingPowerX += 100;

                skillAvailP2 = false;
                buttonSkillOpp.sprite = versiButtonSkill1[1];
                StartCoroutine(WaitSkill1P2());
            }
            if (skillP1 == 1)
            {
                theOpponent.GetComponent<Transform>().position += new Vector3(3f, 0.68f, 0f);
                theOpponent.GetComponent<Transform>().localScale += new Vector3(0.4f, 0.4f, 0.4f);

                skillAvailP2 = false;

                buttonSkillOpp.sprite = versiButtonSkill2[1];
                StartCoroutine(WaitSkill2P2());
            }
            if (skillP1 == 2)
            {
                thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
                thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionY;
                frozenP1.SetActive(true);

                skillAvailP2 = false;

                buttonSkillOpp.sprite = versiButtonSkill3[1];
                StartCoroutine(WaitSkill3P2());
            }

            
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
        yield return new WaitForSeconds(1);
        /*SceneManager.LoadScene("EndGame");*/
        Ld.LoadNextLevel();
    }

    IEnumerator WaitSkill1P1()
    {
        yield return new WaitForSeconds(5);

        thePlayer.GetComponent<Player>().speed -= 4f;
        thePlayer.GetComponent<Player>().jumpingPower -= 2;
        thePlayer.GetComponent<Player>().shootingPowerY -= 200;
        thePlayer.GetComponent<Player>().shootingPowerX -= 100;

    }
    IEnumerator WaitSkill1P2()
    {
        yield return new WaitForSeconds(5);

        theOpponent.GetComponent<Player>().speed -= 4f;
        theOpponent.GetComponent<Player>().jumpingPower -= 2;
        theOpponent.GetComponent<Player>().shootingPowerY -= 200;
        theOpponent.GetComponent<Player>().shootingPowerX -= 100;
    }
    IEnumerator WaitSkill2P1()
    {

        yield return new WaitForSeconds(5);

        thePlayer.GetComponent<Transform>().localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        thePlayer.GetComponent<Transform>().position -= new Vector3(3f, 0.68f, 0f);
    }

    IEnumerator WaitSkill2P2()
    {

        yield return new WaitForSeconds(5);

        theOpponent.GetComponent<Transform>().localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        theOpponent.GetComponent<Transform>().position -= new Vector3(3f, 0.68f, 0f);
    }

    IEnumerator WaitSkill3P1()
    {
        yield return new WaitForSeconds(5);

        frozenP2.SetActive(false);
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.None;
        theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator WaitSkill3P2()
    {
        yield return new WaitForSeconds(5);

        frozenP1.SetActive(false);
        thePlayer.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.None;
        thePlayer.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void RandomizeSkill()
    {
        randomSkillP1 = UnityEngine.Random.Range(0, 2);
        randomSkillP2 = UnityEngine.Random.Range(0, 2);
    }

    public void GetSkillP1(bool skillAvail)
    {
        if (skillAvail == true)
        {
            if (randomSkillP1 == 0)
            {
                skillP1 = 0;
                buttonSkillPlayer.sprite = versiButtonSkill1[0];
            }
            else if (randomSkillP1 == 1)
            {
                skillP1 = 1;
                buttonSkillPlayer.sprite = versiButtonSkill2[0];
            }
            else if (randomSkillP1 == 2)
            {
                skillP1 = 2;
                buttonSkillPlayer.sprite = versiButtonSkill3[0];
            }
            else
            {
                buttonSkillPlayer.sprite = null;
            }
        } 
    }

    public void GetSkillP2(bool skillAvail)
    {
        if(skillAvail == true)
        {
            if (randomSkillP2 == 0)
            {
                skillP2 = 0;
                buttonSkillOpp.sprite = versiButtonSkill1[0];
            }
            if (randomSkillP2 == 1)
            {
                skillP2 = 1;
                buttonSkillOpp.sprite = versiButtonSkill2[0];
            }
            if (randomSkillP2 == 2)
            {
                skillP2 = 2;
                buttonSkillOpp.sprite = versiButtonSkill3[0];
            }
        }
        
    }
}
