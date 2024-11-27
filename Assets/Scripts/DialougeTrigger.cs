using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge = new Dialouge();
    public bool autoStart = false; // Add a toggle to auto-start dialogue

    private void Start()
    {
        if (autoStart)
        {
            TriggerDialouge(false); // Trigger DialougeBox at start (false = main box)
        }
    }

    public void TriggerDialouge(bool showSecondBox)
    {
        // Find the DialogueManager using the new FindFirstObjectByType method
        DialougeManager dialogueManager = FindFirstObjectByType<DialougeManager>();

        if (dialogueManager != null)
        {
            dialogueManager.StartDialouge(dialouge, showSecondBox);
        }
        else
        {
            Debug.LogError("DialougeManager not found in the scene!");
        }
    }
}
