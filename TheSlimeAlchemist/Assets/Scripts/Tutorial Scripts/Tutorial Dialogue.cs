using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDialogue : MonoBehaviour
{
   public TextMeshProUGUI dialogue;

    private int currentLine = 0;
    private bool initalDialogue = false;
    private bool secondDialogue = false;


    private string[] initialLines = {   "You are a slime in a petri dish!",
                                "Use the arrow keys to move and spacebar to jump...",
                                "... and the little flags are the respawning points!",
                                "Collect your first slime!"
                             };

    private string[] metSlimeLines = {  "To put out the fire below, go to the shop and buy another Hydrogen slime...",
                                "To make a compound, water!"
                            };

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Debug.Log("Found player: " + player.name);
        }
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

        if(player.GetComponent<Player>() != null && player.GetComponent<Player>().metOxy)
        {
            MetSlime();
            dialogue.text = "You collected your first slime: Oxygen!";
            player.GetComponent<Player>().metOxy = false;

        }

        if (Input.GetKeyDown(KeyCode.Z) && secondDialogue)
        {
            if (currentLine < metSlimeLines.Length)
            {
                // Debug.Log("following texts...");
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
        // Debug.Log("currentLine: " + currentLine + ", metSlimesLines: " + metSlimeLines.Length);
    }
}

// change font and textbox