using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance;

    public TextMeshProUGUI dialogueTextComponent;
    public TextMeshProUGUI rightCharacterNameTextbox;
    public CharacterInfo rightCharacterInfo;
    public Image rightCharacterPicture;
    public GameObject dialogueCanvas;
    public float textSpeed;
    public event Action onDialogueOver;
    public event Action onDialogueStart;

    public string[] lines;

    private int index;
    private bool dialogueInProgress = false;

    #region Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InputManager.CurrentScheme = InputManager.ControlScheme.Menu; //Sets control scheme to menu controls
    }

    // Update is called once per frame
    void Update()
    {
        //This is to skip the sentence being written out letter for letter, or to skip to the next sentence.
        if (InputManager.MenuSelectDown() && dialogueInProgress)
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

    public void StartDialogue(CharacterInfo info)
    {
        gameObject.SetActive(true);
        CleanUpDialogue(); //Readies dialogue UI for use
        LoadRightCharacterInfo(info); //Loads info name, lines pic, etc.

        
        dialogueInProgress = true;
        StartCoroutine(TypeLine());

        onDialogueStart?.Invoke();
    }

    IEnumerator TypeLine() //This makes the dialogue text appear one letter after the other
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
            CleanUpDialogue();
            EndDialogue();
            dialogueInProgress = false;
        }
    }

    void LoadRightCharacterInfo(CharacterInfo info)
    {
        lines = info.lines;
        rightCharacterNameTextbox.text = info.characterName;
        rightCharacterPicture.sprite = info.characterDialogueSprite;
    }

    void CleanUpDialogue() //Readies dialogue UI for use
    {
        index = 0;
        dialogueTextComponent.text = string.Empty; //Makes sure the textcomponent is empty on scene start
        //dialogueCanvas.SetActive(false); //Makes sure the dialogue canvas is disabled on scene load.
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
        onDialogueOver?.Invoke();
    }
}