using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenePancingan : MonoBehaviour
{
    public LevelLoader Ld;
    [SerializeField] public GameObject button;

    private void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate () { mencet(); });
        Ld = FindObjectOfType<LevelLoader>();
    }
    public void mencet()
    {
        Ld.LoadNextLevel();
    }
}
