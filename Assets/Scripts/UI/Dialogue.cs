using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool dialogueInProgress = false;
    private Component imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; //Makes sure the textcomponent is empty on scene start
        imageComponent = GetComponent<Image>();
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
        if (Input.GetMouseButtonDown(0) && dialogueInProgress)
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
        Debug.Log("Dialogue started");
        imageComponent.GetComponent<Image>().enabled = true;
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
            imageComponent.GetComponent<Image>().enabled = false;
            textComponent.text = string.Empty;
            dialogueInProgress = false;
        }
    }
}
