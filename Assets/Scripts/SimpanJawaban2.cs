using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SimpanJawaban2 : MonoBehaviour
{


    string jawaban2;
    //static SimpanJawaban2 instance;
    //private static SimpanJawaban2 instance;
    // Start is called before the first frame update

    void Awake()
    {


        LoadJawaban();

        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Menandakan agar objek ini tidak dihancurkan saat pindah scene
        }
        else
        {
            Destroy(gameObject); // Hancurkan objek duplikat jika sudah ada instance sebelumnya
        }*/
        //instance = this;
    }


    /*public static SimpanJawaban2 Instance
    {
        get { return instance; }
    }*/


    public string GetJawaban()
    {
        return jawaban2;
    }


    public void ModifikasiJawaban(string value)
    {
        jawaban2 = value;
        SaveJawaban();
    }

    void SaveJawaban()
    {
        PlayerPrefs.SetString("Jawaban2", jawaban2);
        PlayerPrefs.Save();
    }


    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("jawaban 2 = " + jawaban2);
    }

    void LoadJawaban()
    {
        jawaban2 = PlayerPrefs.GetString("Jawaban2", "");
    }
}
