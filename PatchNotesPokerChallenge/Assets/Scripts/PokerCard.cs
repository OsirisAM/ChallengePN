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
    #endregion
    
    #region GameObjectVariables
    Texture cardTexture;

    [SerializeField]
    PlayerManager playerManager;

    [SerializeField]
    GameObject card ;
    #endregion

    #region AccesMethod

    public bool CardAdded
    {
        get{return cardAdded;}
        set{cardAdded = value;}
    }
    
    #endregion



    #region Methods
    
    public void SetCard(string palo,string color,string value,Texture cardTexture)
    {
        this.palo = palo;
        this.color = color;
        this.value = value;
        this.cardTexture = cardTexture;
    }
    public void SetCard(string palo,string color,string value)
    {
        this.palo = palo;
        this.color = color;
        this.value = value;
        
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
    }
    void OnMouseDown()
    {
        Debug.Log("CardClicked");
        PrintInfo();
        playerManager.SetListToRemove(card);
    }
    #endregion


}
