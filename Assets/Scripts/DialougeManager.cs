using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this at the top

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI dialougeText;
    public TextMeshProUGUI dialougeText2;   // For DialogueBox2
    public Animator animator;   // For DialogueBox
    public Animator animator2;  // For DialogueBox2

    private Queue<string> sentences;
    private bool useSecondBox; // Track which dialogue box is being used

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Start a dialogue with the appropriate box based on the 'showSecondBox' parameter
    public void StartDialouge(Dialouge dialouge, bool showSecondBox)
    {
        Debug.Log("Start Test: " + dialouge.sentences);

        animator.SetBool("IsOpen", !showSecondBox);
        animator2.SetBool("IsOpen", showSecondBox);

        useSecondBox = showSecondBox;  // Store whether to use the second box

        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Display the next sentence in the queue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    // Coroutine to type out the sentence
    IEnumerator TypeSentence(string sentence)
    {
        // Check which dialogue box to use (Main or Second)
        TextMeshProUGUI currentText = useSecondBox ? dialougeText2 : dialougeText;

        if (currentText == null)
        {
            Debug.LogError("TextMeshProUGUI reference is missing!");
            yield break;
        }

        // Clear the text before typing it out
        currentText.text = "";

        // Log that the typing process started
        Debug.Log("Typing sentence: " + sentence);

        // Loop through each character in the sentence and display it with a delay
        foreach (char letter in sentence.ToCharArray())
        {
            currentText.text += letter;  // Add the letter to the text
            yield return new WaitForSeconds(0.05f);  // Delay for the typing effect
        }

        // Log when typing is finished
        Debug.Log("Finished typing sentence: " + currentText.text);
    }


    // End the dialogue
    public void EndDialouge()
    {
        animator.SetBool("IsOpen", false);   // Hide DialogueBox (main)
        animator2.SetBool("IsOpen", false);  // Hide DialogueBox2 (secondary)
        Debug.Log("End Text");
    }
}
