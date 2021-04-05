using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandPointsManager : MonoBehaviour
{
    
    int handPoints;
    bool pairOfCards = false;
    bool threeOfCards = false;
    bool fourOfKind = false;

    [SerializeField]
    PlayerManager playerHand;

    PokerCard auxInfo;
    PokerCard cardInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckHand()
    {
        foreach(GameObject aux in playerHand.CardsInHand)
        {
            CountCardsInHand(playerHand.CardsInHand,aux);
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
                Debug.Log(cardInfo.NumberInHand.ToString());
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

}
