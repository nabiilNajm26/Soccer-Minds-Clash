using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerbar : MonoBehaviour
{

    public Image zeyenk;
    float time_remaining;
    public float max_time = 10f;
    // Start is called before the first frame update
    
    void Start()
    {
        time_remaining = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            zeyenk.fillAmount = time_remaining / max_time;
        }
    }
}
