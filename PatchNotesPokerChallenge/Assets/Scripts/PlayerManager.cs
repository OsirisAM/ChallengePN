using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region PrimitiveVariables
    int handSize = 5;
    int pokerPoints = 0;
    int numberOfCardsReturned = 0;
    List<int> handPosition = new List<int>();
    #endregion

    #region GameVariables
    [SerializeField]
    Text pointsText;
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    Button newCardButton;
    [SerializeField]
    Button replaceCardButton;
    List<GameObject> cardsInHand= new List<GameObject>();
    List<GameObject> selectedCards = new List<GameObject>();
    PokerCard cardManager;
    #endregion

    #region MonoBehaviour
    private void Update() {
        if(pokerPoints > 0)
        {
            pointsText.text = pokerPoints.ToString();
        }    
    }
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
        //Debug.Log("Card Removed");
        numberOfCardsReturned = selectedCards.Count;
        for(int i = 0; i < numberOfCardsReturned;i++)
        {
            cardsInHand.Remove(selectedCards[i]);
            deckManager.ReturnCard(selectedCards[i]);
            Destroy(selectedCards[i]);
        }
        //Debug.Log(cardsInHand.Count.ToString());
        replaceCardButton.gameObject.SetActive(false);
        newCardButton.gameObject.SetActive(true);
    }

    public void AddNewCards(GameObject newCard)
    {
        cardsInHand.Add(newCard);
        selectedCards.Clear();
    }

    #endregion
    
    #region Methods

    public void DeSelectCard(GameObject card)
    {
        selectedCards.Remove(card);
        Vector3 tempPosition = new Vector3(0,1,0);
        card.transform.position -= tempPosition;
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = false;
        //Debug.Log("Card De Selected");
    }
    public void SelectCard(GameObject card)
    {
        //Debug.Log("Card Selected");
        Vector3 tempPosition = new Vector3(0,1,0);
        card.transform.position += tempPosition;
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = true;
        handPosition.Add(cardManager.HandPosition);
        if(selectedCards.Count < 3)
        {
            selectedCards.Add(card);
            //Debug.Log("Card Added");
        }
        else
        {
            //Debug.Log("Limit Reached");
        }
    }
    #endregion


}
