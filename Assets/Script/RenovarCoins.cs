using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenovarCoins : MonoBehaviour
{
    private float time = 300f;
    float fixedTime;
    public Text timeText;
    public AudioClip Coin1;

    private void Start()
    {
        fixedTime = time;
    }

    private void Update()
    {
        timeText.text = "Time for coins: " + (int)(fixedTime/60) + " min";
        if (Time.deltaTime > fixedTime)
        {
            AudioManager.Instance.PlayMusic(Coin1);
            Coins.Instance.coins += 100;
            Coins.Instance.TextActualize();
            fixedTime = time;
        }
        else
        {
            fixedTime -= Time.deltaTime;
        }

       
    }
}