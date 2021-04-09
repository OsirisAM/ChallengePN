using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// Clase del Jugador, para llevar el control de los objetos en mano, los puntos que tienen y las cartas que regresa al Dealer del juego (Table Manager)
    /// </summary>
    #region PrimitiveVariables
    int handSize = 5;
    int pokerPoints = 0;
    int numberOfCardsReturned = 0;
    List<int> handPosition = new List<int>();
    #endregion
    /// <summary>
    /// Variables de juego objectos y objectos de otras clases para acceder a la informacion
    /// necesaria para el juego 
    /// </summary>
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
    /// <summary>
    /// Parte de Unity Engine que toda clase que hereda de  MonoBehaviour 
    /// </summary>
    #region MonoBehaviour
    private void Update() {
        if(pokerPoints > 0)
        {
            pointsText.text = pokerPoints.ToString();
        }    
    }
    #endregion
    /// <summary>
    /// Metodos de acceso a todas las variables o encapsulacion
    /// por conceptos de programacion orientada a objetos
    /// </summary>
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
    /// <summary>
    /// Siguiendo el concepto de programacion orientada a objetos toda
    /// clase es la simplicacion de un objeto real, en este caso es 
    /// la simplicacion de las acciones que puede tener un jugador 
    /// como Regresar las cartas que el jugador selecciono y agregar nuevas 
    /// cartas que el dealer del juego da
    /// </summary>
    #region Player Actions

    public void ReturnCards()
    {
        if (selectedCards.Count == 0)
            return;
        numberOfCardsReturned = selectedCards.Count;
        for(int i = 0; i < numberOfCardsReturned;i++)
        {
            cardsInHand.Remove(selectedCards[i]);
            deckManager.ReturnCard(selectedCards[i]);
            selectedCards[i].SetActive(false);
            Destroy(selectedCards[i]);
        }
        replaceCardButton.gameObject.SetActive(false);
        newCardButton.gameObject.SetActive(true);
    }

    public void AddNewCards(GameObject newCard)
    {
        cardsInHand.Add(newCard);
        selectedCards.Clear();
    }

    #endregion
    /// <summary>
    /// Metodos para el funcionamiento del juego como seleccionar y de seleccionar
    /// </summary>
    /// <param name="card"></param>
    #region Methods

    public void DeSelectCard(GameObject card)
    {
        Vector3 tempPosition = new Vector3(0, 1, 0);
        card.transform.position -= tempPosition;
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = false;
        handPosition.Remove(cardManager.HandPosition);
        selectedCards.Remove(card);
    }
    public void SelectCard(GameObject card)
    {
        Vector3 tempPosition = new Vector3(0,1,0);
        card.transform.position += tempPosition;
        cardManager = card.GetComponent<PokerCard>();
        cardManager.CardAdded = true;
        handPosition.Add(cardManager.HandPosition);
        if(selectedCards.Count < 3)
        {
            selectedCards.Add(card);
        }
        else
        {
            return;
        }
    }
    #endregion

}
