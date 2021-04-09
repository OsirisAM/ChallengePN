using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHandPointsManager : MonoBehaviour
{

    #region Primitive Variables
    int handPoints;
    bool pairOfCards = false;
    bool threeOfCards = false;
    bool fourOfKind = false;
    bool straightCards = false;
    bool twoPairsOfCards = false;
    List<string[]> handsSequence = new List<string[]>();
    #endregion
    /// <summary>
    /// Esta parte de codigo tiene las manos que se comparan para saber si es una secuencia de cartas y 
    /// dar puntos corresponditens
    /// </summary>
    #region HandSequences
    string[] handOne = {"1","2","3","4","5"};
    string[] handTwo = {"2","3","4","5","6"};
    string[] handThree = {"4","5","6","7","8"};
    string[] handFour = {"5","6","7","8","9"};
    string[] handFive = {"6","7","8","9","10"};
    string[] handSix = {"7","8","9","10","11"};
    string[] handSeven = {"8","9","10","11","12"};
    string[] handEigth = {"9","10","11","12","13"};
    string[] handNine = {"1","2","3","4","5"};
    string[] handTen = {"5","6","7","8","9"};
    string[] handEleven = {"9","10","11","12","13"};
    string[] tempHand = new string[5];
    #endregion
    /// <summary>
    /// Variables necesarias para el funcionamiento del juego, como PlayerManager para el manejo y acciones del jugador
    /// acciones del dealer
    /// </summary>
    #region GameVariables
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
    #endregion
    /// <summary>
    /// La parte standar donde esta el comportamiento de Unity 
    /// </summary>
    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        SetHandSequence();
    }
    #endregion
    /// <summary>
    /// Metodos publicos como las funciones que realizan los botones y otros 
    /// </summary>
    #region Public Methods
    ///<summary>
    /// Esta funcion es el boton cuando el usuario tiene una mano que puede jugar 
    /// y quiere identificar o saber cuantos puntos gano con la mano actual
    ///</summary>
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

    /// <summary>
    /// Despues de que se hayan repartido las nuevas cartas se checa la mano del jugador 
    /// para saber los puntos que este tiene
    /// </summary>
    public void CheckHand()
    {
        /// <summary>
        /// Esta parte cuenta los posibles pares, tercias o quartetos de un solo tipo de carta que existe
        /// en la mano del jugador
        /// </summary>
        foreach(GameObject aux in playerHand.CardsInHand)
        {
            CountCardsInHand(playerHand.CardsInHand,aux);
        }
        /// <summary>
        /// Se crea una copia de los valores que tiene el jugador en la mano para su manipulacion
        /// esto para evitar cambios en los objetos actuales que tiene el jugador
        /// </summary>
        for(int i = 0; i < playerHand.CardsInHand.Count;i++)
        {
            cardInfo = playerHand.CardsInHand[i].GetComponent<PokerCard>();
            tempHand[i] = cardInfo.Value;
        }
        /// <summary>
        /// Esta parte del codigo, es el algoritmo para checar la secuencia de 
        /// mano, y dar los puntos necesarios y el la funcion PokerHand solo cambia
        /// el texto del juego para avisar que mano esta dando.
        /// </summary>
        FindSequence();
        FindDoublePair();
        PokerHand();
    }
    #endregion

    #region Private Methods
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
                    continue;
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
        while( indexJ < 5)
        {
            int firstCard = tempHandNumbers[indexI];
            int secondCard = tempHandNumbers[indexJ];
            if ((secondCard - firstCard) == 1)
            {
                straightCards = true;
                indexI++;
                if (indexJ < 5)
                {
                    indexJ++;
                }
            }
            else
            {
                straightCards = false;
                indexI++;
                indexJ++;
                if (indexJ <= 4)
                {
                    indexJ++;
                }
            }   
        }   
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
                    
                }
                if(cardInfo.NumberInHand == 3)
                {
                    pairOfCards = false;
                    threeOfCards = true;
                    fourOfKind = false;
                   
                }
                if(cardInfo.NumberInHand == 4)
                {
                    pairOfCards = false;
                    threeOfCards = false;
                    fourOfKind = true;
                    
                }
            }
        }
    }


    private void PokerHand()
    {
        if (pairOfCards)
        {
            CheckPoints(1);
            pokerHandText.text = "PAIR OF A KIND!";
        }


        if (threeOfCards)
        {
            CheckPoints(5);
            pokerHandText.text = "THREE OF A KIND!";
        }


        if (fourOfKind)
        {
            CheckPoints(20);
            pokerHandText.text = "FOUR OF A KIND!";
        }

        if (straightCards)
        {
            CheckPoints(10);
            pokerHandText.text = "STRIAGTH HAND! ";
        }
        if (twoPairsOfCards)
        {
            CheckPoints(3);
            pokerHandText.text = "TWO PAIRS OF A KIND! ";
        }
        fourOfKind = false;
        threeOfCards = false;
        pairOfCards = false;
        straightCards = false;
        twoPairsOfCards = false;
    }


    private void CheckPoints(int points)
    {
        playerHand.PokerPoints += points;
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
    #endregion
}