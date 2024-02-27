using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDialogue : MonoBehaviour
{
   public TextMeshProUGUI dialogue;
    public string[] lines;

    private int currentLine = 0;
    private bool initalDialogue = false;
    private bool secondDialogue = false;

    private string[] initialLines = {   "You are a slime in a petri dish!",
                                "Use the arrow keys to move and spacebar to jump...",
                                "... and the little flags are the respawning points!",
                                "Collect your first slime!"
                             };

    private string[] metSlimeLines = {  "You collected your first slime: Oxygen!",
                                "To put out the fire below, go to the shop and buy another Hydrogen slime...",
                                "To make a compound, water!"
                            };

// Start is called before the first frame update
void Start()
    {
        dialogue.text = "Welcome to The Slime Alchemist!";   
        StartDialogue();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && initalDialogue)
        {
            if (currentLine < initialLines.Length)
            {
                dialogue.text = initialLines[currentLine];
                currentLine++;
            }
            else
            {
                // End of dialogue
                dialogue.text = "";
                initalDialogue = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && secondDialogue)
        {
            if (currentLine < metSlimeLines.Length)
            {
                dialogue.text = metSlimeLines[currentLine];
                currentLine++;
            }
            else
            {
                // End of dialogue
                dialogue.text = "";
                secondDialogue = false;
            }
        }

    }

    public void StartDialogue()
    {
        initalDialogue = true;
        currentLine = 0;
    }

    public void MetSlime()
    {
        secondDialogue = true;
        currentLine = 0;
    }
}

// change font and textbox