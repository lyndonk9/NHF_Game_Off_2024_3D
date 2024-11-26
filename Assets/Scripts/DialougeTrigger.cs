using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge = new Dialouge();

    public void TriggerDialouge(bool showSecondBox)  // Accept the bool parameter to control DialogueBox2
    {
        // Find the DialogueManager and pass both the Dialogue object and the bool
        FindAnyObjectByType<DialougeManager>().StartDialouge(dialouge, showSecondBox);
    }
}