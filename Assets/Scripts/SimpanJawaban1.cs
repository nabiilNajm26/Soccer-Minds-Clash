using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SimpanJawaban1 : MonoBehaviour
{


    //string jawaban1;
    //static SimpanJawaban1 instance;
    //static SimpanJawaban1 instance;

    string jawaban1;
    // Start is called before the first frame update

    /*[HideInInspector]
    public string jawaban1;*/

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

        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Menyimpan objek ketika berpindah scene
        }
        else
        {
            Destroy(gameObject); // Menghapus objek jika objek sudah ada
        }*/
    }

    /*public static SimpanJawaban1 Instance
    {
        get { return instance; }
    }*/

    public string GetJawaban()
    {
        return jawaban1;
    }


    public void ModifikasiJawaban(string value)
    {
        jawaban1 = value;
        SaveJawaban();
    }

    void SaveJawaban()
    {
        PlayerPrefs.SetString("Jawaban1", jawaban1);
        PlayerPrefs.Save();
    }


    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("jawaban 1 = " + jawaban1);
    }


    void LoadJawaban()
    {
        jawaban1 = PlayerPrefs.GetString("Jawaban1", "");
    }
}
