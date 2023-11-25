using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject thePlayer;
    private GameObject theOpponent;
    public GameObject goals, theBall;

    public AudioSource kenaGawang;
    public AudioSource gol;

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
        if (collision.gameObject.tag == "Target")
        {
            kenaGawang.Play();
        }
        if (collision.gameObject.tag == "Head")
        {
            Debug.Log("P1 Kena Kepala");
            thePlayer.GetComponent<Player>().canHead = true;
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 150));
        }
        if (collision.gameObject.tag == "GoalsRight")
        {
            gol.Play();
            if (GameController.instance.isScore == false && GameController.instance.endMatch == false)
            {
                Instantiate(goals, new Vector3(0, -1, 0), Quaternion.identity);

                //Nambah value score
                GameController.number_GoalsLeft++;
                GameController.instance.isScore = true;

                thePlayer.GetComponent<Player>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;
                theOpponent.GetComponent<PlayerTwo>().rb_player.constraints = RigidbodyConstraints2D.FreezePositionX;

                GameController.instance.ContinueMatch(true);

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
            gol.Play();
            if (GameController.instance.isScore == false && GameController.instance.endMatch == false)
            {
                Instantiate(goals, new Vector3(0, -1, 0), Quaternion.identity);

                //Nambah value score
                GameController.number_GoalsRight++;
                GameController.instance.isScore = true;

                

                GameController.instance.ContinueMatch(false);

                //Reset posisi dan force bola tiap skor dicetak
                /*theBall.gameObject.transform.position = new Vector2(0, 0);
                theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));

                thePlayer.gameObject.transform.position = new Vector2(0, 0);
                theOpponent.gameObject.transform.position = new Vector2(10, 0);
                GameController.instance.isScore = false;
*/

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
        if (collision.gameObject.tag == "Head")
        {
            Debug.Log("P1 Lepas Kepala");
            thePlayer.GetComponent<Player>().canHead = false;
        }
    }
}
