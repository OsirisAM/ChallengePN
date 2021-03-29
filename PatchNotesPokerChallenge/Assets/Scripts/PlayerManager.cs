using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region PrimitiveVariables
    int handSize = 5;
    int pokerPoints = 0;
    #endregion

    #region GameVariables
    List<GameObject> handCards = new List<GameObject>();
    List<GameObject> cardsToReplace = new List<GameObject>();

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

    public List<GameObject> HandOfCards
    {
        get{return handCards;}
        set{handCards = value;}
    }
    #endregion

    #region Player Actions

    public void ReturnCards()
    {
        for(int i = 0; i < cardsToReplace.Count;i++)
        {
            
        }
    }

    #endregion
    
    #region Methods
    public void SetListToRemove(GameObject cards)
    {
        Debug.Log(cardsToReplace.Count.ToString());
        cardManager = cards.GetComponent<PokerCard>();
        if(!cardManager.CardAdded)
        {
            cardManager.CardAdded = true;
            if(cardsToReplace.Count < 3)
            {
                cardsToReplace.Add(cards);
                Debug.Log("Card Added");
            }
            else
            {
                Debug.Log("Limit Reached");
            }
        }
        else
        {
            Debug.Log("Card already Added");
        }


        Debug.Log(cardsToReplace.Count.ToString());
        
    }
    #endregion


}
