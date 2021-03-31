using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    #region PrimitiveVariables

    #endregion

    #region GameVariables 
    [SerializeField]
    PlayerManager playerManager;
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameObject card;
    [SerializeField]
    GameObject table;


    PokerCard cardToPlayer;
    PokerCard cardFromDeck;

    List<GameObject> handOfCards = new List<GameObject>();
    
    List<Vector3> cardsPosition = new List<Vector3>();
    #endregion

    #region  MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempCard;
        SetCardsPositions();
        deckManager.SetDeckOfCards();
        deckManager.PrintDeckInfo();
        for(int i = 0; i < 5;i++)
        {
            int randomCard = Random.Range(0,deckManager.DeckCount());
            card = deckManager.ReturnCard(randomCard);
            tempCard = Instantiate(card,cardsPosition[i],Quaternion.identity);
            tempCard.transform.SetParent(table.transform);

            cardToPlayer = tempCard.GetComponent<PokerCard>();
            cardFromDeck = card.GetComponent<PokerCard>();
            cardToPlayer.Palo = cardFromDeck.Palo;
            cardToPlayer.Color = cardFromDeck.Color;
            cardToPlayer.Value = cardFromDeck.Value;
            cardToPlayer.SetSprite(cardFromDeck.CardSprite);
            cardToPlayer.SetHandPosition(i);
            cardToPlayer.SetPlayer(playerManager);
            handOfCards.Add(tempCard);
        }
        playerManager.CardsInHand = handOfCards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region PublicMethods
    public void GiveNewCards()
    {
        GameObject newCard;
        for(int i = 0;i < playerManager.NumberOfCardsReturned;i++)
        {
            newCard = Instantiate(card,cardsPosition[playerManager.HandPosition[i]],Quaternion.identity);
            newCard.transform.SetParent(table.transform);
            playerManager.AddNewCards(newCard);
        }
        playerManager.HandPosition.Clear();
    }
    #endregion


    #region PrivateMethods
    private void SetCardsPositions()
    {
        cardsPosition.Add(new Vector3(-3,0,0));
        cardsPosition.Add(new Vector3(0,0,0));
        cardsPosition.Add(new Vector3(3,0,0));
        cardsPosition.Add(new Vector3(6,0,0));
        cardsPosition.Add(new Vector3(9,0,0));
    }
    #endregion
}
