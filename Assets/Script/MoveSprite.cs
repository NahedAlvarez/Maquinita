using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ArrayPadre
{
    public Image[] arrayHijo;
}

public class MoveSprite : Singleton<MoveSprite>
{
    public Sprite[] fruitSprite;
    public bool stopPieces = true;
    public ArrayPadre[] myArray;

    void Start ()
    {
        ReRoll();
        StartCoroutine(MovePiece());
    }
    public void ReRoll()
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            for (int j = 0; j < myArray.Length; j++)
            {
                myArray[i].arrayHijo[j].sprite = fruitSprite[Random.Range(0, fruitSprite.Length)];
            }
        }
        VerifyArray.Instance.ColorWhiteArray();

    }

    int count = 1;
    private void Update()
    {
        if(stopPieces == false)
        {
            StopAllCoroutines();
            count = 0;
        }
        else if(stopPieces == true && count == 0)
        {
            ReRoll();
            StartCoroutine(MovePiece());
        }
    }
    WaitForSeconds timeFruitMove;
    IEnumerator MovePiece()
    {
        count = 1;
        for (int i = 0; i < myArray.Length; i++)
        {
            for (int j = 0; j < myArray.Length; j++)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        myArray[i - 1].arrayHijo[j].sprite = myArray[i].arrayHijo[j].sprite;
                        break;
                    case 2:
                        myArray[i - 1].arrayHijo[j].sprite = myArray[i].arrayHijo[j].sprite;
                        myArray[i].arrayHijo[j].sprite = fruitSprite[Random.Range(0, fruitSprite.Length)];
                        break;
                }
            }
        }
        yield return new WaitForSeconds(.3f);
        StartCoroutine(MovePiece());
    }
}
