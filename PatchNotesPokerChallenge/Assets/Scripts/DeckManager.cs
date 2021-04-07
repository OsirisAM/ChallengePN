
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Sprite[] cardsTextureHearts = new Sprite[13];
    public Sprite[] cardsTextureClover= new Sprite[13];
    public Sprite[] cardsTextureDiamond = new Sprite[13];
    public Sprite[] cardsTextureSpades = new Sprite[13];

    string[] cardValueHearts = new string[13];
    string[] cardValueClover = new string[13];
    string[] cardValueDiamond = new string[13];
    string[] cardValueSpades = new string[13];

    List<GameObject> deckOfCards = new List<GameObject>(); 
    
    [SerializeField]
    GameObject card;
    [SerializeField]
    GameObject deck;

    PokerCard cardInfo;
    GameObject cardToReturn;


    public void PrintDeckInfo()
    {
        foreach(GameObject cardInfo in deckOfCards)
        {
            cardInfo.GetComponent<PokerCard>().PrintInfo();
        }
    }

    public GameObject GiveCard(int randomCard)
    {
        cardToReturn = deckOfCards[randomCard];
        deckOfCards.Remove(cardToReturn);
        //Debug.Log(deckOfCards.Count.ToString());
        return cardToReturn;
    }

    public void ReturnCard(GameObject card)
    {
        deckOfCards.Add(card);
        //Debug.Log(deckOfCards.Count.ToString());
    }

    public int DeckCount()
    {
        return deckOfCards.Count;
    }

    public void ResetDeck()
    {
        int numberOfCards = deck.transform.childCount;
        for(int i = 0; i < numberOfCards;i++)
            Destroy(deck.transform.GetChild(i).gameObject);
    }

    public void SetDeckOfCards()
    {
        SetCardValues(); 
        
        for(int i = 0;i < 13;i++)
        {
            deckOfCards.Add(SetCardInformation(card,cardsTextureHearts[i],"Red",cardValueHearts[i],"Hearts"));
        }
        for(int i = 0;i < 13;i++)
        {
            deckOfCards.Add(SetCardInformation(card,cardsTextureClover[i],"Black",cardValueClover[i],"Clovers"));
        }
        for(int i = 0;i < 13;i++)
        {
            deckOfCards.Add(SetCardInformation(card,cardsTextureDiamond[i],"Red",cardValueDiamond[i],"Diamonds"));
        }
        for(int i = 0;i < 13;i++)
        {
            deckOfCards.Add(SetCardInformation(card,cardsTextureSpades[i],"Black",cardValueSpades[i],"Spades"));
        }
    }


    private GameObject SetCardInformation(GameObject card,Sprite cardSprite,string color,string value,string palo)
    {
        GameObject tempCard;
        tempCard = Instantiate(card,deck.transform);
        tempCard.transform.SetParent(deck.transform);
        cardInfo = tempCard.GetComponent<PokerCard>();
        cardInfo.SetCard(palo,color,value,cardSprite);
        return tempCard;
    }
    private void SetCardValues()
    {
        for(int i = 0;i<13;i++)
        {
            switch(i)
            {
                case 0:
                    cardValueHearts[i] = "1";
                    cardValueClover[i] = "1";
                    cardValueDiamond[i] = "1";
                    cardValueSpades[i] = "1";
                    break;
                    
                case 1:
                    cardValueHearts[i] = "2";
                    cardValueClover[i] = "2";
                    cardValueDiamond[i] = "2";
                    cardValueSpades[i] = "2";
                    break;
                    
                case 2:
                    cardValueHearts[i] = "3";
                    cardValueClover[i] = "3";
                    cardValueDiamond[i] = "3";
                    cardValueSpades[i] = "3";
                    break;
                    
                case 3:
                    cardValueHearts[i] = "4";
                    cardValueClover[i] = "4";
                    cardValueDiamond[i] = "4";
                    cardValueSpades[i] = "4";
                    break;
                    
                case 4:
                    cardValueHearts[i] = "5";
                    cardValueClover[i] = "5";
                    cardValueDiamond[i] = "5";
                    cardValueSpades[i] = "5";
                    break;
                    
                case 5:
                    cardValueHearts[i] = "6";
                    cardValueClover[i] = "6";
                    cardValueDiamond[i] = "6";
                    cardValueSpades[i] = "6";
                    break;
                    
                case 6:
                    cardValueHearts[i] = "7";
                    cardValueClover[i] = "7";
                    cardValueDiamond[i] = "7";
                    cardValueSpades[i] = "7";
                    break;
                    
                case 7:
                    cardValueHearts[i] = "8";
                    cardValueClover[i] = "8";
                    cardValueDiamond[i] = "8";
                    cardValueSpades[i] = "8";
                    break;
                    
                case 8:
                    cardValueHearts[i] = "9";
                    cardValueClover[i] = "9";
                    cardValueDiamond[i] = "9";
                    cardValueSpades[i] = "9";
                    break;
                    
                case 9:
                    cardValueHearts[i] = "10";
                    cardValueClover[i] = "10";
                    cardValueDiamond[i] = "10";
                    cardValueSpades[i] = "10";
                    break;
                    
                case 10:
                    cardValueHearts[i] = "11";
                    cardValueClover[i] = "11";
                    cardValueDiamond[i] = "11";
                    cardValueSpades[i] = "11";
                    break;
                    
                case 11:
                    cardValueHearts[i] = "12";
                    cardValueClover[i] = "12";
                    cardValueDiamond[i] = "12";
                    cardValueSpades[i] = "12";
                    break;
                case 12:
                    cardValueHearts[i] = "13";
                    cardValueClover[i] = "13";
                    cardValueDiamond[i] = "13";
                    cardValueSpades[i] = "13";
                    break;
            }
        }
    }
}   
