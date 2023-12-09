using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);

        
        
        if(levelIndex == 6)
        {
            yield return new WaitForSeconds(2f);
            transition.SetTrigger("Start");
            /*yield return new WaitForSeconds(3f);*/
        }
        else
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(2f);
        }


        SceneManager.LoadScene(levelIndex);
    }
}
