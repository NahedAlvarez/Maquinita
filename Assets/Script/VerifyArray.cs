using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyArray : MonoBehaviour
{
    public ArrayPadre[] myArray;
    int countDiagonal;
    int countDiagonal1;
    int countHorizontal;
    public GameObject button;

    private void Start()
    {
        myArray = MoveSprite.Instance.myArray;
    }

    public void ButtonMethod()
    {
        if (MoveSprite.Instance.stopPieces == false && Coins.Instance.useCoins > 0)
        {
            Coins.Instance.ResetCoins();
            ColorWhiteArray();
            button.GetComponentInChildren<Text>().text = "STOP";
            MoveSprite.Instance.stopPieces = true;
            Coins.Instance.ResetCoins();
        }
        else if (MoveSprite.Instance.stopPieces == true && Coins.Instance.useCoins > 0)
        {
            button.GetComponentInChildren<Text>().text = "SPIN";
            ExamineArray();
            MoveSprite.Instance.stopPieces = false;
        }  
    }

    public void ColorWhiteArray()
    {
        for(int i = 0; i < myArray.Length; i++)
        {
            for(int j = 0; j < myArray.Length; j++)
            {
                if (myArray[i].arrayHijo[j].GetComponentInChildren<SpriteRenderer>().color == Color.red)
                {
                    myArray[i].arrayHijo[j].GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    public void ExamineArray()
    {
        #region Diagonal
        for(int i = 0; i < myArray.Length-1; i++)
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
                    myArray[i-j].arrayHijo[i-j].GetComponentInChildren<SpriteRenderer>().color = Color.red;
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
                        myArray[i].arrayHijo[j + k].GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    }
                    Coins.Instance.Recollect();
                }
            }
            countHorizontal = 0;
        }
        #endregion

        #region diagonal1
        int count = 2;
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
                    myArray[i - j].arrayHijo[i + j].GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                Coins.Instance.Recollect();
            }
            count--;
        }
        #endregion;

    }


}
