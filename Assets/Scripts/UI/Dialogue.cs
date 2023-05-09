using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextComponent;
    public TextMeshProUGUI rightCharacterName;
    public CharacterInfo rightCharacterInfo;
    public float textSpeed;
    public event Action onDialogueOver;
    public GameObject dialogueCanvas;
    public Image rightCharacterPicture;
    public string[] lines;


    private int index;
    private bool dialogueInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadRightCharacterInfo();
        dialogueTextComponent.text = string.Empty; //Makes sure the textcomponent is empty on scene start
        dialogueCanvas.SetActive(false); //Makes sure the dialogue canvas is disabled on scene load.
        InputManager.Scheme = InputManager.ControlScheme.Menu; //Sets control scheme to menu controls
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.MenuSelectDown() && !dialogueInProgress)
        {
            StartDialogue();
        }

        //This is to skip the sentence being written out letter for letter, or to skip to the next sentence.
        else if (InputManager.MenuSelectDown() && dialogueInProgress)
        {
            //If the current line is finished typing, run this
            if(dialogueTextComponent.text == lines[index])
            {
                NextLine();
            }

            //If the current line is still being written out, complete it.
            else
            {
                StopAllCoroutines();
                dialogueTextComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        dialogueCanvas.SetActive(true);
        StartCoroutine(TypeLine());
        dialogueInProgress = true;
    }

    IEnumerator TypeLine() //The aim of this coroutine is to make the text appear one letter after the other
    {
        yield return new WaitForSeconds(0.2f);
        //This foreach loop breaks all text down to their own letters
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() //Completes the sentence being written out or sets the textbox to inactive if there is no more text.
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueTextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else //Disables the dialogue canvas
        {
            dialogueCanvas.SetActive(false);
            dialogueTextComponent.text = string.Empty;
            dialogueInProgress = false;
            onDialogueOver?.Invoke();
        }
    }

    void LoadRightCharacterInfo()
    {
        lines = rightCharacterInfo.lines;
        rightCharacterName.text = rightCharacterInfo.characterName;
        rightCharacterPicture.sprite = rightCharacterInfo.characterDialogueSprite;
    }
}