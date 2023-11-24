// Import library atau namespace yang diperlukan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Deklarasi kelas Play yang merupakan turunan dari MonoBehaviour
public class Play : MonoBehaviour
{
    // Deklarasi variabel publik yang dapat diakses dari Editor Unity
    public Image flagPlayer1, starPlayer1;
    public Text txtValuePlayer1, namePlayer1;
    public Image flagPlayer2, starPlayer2;
    public Text txtValuePlayer2, namePlayer2;

    public int valuePlayer1, valuePlayer2;

    // Start is called before the first frame update
    void Start()
    {
        // Fungsi Start yang dipanggil sebelum frame pertama dijalankan
        // valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2",1);
        // Komentar di atas adalah kode yang di-komentar (tidak dijalankan), mungkin tidak diperlukan pada saat ini.
    }

    // Update is called once per frame
    void Update()
    {
        // Fungsi Update yang dipanggil setiap frame

        // Mengatur tampilan untuk Player 1
        flagPlayer1.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        namePlayer1.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer1", 1) - 1];
        txtValuePlayer1.text = PlayerPrefs.GetInt("valuePlayer1", 1).ToString() + "/8";
        GetStarPlayer1();

        // Mengatur tampilan untuk Player 2
        flagPlayer2.sprite = TeamUI.instance.TeamFlag[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];
        namePlayer2.text = TeamUI.instance.TeamName[PlayerPrefs.GetInt("valuePlayer2", 1) - 1];
        txtValuePlayer2.text = PlayerPrefs.GetInt("valuePlayer2", 1).ToString() + "/8";
        GetStarPlayer2();
    }

    // Method yang dipanggil saat tombol kembali ditekan
    public void ButtonBack()
    {
        // Memuat level "Menu"
        Application.LoadLevel("Menu");
    }

    public void ButtonNext()
    {
        Application.LoadLevel("Game");
    }

    // Method untuk mengubah pemilihan tim untuk Player 1 ke kiri
    public void ButtonLeftPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer1", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer1", 8);
        }
        else
        {
            valuePlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
            valuePlayer1--;
            PlayerPrefs.SetInt("valuePlayer1", valuePlayer1);
        }
    }

    // Method untuk mengubah pemilihan tim untuk Player 1 ke kanan
    public void ButtonRightPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer1", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer1", 1);
        }
        else
        {
            int valuePlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
            valuePlayer1++;
            PlayerPrefs.SetInt("valuePlayer1", valuePlayer1);
        }
    }

    // Method untuk mengubah pemilihan tim untuk Player 2 ke kiri
    public void ButtonLeftPlayer2()
    {
        if (PlayerPrefs.GetInt("valuePlayer2", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer2", 8);
        }
        else
        {
            valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
            valuePlayer2--;
            PlayerPrefs.SetInt("valuePlayer2", valuePlayer2);
        }
    }

    // Method untuk mengubah pemilihan tim untuk Player 2 ke kanan
    public void ButtonRightPlayer2()
    {
        if (PlayerPrefs.GetInt("valuePlayer2", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer2", 1);
        }
        else
        {
            int valuePlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
            valuePlayer2++;
            PlayerPrefs.SetInt("valuePlayer2", valuePlayer2);
        }
    }

    // Method untuk mendapatkan bintang (star) untuk Player 1
    public void GetStarPlayer1()
    {
        int vlPlayer1 = PlayerPrefs.GetInt("valuePlayer1", 1);
        if (vlPlayer1 >= 1 && vlPlayer1 <= 3 || vlPlayer1 > 4)
        {
            starPlayer1.sprite = TeamUI.instance.Star[4];
        }
        else
        {
            starPlayer1.sprite = TeamUI.instance.Star[3];
        }
    }

    // Method untuk mendapatkan bintang (star) untuk Player 2
    public void GetStarPlayer2()
    {
        int vlPlayer2 = PlayerPrefs.GetInt("valuePlayer2", 1);
        if (vlPlayer2 >= 1 && vlPlayer2 <= 3 || vlPlayer2 > 4)
        {
            starPlayer2.sprite = TeamUI.instance.Star[4];
        }
        else
        {
            starPlayer2.sprite = TeamUI.instance.Star[3];
        }
    }
}
