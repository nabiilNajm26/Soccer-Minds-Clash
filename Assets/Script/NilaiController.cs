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
        Ld.LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
