// Import library atau namespace yang diperlukan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deklarasi kelas TeamUI yang merupakan turunan dari MonoBehaviour
public class TeamUI : MonoBehaviour
{
    // Deklarasi variabel instance yang bersifat statis, dapat diakses dari kelas lain
    public static TeamUI instance;

    // Array untuk menyimpan sprite dari bendera tim
    public Sprite[] TeamFlag;

    // Array untuk menyimpan nama tim
    public string[] TeamName;

    // Array untuk menyimpan sprite dari bintang
    public Sprite[] Star;

    // Method yang dipanggil saat objek dibuat di dunia game
    private void Awake()
    {
        // Memastikan bahwa hanya ada satu instance dari TeamUI yang dapat ada
        if (instance == null)
        {
            // Jika instance belum ada, set instance menjadi objek saat ini
            instance = this;

            // Menyatakan bahwa objek ini tidak akan dihancurkan ketika pindah antar level
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika instance sudah ada, hancurkan objek saat ini agar hanya ada satu instance yang tersisa
            DestroyImmediate(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Fungsi Start yang dipanggil sebelum frame pertama dijalankan
        // (Tidak ada implementasi khusus di sini)
    }

    // Update is called once per frame
    void Update()
    {
        // Fungsi Update yang dipanggil setiap frame
        // (Tidak ada implementasi khusus di sini)
    }
}
