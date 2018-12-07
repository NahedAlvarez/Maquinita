using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyArray : Singleton<VerifyArray>
{
    public ArrayPadre[] myArray;
    public GameObject button;
    public AudioClip coin;
    public AudioClip coin1;
    public AudioSource _audioSource;

    private void Start()
    {
        myArray = MoveSprite.Instance.myArray;
        _audioSource = GetComponent<AudioSource>();
    }

    public void ButtonMethod()
    {
        if (MoveSprite.Instance.stopPieces == false && Coins.Instance.useCoins > 0)
        {
            Coins.Instance.ResetCoins();
            button.GetComponentInChildren<Text>().text = "STOP";
            MoveSprite.Instance.stopPieces = true;
            Coins.Instance.ResetCoins();
            AudioManager.Instance.PlayMusic(coin1);
            if(!AudioManager.Instance.mute)
            _audioSource.volume = 0.5f;
        }
        else if (MoveSprite.Instance.stopPieces == true && Coins.Instance.useCoins > 0)
        {
            button.GetComponentInChildren<Text>().text = "SPIN";
            ExamineArray();
            MoveSprite.Instance.stopPieces = false;
            AudioManager.Instance.PlayMusic(coin1);
            if (!AudioManager.Instance.mute)
                _audioSource.volume = 0.2f;
        }  
    }

    public void ColorWhiteArray()
    {
        for(int i = 0; i < myArray.Length; i++)
        {
            for(int j = 0; j < myArray.Length; j++)
            {
                if (myArray[i].arrayHijo[j].transform.Find("Image").GetComponent<Image>().color == Color.red)
                {
                    myArray[i].arrayHijo[j].transform.Find("Image").GetComponent<Image>().color = Color.white;
                }
            }
        }
    }
    //examoina el array para saber si gano el jugador o no de forma horizontal y transversal
    int countDiagonal1;
    int countHorizontal;
    int countDiagonal;
    public void ExamineArray()
    {
        countDiagonal = 0;
        countDiagonal1 = 0;
        countHorizontal = 0;
        
        #region Diagonal
        for (int i = 0; i < myArray.Length-1; i++)
        {
            if(myArray[i].arrayHijo[i].sprite == myArray[i+1].arrayHijo[i+1].sprite)
            {
                countDiagonal++;
            }
            else 
            {
                countDiagonal = 0;
                continue;
            }

            if(countDiagonal == 2)
            {
                for (int j = -1; j <= 1; j++)
                {
                    myArray[i - j].arrayHijo[i - j].transform.Find("Image").GetComponent<Image>().color = Color.red;
                }

                Coins.Instance.Recollect();
            }
        }
        #endregion

        #region Horizontal
        for (int i = 0; i < myArray.Length; i++)
        {
            for (int j = 0; j < myArray.Length - 1; j++)
            {
                if (myArray[i].arrayHijo[j].sprite == myArray[i].arrayHijo[j + 1].sprite)
                {
                    countHorizontal++;
                }
                else
                {
                    countHorizontal = 0;
                    continue;
                }

                if (countHorizontal == 2)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        myArray[i].arrayHijo[j + k].transform.Find("Image").GetComponent<Image>().color = Color.red;
                        AudioManager.Instance.PlayMusic(coin);
                    }
                    Coins.Instance.Recollect();
                }
            }
            countHorizontal = 0;
        }
        #endregion

        #region diagonal1
        int count = 2;
        count = 2;
        for (int i = 0; i < myArray.Length - 1; i++)
        {
            if (myArray[count].arrayHijo[i].sprite == myArray[count - 1].arrayHijo[i + 1].sprite)
            {
                countDiagonal1++;
            }
            else
            {
                countDiagonal1 = 0;
                break;
            }
            if (countDiagonal1 == 2)
            {
                for (int j = -1; j <= 1; j++)
                {
                    myArray[i - j].arrayHijo[i + j].transform.Find("Image").GetComponent<Image>().color = Color.red;
                }
                Coins.Instance.Recollect();
            }
            count--;
        }
        #endregion;

    }


}
