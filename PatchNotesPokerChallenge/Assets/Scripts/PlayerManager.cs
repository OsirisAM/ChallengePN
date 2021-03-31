using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region PrimitiveVariables
    int handSize = 5;
    int pokerPoints = 0;
    int numberOfCardsReturned = 0;
    List<int> handPosition = new List<int>();
    #endregion

    #region GameVariables
    List<GameObject> cardsInHand= new List<GameObject>();
    List<GameObject> selectedCards = new List<GameObject>();
    PokerCard cardManager;
    #endregion

    #region MonoBehaviour
    #endregion


    #region Access Methods

    public int HandSize
    {
        get {return handSize;}
        set {handSize = value;}
    }

    public int PokerPoints
    {
        get{return pokerPoints;}
        set {pokerPoints = value;}
    }

    public int NumberOfCardsReturned
    {
        get{return numberOfCardsReturned;}
        set{numberOfCardsReturned = value;}
    }

    public List<GameObject> CardsInHand
    {
        get{return cardsInHand;}
        set{cardsInHand = value;}
    }
    public List<GameObject> SelectedCards 
    {
        get{return selectedCards;}
        set{selectedCards = value;}
    }
    public List<int> HandPosition 
    {
        get{return handPosition;}
    }
    #endregion

    #region Player Actions

    public void ReturnCards()
    {
        Debug.Log("Card Removed");
        numberOfCardsReturned = selectedCards.Count;
        for(int i = 0; i < selectedCards.Count;i++)
        {
            selectedCards[i].GetComponent<PokerCard>().PrintInfo();
            cardsInHand.Remove(selectedCards[i]);
            Destroy(selectedCards[i]);
        }
        selectedCards.Clear();
        Debug.Log(cardsInHand.Count.ToString());
    }

    public void AddNewCards(GameObject newCard)
    {
        cardsInHand.Add(newCard);
    }

    #endregion
    
    #region Methods

    public void DeSelectCard(GameObject card)
    {
        selectedCards.Remove(card);
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = false;
        Debug.Log("Card De Selected");
    }
    public void SelectCard(GameObject card)
    {
        Debug.Log("Card Selected");
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = true;
        handPosition.Add(cardManager.HandPosition);
        if(selectedCards.Count < 3)
        {
            selectedCards.Add(card);
            Debug.Log("Card Added");
        }
        else
        {
            Debug.Log("Limit Reached");
        }
    }
    #endregion


}
