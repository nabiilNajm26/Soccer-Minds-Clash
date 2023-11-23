using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text txt_GoalsRight, txt_GoalsLeft, txt_timeMatch;
    public int number_GoalsRight, number_GoalsLeft;
    public bool isScore, endMatch, winPlayer;
    public float timeMatch;
    private GameObject theBall;
    public GameObject kickOffMsg;
    private GameObject thePlayer, theOpponent;

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
        timeMatch = 90;
        Instantiate(kickOffMsg, new Vector3(0, -1, 0), Quaternion.identity);
        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");
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
        yield return new WaitForSeconds(2f);
        isScore = false;
        if(endMatch == false)
        {
            theBall.transform.position = new Vector3(0, 0, 0);
            theBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            thePlayer.gameObject.transform.position = new Vector2(0, 0);
            theOpponent.gameObject.transform.position = new Vector2(10, 0);
            if(winPlayer == true)
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 200));
            }
            else
            {
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }
        }

    }
}
