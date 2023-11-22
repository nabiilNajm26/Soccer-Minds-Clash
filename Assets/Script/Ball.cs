using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject thePlayer;
    private GameObject theOpponent;
    public GameObject goals, theBall;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("P1 Kena Bola");
            thePlayer.GetComponent<Player>().canShoot = true;
        }
        if (collision.gameObject.tag == "Opponent")
        {
            Debug.Log("P2 Kena Bola");
            theOpponent.GetComponent<PlayerTwo>().canShoot = true;
        }
        if (collision.gameObject.tag == "GoalsRight")
        {
            Instantiate(goals, new Vector3(0, -1, 0), Quaternion.identity);
            if (GameController.instance.isScore == false && GameController.instance.endMatch == false)
            {
                //Nambah value score
                GameController.instance.number_GoalsLeft++;
                GameController.instance.isScore = true;

                //Reset posisi dan force bola tiap skor dicetak
                /*theBall.gameObject.transform.position = new Vector2(0, 0);
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));

                thePlayer.gameObject.transform.position = new Vector2(0, 0);
                theOpponent.gameObject.transform.position = new Vector2(10, 0);
                GameController.instance.isScore = false;*/

            }

        }
        if (collision.gameObject.tag == "GoalsLeft")
        {
            Instantiate(goals, new Vector3(0, -1, 0), Quaternion.identity);
            if (GameController.instance.isScore == false && GameController.instance.endMatch == false)
            {
                //Nambah value score
                GameController.instance.number_GoalsRight++;
                GameController.instance.isScore = true;

                //Reset posisi dan force bola tiap skor dicetak
                /*theBall.gameObject.transform.position = new Vector2(0, 0);
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));

                thePlayer.gameObject.transform.position = new Vector2(0, 0);
                theOpponent.gameObject.transform.position = new Vector2(10, 0);
                GameController.instance.isScore = false;*/


            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("P1 Lepas Bola");
            thePlayer.GetComponent<Player>().canShoot = false;
        }
        if (collision.gameObject.tag == "Opponent")
        {
            Debug.Log("P2 Lepas Bola");
            theOpponent.GetComponent<PlayerTwo>().canShoot = false;
        }
    }
}
