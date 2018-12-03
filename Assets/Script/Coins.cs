using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void Recollect()
    {
        coins += useCoins * 100;
        TextActualizeSpin();
    }

    public void ResetCoins()
    {
        useCoins = 0;
        TextActualize();
    }

    public void TextActualizeSpin()
    {
        coinText.text = "Coins: " + coins + " Coins Used: " + 0;
    }

    public void TextActualize()
    {
        coinText.text = "Coins: " + coins + " Coins Used: " + useCoins;
    }

}
