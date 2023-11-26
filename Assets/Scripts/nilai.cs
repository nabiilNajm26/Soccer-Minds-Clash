using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class nilai : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] public TMP_Text txt1;
    [SerializeField] public TMP_Text txt2;

    //[SerializeField] public QuizManager1 q1;
    //[SerializeField] public QuizManager2 q2;
    //QuizManager1 q1;
    //[SerializeField] public GameObject CanvasJawab;
    //[SerializeField] public GameObject CanvasAkhir;

    SimpanJawaban1 simpan1;
    SimpanJawaban2 simpan2;

    private void Awake()
    {
        //q1 = FindObjectOfType<QuizManager1>();
        simpan1 = FindObjectOfType<SimpanJawaban1>();
        simpan2 = FindObjectOfType<SimpanJawaban2>();
    }


    private void Start()
    {
        /*txt1.text = q1.Gettext();*/
        txt1.text = simpan1.GetJawaban();
        txt2.text = simpan2.GetJawaban();
        //txt2 = GameObject.Find("nilaiP2").GetComponent<TMP_Text>();
        
        //q2 = FindObjectOfType<QuizManager2>();

        //UpdateCanvasVisibility();
    }



    void Update()
    {

        Debug.Log(simpan1.GetJawaban());
        Debug.Log(simpan2.GetJawaban());
        //Debug.Log(q1.Gettext());
        /*Debug.Log(q2.Bas2);
        string cek1 = q1.Bas1;*/
        //string cek2 = q2.Bas2;

        //txt1.text = cek1;
        //txt2.text = cek2;

        //UpdateCanvasVisibility();
    }




    /*void UpdateCanvasVisibility()
    {
        if (string.IsNullOrEmpty(q1.Bas1))
        {
            CanvasJawab.SetActive(true);
            CanvasAkhir.SetActive(false);
        }
        else
        {
            CanvasJawab.SetActive(false);
            CanvasAkhir.SetActive(true);
        }
    }*/




}
