using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestiona los coins y los coins usados 
/// </summary>

public class Coins : Singleton<Coins>
{
    public int coins = 100;
    public int useCoins;
    public Text coinText;
    public AudioClip clipCoin;

    private void Start()
    {
        TextActualize();
    }
    //Resta coins y aumenta los coins usados / reproduce el sonido  
    public void GetCoin()
    {
        if(MoveSprite.Instance.stopPieces == false)
        {
            return;
        }
        coins -= 1;
        useCoins += 1;
        TextActualize();
        AudioManager.Instance.PlayMusic(clipCoin);
    }

    //da los coins cuando ganas 
    public void Recollect()
    {
        coins += useCoins * 100;
        TextActualizeSpin();
    }
    //reinicia los coins 
    public void ResetCoins()
    {
        useCoins = 0;
        TextActualize();
    }
    //actualiza el texto de coins cuando 
    public void TextActualizeSpin()
    {
        coinText.text = "Coins: " + coins + " Coins Used: " + 0;
    }

    public void TextActualize()
    {
        coinText.text = "Coins: " + coins + " Coins Used: " + useCoins;
    }

}
