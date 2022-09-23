using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerCode : MonoBehaviour
{

    public int Value = 0;
    public int Clean = 100;
    public int Money = 20;
    public int Fame = 0;

    public TMP_Text Value_t;
    public TMP_Text Clean_t;
    public TMP_Text Money_t;
    public TMP_Text Fame_t;

    public TMP_Text Dialogue;
    public GameObject DialogueBox;

    public GameObject storeManager;

    private int ActionCounter = 0;
    private int FameDropAction = 3;

    public bool dialogueShowing = false;

    private void Start()
    {
        DialogueBox = GameObject.Find("Dialogue bg");
        Dialogue = DialogueBox.GetComponentInChildren<TMP_Text>();
        DialogueBox.SetActive(false);
        storeManager = GameObject.Find("StoreManager");
    }

    void Update()
    {
        Value_t.text = "Value " + Value.ToString();
        Clean_t.text = "Clean " + Clean.ToString();
        Money_t.text = "Money " + Money.ToString();
        Fame_t.text = "Fame " + Fame.ToString();

        if(ActionCounter == FameDropAction)
        {
            ActionCounter = 0;
            if (Fame != 0)
            {
                Fame -= 2;
                //dialogue
                DialogueSpeak("It's been a while since you showed up in the public, people are starting to forgetting about you");
            }
        }
        
    }

    public void Action(int type)
    {
        if (!dialogueShowing)
        {

            switch (type)
            {
                case 0://store
                       //enter store mode
                       //display items
                    storeManager.GetComponent<Store>().DisplayItems();

                    //show addition

                    ActionCounter = ActionCounter + 1;

                    break;

                case 1://masqurade
                       //spend money, value* ? = fame gain

                    Money = Money - 200;

                    if (Clean < 25)
                    {
                        DialogueSpeak("You go to the party. But you look like a homeless Gucci with your dirty body. The security kicks you out after a few people complain about your smell. Money - 200.");
                    }
                    else
                    {
                        Fame = Fame + Value * 2;
                        Clean = Clean - 25;

                        //show addition

                        DialogueSpeak("You go to the party. People are slowly recognizing you. Money - 200, Fame +" + Value * 2 + ". But you got sweaty and dirty, Clean - 25");

                        if (ActionCounter != 0) ActionCounter = ActionCounter - 1;

                    }

                    break;

                case 2://work
                       //random money gain * fame
                    int multiplyer = Random.Range(2, 5);
                    Money = Money + 20 + multiplyer * Fame;

                    DialogueSpeak("You work your ass off as a streamer. You gain" + (multiplyer * Fame + 20) + "Money");

                    break;

                case 3://Clean

                    Money -= 25;
                    Clean = 100;

                    DialogueSpeak("You pay a cat to lick you clean. Money - 25, Clean + 100");

                    ActionCounter = ActionCounter + 1;

                    break;

                default:
                    break;

            }

        }

        else
        {
            DialogueBox.SetActive(false);
            dialogueShowing = false;
        }
        
    }

    public void DialogueSpeak(string dd)
    {
        Dialogue.text = dd;
        DialogueBox.SetActive(true);
        dialogueShowing = true;
    }

}
