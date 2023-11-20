using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject panelLoading, panelTransit;
    public Image img_loading;
    public static bool isLoading = false;
    public Text txt_loading; 

    // Start is called before the first frame update
    void Start()
    {
        if(isLoading == false)
        {
            StartCoroutine(waitLoadingMenu());
        }
        else
        {
            panelLoading.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(img_loading.fillAmount < 1)
        {
            img_loading.fillAmount += 0.005f;
        }
        if(img_loading.fillAmount >= 1)
        {
            isLoading = true;
        }
        txt_loading.text = Mathf.RoundToInt(img_loading.fillAmount * 100f) + "%";

    }
    IEnumerator waitLoadingMenu()
    {
        yield return new WaitForSeconds(3f);
        panelTransit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panelLoading.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        panelTransit.SetActive(false);
    }

    public void ButtonPlay()
    {
        Application.LoadLevel("Play");
    }
}
