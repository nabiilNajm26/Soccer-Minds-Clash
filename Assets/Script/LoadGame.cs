using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    public GameObject panelLoading;
    public Image img_loading;
    public static bool isLoading = false;
    public Text txt_loading;


    // Start is called before the first frame update
    void Start()
    {
        if (isLoading == false)
        {
            // Jika isLoading false, memulai coroutine waitLoadingMenu
            StartCoroutine(waitLoadingMenu());
        }
        else
        {
            // Jika isLoading true, menonaktifkan panelLoading
            panelLoading.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (img_loading.fillAmount < 1)
        {
            // Jika ya, menambahkan fillAmount img_loading sebesar 0.005 setiap frame
            img_loading.fillAmount += 0.002f;
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

    IEnumerator waitLoadingMenu()
    {
        // Menunggu selama 3 detik
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Game");
    }
}
