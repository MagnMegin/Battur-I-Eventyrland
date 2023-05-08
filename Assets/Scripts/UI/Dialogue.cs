using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public CharacterInfo characterInfo;
    public string[] lines;
    public float textSpeed;
    public event Action onDialogueOver;

    private string characterName;
    private int index;
    private bool dialogueInProgress = false;
    private Component rightImageComponent; //This is the background of the text
    private Component leftImageComponent;

    // Start is called before the first frame update
    void Start()
    {
        lines = characterInfo.lines;
        characterName = characterInfo.characterName;

        textComponent.text = string.Empty; //Makes sure the textcomponent is empty on scene start

        rightImageComponent = GetComponent<Image>();
        leftImageComponent = GetComponent<Image>();

        InputManager.Scheme = InputManager.ControlScheme.Menu;
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
            if(textComponent.text == lines[index])
            {
                NextLine();
            }

            //If the current line is still being written out, complete it.
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        //Debug.Log("Dialogue started");
        leftImageComponent.GetComponent<Image>().enabled = true;
        rightImageComponent.GetComponent<Image>().enabled = true;
        StartCoroutine(TypeLine());
        dialogueInProgress = true;
    }

    IEnumerator TypeLine() //The aim of this coroutine is to make the text appear one letter after the other
    {
        //This foreach loop breaks all text down to their own letters
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() //Completes the sentence being written out or sets the textbox to inactive if there is no more text.
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else //Disables the textbox and clears the text
        {
            leftImageComponent.GetComponent<Image>().enabled = false;
            rightImageComponent.GetComponent<Image>().enabled = false;
            textComponent.text = string.Empty;
            dialogueInProgress = false;
            onDialogueOver?.Invoke();
        }
    }
}
