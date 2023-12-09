using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [Header("First Selected Options")]
    [SerializeField] public GameObject _pauseMenuFirst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameController.instance.isPaused == true)
        {
            EventSystem.current.SetSelectedGameObject(_pauseMenuFirst);
        }
        if(GameController.instance.isPaused == false)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }*/
    }
}
