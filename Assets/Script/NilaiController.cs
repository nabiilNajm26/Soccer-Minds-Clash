using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NilaiController : MonoBehaviour
{

    public LevelLoader Ld;

    // Start is called before the first frame update
    void Start()
    {
        Ld = FindObjectOfType<LevelLoader>();
        /*Ld.LoadNextLevel();*/
        StartCoroutine(LanjutScene());

    }


    IEnumerator LanjutScene()
    {
        //Menunggu 3 detik dilanjutkan dengan pindah scene ke result atau scoreboard
        yield return new WaitForSeconds(6);
        /*SceneManager.LoadScene("EndGame");*/
        Ld.LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
