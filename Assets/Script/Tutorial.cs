using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    public bool isScore, endMatch, winPlayer, isPaused;
    public bool skillAvailP1;

    private GameObject theBall;
    public GameObject kickOffMsg, matchOverMsg;
    public GameObject  panelHelp;
    private GameObject thePlayer;


    public AudioSource backSound;
    public AudioSource matchBegin;

    public Sprite[] versiButtonSkill1;

    public Image buttonSkillPlayer;
    public GameObject btnSkillPlayer;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        panelHelp.SetActive(false);

        btnSkillPlayer.SetActive(true);

        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");

        matchBegin.Play();
        backSound.Play();

       
        Time.timeScale = 1;
        Instantiate(kickOffMsg, new Vector3(0, -1, 0), Quaternion.identity);
        
        


        backSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ButtonEnd()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetBall()
    {
        theBall.transform.position = new Vector3(0, 0, 0);
        new WaitForSeconds(1f);
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

    

    IEnumerator WaitSkill1()
    {
        yield return new WaitForSeconds(5);

        thePlayer.GetComponent<Player>().speed -= 4f;
        thePlayer.GetComponent<Player>().jumpingPower -= 2;
        thePlayer.GetComponent<Player>().shootingPowerY -= 200;
        thePlayer.GetComponent<Player>().shootingPowerX -= 100;

    }
    
}
