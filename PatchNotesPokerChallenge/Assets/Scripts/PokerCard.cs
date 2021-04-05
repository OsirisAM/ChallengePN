using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCard : MonoBehaviour
{
    #region Primitive Variables
    string palo = "";

    string color = "";

    string value = "";

    bool cardAdded = false;

    int handPosition = 0;

    int numberInHand = 0 ;
    #endregion
    
    #region GameObjectVariables
    SpriteRenderer cardSpriteRenderer;
    Sprite cardSprite;
    [SerializeField]
    PlayerManager playerManager;

    [SerializeField]
    GameObject card;

    #endregion

    #region AccesMethod

    public string Palo
    {
        get{return palo;}
        set{palo = value;}
    }

    public string Color 
    {
        get{return color;}
        set{color = value;}
    }

    public string Value 
    {
        get{return value;}
        set{this.value = value;}
    }

    public bool CardAdded
    {
        get{return cardAdded;}
        set{cardAdded = value;}
    }
    public int NumberInHand 
    {
        get{return numberInHand;}
        set{numberInHand = value;}
    }
    public int HandPosition
    {
        get{return handPosition;}
    }
    public Sprite CardSprite 
    {
        get{return cardSprite;}
    }
    #endregion


    #region Methods
    
    public void SetCard(string palo,string color,string value,Sprite cardSprite)
    {
        this.palo = palo;
        this.color = color;
        this.value = value;

        this.cardSpriteRenderer = card.GetComponent<SpriteRenderer>();
        this.cardSpriteRenderer.sprite = cardSprite;
        this.cardSprite = cardSpriteRenderer.sprite;
    }
    public void SetCard(string palo,string color,string value)
    {
        this.palo = palo;
        this.color = color;
        this.value = value;
    }
    public void SetHandPosition(int handPosition)
    {
        this.handPosition = handPosition;
    }
    public void SetSprite(Sprite cardSprite)
    {
        this.cardSpriteRenderer = card.GetComponent<SpriteRenderer>();
        this.cardSpriteRenderer.sprite = cardSprite;
        this.cardSprite = cardSpriteRenderer.sprite;

    }
    public void SetPlayer(PlayerManager pm)
    {
        playerManager = pm;
    }
    public void PrintInfo()
    {
        Debug.Log(palo+"\n");
        Debug.Log(color+"\n");
        Debug.Log(value+"\n");
        Debug.Log(cardAdded);
        Debug.Log(handPosition.ToString());
    }
    void OnMouseDown()
    {
        PrintInfo();
        if(!cardAdded)
            playerManager.SelectCard(card);
        else
            playerManager.DeSelectCard(card);
    }
    #endregion


}
