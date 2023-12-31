// Import library atau namespace yang diperlukan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Deklarasi kelas Menu yang merupakan turunan dari MonoBehaviour
public class Menu : MonoBehaviour
{
    // Deklarasi variabel publik yang dapat diakses dari Editor Unity
    public GameObject panelLoading, panelTransit, panelHint, panelQuit;
    public Image img_loading;
    public static bool isLoading = false;
    public Text txt_loading;

    public AudioSource backsound;
    public AudioSource backsoundSub;
    public bool isAudioPlayed = true;

    public Animator anim;
    public string animationTitle;

    public bool isQuit = false;
    public GameObject firstMenu, firstQuit;

    // Start is called before the first frame update
    void Start()
    {
        panelHint.SetActive(false);
        panelQuit.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstMenu);

        

        // Memulai fungsi Start saat aplikasi/game pertama kali dijalankan

        // Memeriksa apakah isLoading bernilai false
        if (isLoading == false)
        {
            // Jika isLoading false, memulai coroutine waitLoadingMenu
            StartCoroutine(waitLoadingMenu());
        }
        else
        {
            // Jika isLoading true, menonaktifkan panelLoading
            panelLoading.SetActive(false);
            panelHint.SetActive(true);
            backsoundSub.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Memulai fungsi Update setiap frame

        // Memeriksa apakah fillAmount dari img_loading kurang dari 1
        if (img_loading.fillAmount < 1)
        {
            // Jika ya, menambahkan fillAmount img_loading sebesar 0.005 setiap frame
            img_loading.fillAmount += 0.005f;
        }

        // Memeriksa apakah fillAmount img_loading sudah mencapai atau melebihi 1
        if (img_loading.fillAmount >= 1)
        {
            // Jika ya, mengubah nilai isLoading menjadi true
            isLoading = true;
        }

        // Menampilkan persentase loading pada txt_loading
        txt_loading.text = Mathf.RoundToInt(img_loading.fillAmount * 100f) + "%";
    }

    // Coroutine untuk menunggu loading menu
    IEnumerator waitLoadingMenu()
    {
        // Menunggu selama 3 detik
        yield return new WaitForSeconds(5f);

        // Menampilkan panelTransit dan menunggu selama 1.5 detik
        
        backsound.Play();
        
        
        panelTransit.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        // Menonaktifkan panelLoading dan menunggu selama 1.5 detik
        
        panelLoading.SetActive(false);
        yield return new WaitForSeconds(1.7f);

        // Menonaktifkan panelTransit setelah proses loading selesai
        
        panelTransit.SetActive(false);
        panelHint.SetActive(true);

        yield return new WaitForSeconds(2f);
        
        anim.Play(animationTitle);
        isAudioPlayed = false;
    }

    // Method yang dipanggil saat tombol play ditekan
    public void ButtonPlay()
    {
        // Memuat level "Play"
        SceneManager.LoadScene("Play");
    }

    public void ButtonTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ButtonQuit()
    {
        if (isQuit == false)
        {
            isQuit = true;
            panelQuit.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstQuit);
        }
    }

    public void YesButtonQuit()
    {
        Application.Quit();
    }

    public void NoButtonQuit()
    {
        panelQuit.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstMenu);
        isQuit = false;
    }
}
