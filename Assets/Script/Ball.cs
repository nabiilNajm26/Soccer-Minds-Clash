using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject thePlayer;
    private GameObject theOpponent;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theOpponent = GameObject.FindGameObjectWithTag("Opponent");
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
            theOpponent.GetComponent<Player>().canShoot = true;
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
            theOpponent.GetComponent<Player>().canShoot = false;
        }
    }
}
