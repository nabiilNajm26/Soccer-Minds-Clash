using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ScenePancingan : MonoBehaviour
{
    public LevelLoader ld;
    private bool tbl1 = false;
    private bool tbl2 = false;
    private bool isReadyP1 = false;
    private bool isReadyP2 = false;
    [SerializeField] public GameObject button1;
    [SerializeField] public GameObject button2;
    [SerializeField] public TMP_Text txtbutton1;
    [SerializeField] public TMP_Text txtbutton2;
    [SerializeField] public Color warnaOnClick;

    private void Start()
    {
        /*button1.GetComponent<Button>().onClick.AddListener(delegate () { funButton(0); });
        button2.GetComponent<Button>().onClick.AddListener(delegate () { funButton(1); });*/
        /*button1.onClick.AddListener(delegate () { btn1(); });
        button2.onClick.AddListener(delegate () { btn2(); });*/
        ld = FindObjectOfType<LevelLoader>();
    }

    private void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            funButton(0);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            funButton(1);
        }*/


        // Implementasi ini memastikan bahwa kedua tombol ditekan sebelum memuat level berikutnya
        if (isReadyP1 == false || isReadyP2 == false)
        {
            // Satu dari dua tombol tidak ditekan
            Debug.Log("Tekan kedua tombol sebelum melanjutkan.");
            return;
        }

        // Kedua tombol telah ditekan, pindah ke scene selanjutnya
        ld.LoadNextLevel();
    }

    /*void funButton(int choice)
    {


        switch (choice)
        {
            case 0:
                tbl1 = true;
                ChangeButtonColor(button1);
                txtbutton1.text = "Ready";
                break;
            case 1:
                tbl2 = true;
                ChangeButtonColor(button2);
                txtbutton2.text = "Ready";
                break;
        }


        *//*if (currentQues < quesList.Length - 1)
        {
            currentQues += 1;
        }*/

        /*showQuestion();*/
        /*StartCoroutine(WaitAndSwitchScene());*//*

    }*/

    void ChangeButtonColor(GameObject button)
    {
        // Ganti warna tombol menjadi warna yang diinginkan (misalnya, warnaOnClick)
        button.GetComponent<Image>().color = warnaOnClick;
    }


    public void ReadyP1()
    {
        isReadyP1 = true;
        ChangeButtonColor(button1);
        txtbutton1.text = "Ready";
    }

    public void ReadyP2()
    {
        isReadyP2 = true;
        ChangeButtonColor(button2);
        txtbutton2.text = "Ready";
    }



    /*public void btn1(GameObject button)
    {
        tbl1 = true;
        button.GetComponent<Image>().color = warnaOnClick;
    }

    public void btn2()
    {
        tbl2 = true;    
    }*/
}
