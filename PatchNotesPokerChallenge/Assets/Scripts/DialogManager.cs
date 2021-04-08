using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    List<string> Sentences = new List<string>();
    [SerializeField]
    Text dialogOfInstructions;
    [SerializeField]
    Button continueButton;
    [SerializeField]
    Image dialogBox;
    int start = 0;
    int end = 2;
    private void Start()
    {
        SetDialog();
        for (int i = start; i <= end; i++)
        {
            dialogOfInstructions.text += Sentences[i];
        }
    }

    public void OnClickNextDialogue()
    {
        start = 3;
        end = 5;
        dialogOfInstructions.text = "";
        for (int i = start ;i <= end;i++)
        {
            dialogOfInstructions.text += Sentences[i];
        }
        StartCoroutine("ClearDialogBox");
    }
    private void SetDialog()
    {
        Sentences.Add("Welcome to Poker Challenge the rules are simple \n");
        Sentences.Add("you will handed a hand of poker with  \n");
        Sentences.Add("5 cards, you can selecte up to 3 to change them");

        Sentences.Add("And replace them with new cards to archive one \n");
        Sentences.Add("many poker hands and earn points after that \n ");
        Sentences.Add("you can start a new game or continue your win streak \n");
    }
    IEnumerator ClearDialogBox()
    {

        yield return new WaitForSeconds(4f);
        continueButton.gameObject.SetActive(false);
        dialogOfInstructions.gameObject.SetActive(false);
        dialogBox.gameObject.SetActive(false);
    }
}
