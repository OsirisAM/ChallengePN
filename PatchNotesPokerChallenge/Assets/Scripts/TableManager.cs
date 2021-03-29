using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{


    #region GameVariables 
    [SerializeField]
    PlayerManager playerManager;
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameObject card;
    [SerializeField]
    GameObject table;
    
    List<GameObject> handOfCards = new List<GameObject>();
    PokerCard cardManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempCard;
        for(int i = 0; i < 5;i++)
        {
            tempCard = Instantiate(card);
            tempCard.transform.SetParent(table.transform);
            SetCardsInfo(tempCard,i.ToString(),i.ToString(),i.ToString());
            handOfCards.Add(tempCard);
        }
        playerManager.HandOfCards = handOfCards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCardsInfo(GameObject tempCard,string palo,string color,string value)
    {
        cardManager = tempCard.GetComponent<PokerCard>();
        cardManager.SetCard(palo,color,value);
        cardManager.SetPlayer(playerManager);
    }
}
