using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class QuizManager1 : MonoBehaviour
{

    public LevelLoader Ld;
    [Header("Button")]
    [SerializeField] public GameObject button1;
    [SerializeField] public GameObject button2;
    [SerializeField] public GameObject button3;
    [SerializeField] public GameObject button4;
    [SerializeField] public Color warnaOnClick;

    [Header("Countdown Text")]
    [SerializeField] public GameObject countdownTxt;

    [Header("Text")]
    [SerializeField] public TMP_Text txtbutton1;
    [SerializeField] public TMP_Text txtbutton2;
    [SerializeField] public TMP_Text txtbutton3;
    [SerializeField] public TMP_Text txtbutton4;


    SimpanJawaban1 simpan1;

<<<<<<< HEAD
    [System.Serializable] class Question
=======
    [System.Serializable]
    class Question
>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd
    {
        [SerializeField] public string questionTxt;
        [SerializeField] public string[] choices = new string[4];
        [SerializeField] public string answer;

    }
    //Attribues
    int currentQues = 0;
    private float countdownTime = 10f;
    private float currentTime = 0f;
    /*private float timeWhenAnswered = 0f;*/
    private bool playerAnswered = false;    // ini buat nyimpen hitungan kalo player udh jawab apa belum

    //Game Objects
    TMP_Text question;
    TMP_Text countdownText;
    //Button[] choiceButtons = new Button[4];
    //TMP_Text[] buttonText = new TMP_Text[4];

    //pengaturan pertanyaan
    [SerializeField] Question[] quesList = new Question[1];

    //var buat nyimpen jawaban pemain
    public string jwbPlayer1;
    public string bAs1;   //bAs = benar atau salah wkwkwkwk -> ini untuk penentuan buff atau nerf

    public string Bas1
    {
        get { return bAs1; }
        set { bAs1 = value; }
    }



    private void Awake()
    {
        simpan1 = FindObjectOfType<SimpanJawaban1>();

        /*if (SimpanJawaban1.Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }



    private void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyUp(KeyCode.W))
=======
        /*if (Input.GetKeyUp(KeyCode.W))
>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd
        {
            funButton(0);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            funButton(1);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            funButton(2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            funButton(3);
<<<<<<< HEAD
        }
=======
        }*/
>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd

        currentTime -= 1 * Time.deltaTime;
        countdownText = countdownTxt.GetComponent<TMP_Text>();
        countdownText.text = currentTime.ToString("0");

<<<<<<< HEAD
        
=======

>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd

        if (currentTime <= 0)
        {
            currentTime = 0;
<<<<<<< HEAD
            if(!playerAnswered)
=======
            if (!playerAnswered)
>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd
            {
                bAs1 = "salah";
                Ld.LoadNextLevel();
            }
        }


        /*StartCoroutine(StartCountdown());*/

<<<<<<< HEAD
        
=======

>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd

        //Debug.Log("bas1 = " + bAs1);

    }


    private void Start()
    {
        Ld = FindObjectOfType<LevelLoader>();
        currentTime = countdownTime;

        question = GameObject.Find("soal").GetComponent<TMP_Text>();
        /*choiceButtons[0] = GameObject.Find("Button1").GetComponent<Button>();
        choiceButtons[1] = GameObject.Find("Button2").GetComponent<Button>();
        choiceButtons[2] = GameObject.Find("Button3").GetComponent<Button>();
        choiceButtons[3] = GameObject.Find("Button4").GetComponent<Button>();*/

        /*buttonText[0] = button1.GetComponent<TMP_Text>();
        buttonText[1] = button2.GetComponent<TMP_Text>();
        buttonText[2] = button3.GetComponent<TMP_Text>();
        buttonText[3] = button4.GetComponent<TMP_Text>();*/

        // Alternative to give The Button Method (no onClick() configuration required for each Button)
        button1.GetComponent<Button>().onClick.AddListener(delegate () { funButton(0); });
        button2.GetComponent<Button>().onClick.AddListener(delegate () { funButton(1); });
        button3.GetComponent<Button>().onClick.AddListener(delegate () { funButton(2); });
        button4.GetComponent<Button>().onClick.AddListener(delegate () { funButton(3); });

<<<<<<< HEAD
        
=======

>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd

        // Initialization (Start the game)
        randomQues();
        showQuestion();

    }


    /*void ColorOnClick()
    {
        clickedButton = GetComponent<Button>();
        clickedButton.image.color = warnaOnClick;
    }*/


    /*IEnumerator WaitAndSwitchScene()    // ini buat hitungan mundur pas pemain udh jawab
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Waiting for 3 seconds before switching to the next scene.");
        SwitchToNextScene();
    }*/




    void SwitchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void randomQues()
    {

        for (int i = 0; i < quesList.Length; i++)
        {
            int randomIndex = Random.Range(0, quesList.Length);
            Question temporary = quesList[i];
            quesList[i] = quesList[randomIndex];
            quesList[randomIndex] = temporary;
        }

<<<<<<< HEAD
          
=======

>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd
    }

    void showQuestion()
    {
        /*Debug.Log(quesList[currentQues].choices[0]);*/
        question.text = quesList[currentQues].questionTxt;
        txtbutton1.text = quesList[currentQues].choices[0];
        txtbutton2.text = quesList[currentQues].choices[1];
        txtbutton3.text = quesList[currentQues].choices[2];
        txtbutton4.text = quesList[currentQues].choices[3];

    }

    void funButton(int choice)
    {
        playerAnswered = true;
        jwbPlayer1 = quesList[currentQues].choices[choice];

        switch (choice)
        {
            case 0:
                ChangeButtonColor(button1);
                break;
            case 1:
                ChangeButtonColor(button2);
                break;
            case 2:
                ChangeButtonColor(button3);
                break;
            case 3:
                ChangeButtonColor(button4);
                break;
        }

        if (jwbPlayer1 == quesList[currentQues].answer)
        {
            Debug.Log("jawaban benar");
            bAs1 = "benar";
            simpan1.ModifikasiJawaban("benar");
        }
        else
        {
            Debug.Log("jawaban salah");
            bAs1 = "salah";
            simpan1.ModifikasiJawaban("salah");
        }

        /*if (currentQues < quesList.Length - 1)
        {
            currentQues += 1;
        }*/

        /*showQuestion();*/
        /*StartCoroutine(WaitAndSwitchScene());*/
        Debug.Log(jwbPlayer1);
        Ld.LoadNextLevel();
    }

    void ChangeButtonColor(GameObject button)
    {
        // Ganti warna tombol menjadi warna yang diinginkan (misalnya, warnaOnClick)
        button.GetComponent<Image>().color = warnaOnClick;
    }

    public string Gettext()
    {
        return bAs1;
    }

<<<<<<< HEAD
}
=======
    public void ButtonAns1()
    {

        funButton(0);

    }
    public void ButtonAns2()
    {

        funButton(1);

    }
    public void ButtonAns3()
    {

        funButton(2);

    }
    public void ButtonAns4()
    {

        funButton(3);

    }
}
>>>>>>> c269fc66188381583d0dfcbcd83e2308a409b2cd
