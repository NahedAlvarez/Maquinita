using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// cada 5 minutos aumenta en 100 las monedas
/// </summary>
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
    //convierte el tiempo y modifica un text 
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