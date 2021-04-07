using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHandPointsManager : MonoBehaviour
{
    
    int handPoints;
    bool pairOfCards = false;
    bool threeOfCards = false;
    bool fourOfKind = false;
    bool straightCards = false;
    bool twoPairsOfCards = false;

    List<string[]> handsSequence = new List<string[]>();

    string[] handOne = {"1","2","3","4","5"};
    string[] handTwo = {"2","3","4","5","6"};
    string[] handThree = {"4","5","6","7","8"};
    string[] handFour = {"5","6","7","8","9"};
    string[] handFive = {"6","7","8","9","10"};
    string[] handSix = {"7","8","9","10","J"};
    string[] handSeven = {"8","9","10","J","Q"};
    string[] handEigth = {"9","10","J","Q","K"};
    string[] handNine = {"1","2","3","4","5"};
    string[] handTen = {"5","6","7","8","9"};
    string[] handEleven = {"9","10","J","Q","K"};

    string[] tempHand = new string[5];

    [SerializeField]
    PlayerManager playerHand;
    [SerializeField]
    Text pokerHandText;
    [SerializeField]
    Button checkHandButton;
    [SerializeField]
    Button replaceCardsButton;
    [SerializeField]
    Button giveNewCardButton;
    [SerializeField]
    Button playNewGameButton;
    [SerializeField]
    Button resetGameButton;

    PokerCard auxInfo;
    PokerCard cardInfo;
    // Start is called before the first frame update
    void Start()
    {
        SetHandSequence();
    }

    public void CheckActualHand()
    {
        giveNewCardButton.gameObject.SetActive(false);
        replaceCardsButton.gameObject.SetActive(false);
        checkHandButton.gameObject.SetActive(false);
        resetGameButton.gameObject.SetActive(true);
        playNewGameButton.gameObject.SetActive(true);

        foreach (GameObject aux in playerHand.CardsInHand)
        {
            CountCardsInHand(playerHand.CardsInHand, aux);
        }
        for (int i = 0; i < playerHand.CardsInHand.Count; i++)
        {
            cardInfo = playerHand.CardsInHand[i].GetComponent<PokerCard>();
            tempHand[i] = cardInfo.Value;
        }
        FindSequence();
        FindDoublePair();
        PokerHand();
    }


    public void CheckHand()
    {

        foreach(GameObject aux in playerHand.CardsInHand)
        {
            CountCardsInHand(playerHand.CardsInHand,aux);
        }
        for(int i = 0; i < playerHand.CardsInHand.Count;i++)
        {
            cardInfo = playerHand.CardsInHand[i].GetComponent<PokerCard>();
            tempHand[i] = cardInfo.Value;
        }
        FindSequence();
        FindDoublePair();
        PokerHand();
    }

    private void FindDoublePair()
    {
        string tempChar = "";
        int countCoincidence = 0;
        for(int i = 0; i < 5; i++)
        {
            tempChar = tempHand[i];
           for(int j = 0;j< 5;j++)
           {
                if (i == j)
                    break;
                if(tempChar == tempHand[j])
                {
                    countCoincidence++;
                }
           }
        }
        if(countCoincidence == 4)
        {
            twoPairsOfCards = true;
            pairOfCards = false;
        }
    }
    private void FindSequence()
    {
        int[] tempHandNumbers = {0,0,0,0,0};
        int indexI = 0;
        int indexJ = 1;
        string tempChar;
       for(int i = 0 ; i < tempHandNumbers.Length; i++)
       {
            tempChar = tempHand[i];
            tempHandNumbers[i] = Convert.ToInt32(tempChar);
       }
        QuickSort(tempHandNumbers, 0, tempHandNumbers.Length - 1);
        while(indexI < indexJ)
        {
            if (tempHandNumbers[indexI] - tempHandNumbers[indexJ] == 1)
            {
                straightCards = true;
                indexI++;
                indexJ++;
                if (indexI == 4 && indexJ == 4)
                    break;
            }
            else
            {
                straightCards = false;
                indexI++;
                indexJ++;
                if (indexJ == 4)
                    break;
            }   
        }
    }

    private void PokerHand()
    {
        if(pairOfCards)
            pokerHandText.text = "PAIR OF A KIND!";
        if(threeOfCards)
            pokerHandText.text = "THREE OF A KIND!";
        if(fourOfKind)
            pokerHandText.text = "FOUR OF A KIND!";
        if(straightCards)
            pokerHandText.text = "STRIAGTH HAND! ";
        if(twoPairsOfCards)
            pokerHandText.text = "TWO PAIRS OF A KIND! ";
    }


    private void CountCardsInHand(List<GameObject> cardsInHand,GameObject card)
    {
        cardInfo = card.GetComponent<PokerCard>();
        foreach (GameObject aux in cardsInHand)
        {
            auxInfo = aux.GetComponent<PokerCard>();
            if(cardInfo.Value == auxInfo.Value )
            {
                cardInfo.NumberInHand += 1;
                if(cardInfo.NumberInHand == 2)
                {
                    pairOfCards = true;
                    threeOfCards = false;
                    fourOfKind = false;
                    CheckPoints(1);
                }
                if(cardInfo.NumberInHand == 3)
                {
                    pairOfCards = false;
                    threeOfCards = true;
                    fourOfKind = false;
                    CheckPoints(5);
                }
                if(cardInfo.NumberInHand == 4)
                {
                    pairOfCards = false;
                    threeOfCards = false;
                    fourOfKind = true;
                    CheckPoints(20);
                }
            }
        }
    }

    private void CheckPoints(int points)
    {
        playerHand.PokerPoints = points;
    }

    private void SetHandSequence()
    {
        handsSequence.Add(handOne);
        handsSequence.Add(handTwo);
        handsSequence.Add(handThree);
        handsSequence.Add(handFour);
        handsSequence.Add(handFive);
        handsSequence.Add(handSix);
        handsSequence.Add(handSeven);
        handsSequence.Add(handEigth);
        handsSequence.Add(handNine);
        handsSequence.Add(handTen);
        handsSequence.Add(handEleven);
    }


    private void QuickSort(int[] tempHand,int first,int last)
    {
        int indexI = first;
        int indexJ = last;
        int middlePoint = (first + last )/2;
        double pivot = tempHand[middlePoint];
        int bubbleVariable;
        do
        {
            while (tempHand[indexI] < pivot)
                indexI++;
            while (tempHand[indexJ] > pivot)
                indexJ--;
            if (indexI <= indexJ)
            {
                bubbleVariable = tempHand[indexI];
                tempHand[indexI] = tempHand[indexJ];
                tempHand[indexJ] = bubbleVariable;
                indexI++;
                indexJ--;
            }
        } while (indexI <= indexJ);
        if (first < indexJ)
            QuickSort(tempHand, first, indexJ);
        if (indexI < last)
            QuickSort(tempHand, indexI, last);
    }
}
//Debug.Log("Player Hand " + tempHand.ToString());
//int aux = 0;
//int numberOfCoincidence = 0;
//foreach (string[] hands in handsSequence)
//{
//    for (int i = 0; i < tempHand.Length; i++)
//    {
//        Debug.Log("Hand Number" + aux.ToString() + " Hand Sequence " + hands[i]);
//        if (Array.Exists(hands, element => element == tempHand[i]))
//        {
//            numberOfCoincidence++;
//            Debug.Log(numberOfCoincidence);
//            if (numberOfCoincidence == 5)
//                break;
//        }
//        else
//        {
//            numberOfCoincidence = 0;
//            Debug.Log(numberOfCoincidence);
//            continue;

//        }
//    }
//    if (numberOfCoincidence == 5)
//        break;
//    aux++;
//}
//if (numberOfCoincidence == 5)
//{
//    straightCards = true;
//    CheckPoints(10);
//}
//else
//{
//    straightCards = false;
//}
//Debug.Log("Se encontro una secucuencia?: " + straightCards);