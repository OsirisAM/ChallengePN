using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TableManager : MonoBehaviour
{
    #region PrimitiveVariables

    #endregion

    #region GameVariables 


    #region GameObjects
    [SerializeField]
    GameObject card;
    [SerializeField]
    GameObject playerHand;
    #endregion

    #region GUI Variable
    [SerializeField]
    Button checkHandButton;
    [SerializeField]
    Button replaceCardButton;
    [SerializeField]
    Button newCardsButton;
    [SerializeField]
    Button resetGameButton;
    [SerializeField]
    Button playAgainButton;
    [SerializeField]
    Text resetingText;
    #endregion

    #region GameObjects And Variables
    [SerializeField]
    CheckHandPointsManager pointsManager;
    [SerializeField]
    PlayerManager playerManager;
    [SerializeField]
    DeckManager deckManager;
    PokerCard cardToPlayer;
    PokerCard cardFromDeck;
    List<GameObject> handOfCards = new List<GameObject>();
    List<Vector3> cardsPosition = new List<Vector3>();
    #endregion

    #endregion

    #region  MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        SetCardsPositions();
        deckManager.SetDeckOfCards();
        //deckManager.PrintDeckInfo();
        SetPlayersHand();
    }
    #endregion

    #region PublicMethods
    public void RestGame()
    {
        foreach(GameObject objects in playerManager.CardsInHand)
        {
            Destroy(objects);
        }
        playerManager.CardsInHand.Clear();
        deckManager.ResetDeck();

        StartCoroutine("WaitProcess");
        SetCardsPositions();
        deckManager.SetDeckOfCards();
        SetPlayersHand();
        checkHandButton.gameObject.SetActive(true);
        replaceCardButton.gameObject.SetActive(true);
        newCardsButton.gameObject.SetActive(false);
        resetGameButton.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
    }
    public void GiveNewCards()
    {
        GameObject newCard;
        for(int i = 0;i < playerManager.NumberOfCardsReturned;i++)
        {
            int randomCard = Random.Range(0,deckManager.DeckCount());
            card = deckManager.GiveCard(randomCard);
            Vector3 newCardVector = cardsPosition[playerManager.HandPosition[i]];
            newCard = Instantiate(card,newCardVector,Quaternion.identity);
            cardToPlayer = newCard.GetComponent<PokerCard>();
            cardFromDeck = card.GetComponent<PokerCard>();

            cardToPlayer.Palo = cardFromDeck.Palo;
            cardToPlayer.Color = cardFromDeck.Color;
            cardToPlayer.Value = cardFromDeck.Value;
            cardToPlayer.SetSprite(cardFromDeck.CardSprite);
            cardToPlayer.SetHandPosition(i);
            cardToPlayer.SetPlayer(playerManager);


            playerManager.AddNewCards(newCard);
        }
        for(int i = 0;i < playerManager.CardsInHand.Count;i++)
        {
            playerManager.CardsInHand[i].transform.position = cardsPosition[i];
            playerManager.CardsInHand[i].transform.SetParent(playerHand.transform);
        }
        playerManager.HandPosition.Clear();

        pointsManager.CheckHand();
        newCardsButton.gameObject.SetActive(false);
        checkHandButton.gameObject.SetActive(false);
        resetGameButton.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }
    #endregion

    #region PrivateMethods
    private void SetPlayersHand()
    {
        int randomCard = 0;
        GameObject tempCard;
        for(int i = 0; i < 5;i++)
        {
            randomCard = Random.Range(0,deckManager.DeckCount());
            card = deckManager.GiveCard(randomCard);
            tempCard = Instantiate(card,cardsPosition[i],Quaternion.identity);
            tempCard.transform.SetParent(playerHand.transform);
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
    private void SetCardsPositions()
    {
        cardsPosition.Add(new Vector3(-3,0,0));
        cardsPosition.Add(new Vector3(-1,0,0));
        cardsPosition.Add(new Vector3(1,0,0));
        cardsPosition.Add(new Vector3(3,0,0));
        cardsPosition.Add(new Vector3(5,0,0));
    }
    IEnumerator WaitProcess()
    {
        resetingText.text = "Reiniciando";
        Debug.Log("Iniciado proceso de reinicio");
        yield return new WaitForSeconds(3f);
        Debug.Log("Termino proceso de reinicio");
        resetingText.text = "";
    }
    #endregion
}
