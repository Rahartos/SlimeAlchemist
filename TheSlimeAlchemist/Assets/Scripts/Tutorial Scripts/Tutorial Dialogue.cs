using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDialogue : MonoBehaviour
{
   public TextMeshProUGUI dialogue;
    public string[] lines;

    private int currentLine = 0;
    private bool dialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        lines = new string[] {
                                "Use the arrow keys to move and spacebar to jump",
                                "Collect your first slime!"
                             };
        dialogue.text = "Welcome to The Slime Alchemist!";
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && dialogueActive){
            if (currentLine < lines.Length)
            {
                dialogue.text = lines[currentLine];
                currentLine++;
            }
            else
            {
                // End of dialogue
                dialogue.text = "";
                dialogueActive = false;
            }
        }
    }

    public void StartDialogue()
    {
        dialogueActive = true;
        currentLine = 0;
    }
}

// change font and textbox