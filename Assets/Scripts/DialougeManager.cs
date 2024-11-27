using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI dialougeText;  // Reference to the TextMeshPro component for DialogueBox1
    public TextMeshProUGUI dialougeText2;  // Reference to the TextMeshPro component for DialogueBox2
    public Animator animator;  // Animator for DialogueBox1
    public Animator animator2; // Animator for DialogueBox2

    private Queue<string> sentences;  // Queue to store the dialogue sentences
    private bool useSecondBox;        // Flag to indicate if the second dialogue box should be used

    void Start()
    {
        // Initialize the sentence queue and log its state
        sentences = new Queue<string>();
        Debug.Log("Sentences queue initialized: " + (sentences != null));

        // Check if references are assigned
        Debug.Log("dialougeText: " + (dialougeText != null ? "Assigned" : "Missing"));
        Debug.Log("dialougeText2: " + (dialougeText2 != null ? "Assigned" : "Missing"));
        Debug.Log("animator: " + (animator != null ? "Assigned" : "Missing"));
        Debug.Log("animator2: " + (animator2 != null ? "Assigned" : "Missing"));
    }

    // Start a dialogue with the appropriate box based on the 'showSecondBox' parameter
    public void StartDialouge(Dialouge dialouge, bool showSecondBox)
    {
        Debug.Log("StartDialouge called. Using second box: " + showSecondBox);

        // Ensure sentences queue is initialized
        if (sentences == null)
        {
            sentences = new Queue<string>();
            Debug.Log("Sentences queue was null. Initialized it.");
        }

        // Check if Dialouge object is null
        if (dialouge == null)
        {
            Debug.LogError("Dialouge object is null!");
            return;
        }

        // Check if sentences are missing or empty
        if (dialouge.sentences == null || dialouge.sentences.Length == 0)
        {
            Debug.LogError("Dialogue sentences are missing or empty!");
            return;
        }

        // Debug: Log the sentences to ensure they are correctly passed
        Debug.Log("Sentences from Dialogue: " + string.Join(", ", dialouge.sentences));

        // Ensure the animators are properly initialized
        if (animator == null || animator2 == null)
        {
            Debug.LogError("Animator references are missing!");
            return;
        }

        // Check if the Animator components are still valid before calling SetBool
        Debug.Log("Checking Animator status before SetBool:");
        Debug.Log($"Animator 1 Assigned: {animator != null}, Animator 1 Active: {animator.gameObject.activeSelf}");
        Debug.Log($"Animator 2 Assigned: {animator2 != null}, Animator 2 Active: {animator2.gameObject.activeSelf}");


        // Ensure TextMeshProUGUI references are properly initialized
        if (dialougeText == null || dialougeText2 == null)
        {
            Debug.LogError("TextMeshProUGUI references are missing!");
            return;
        }

        if (sentences == null)
        {
            Debug.LogError("Sentences queue is null!");
            return;
        }

        // Log sentences for debugging
        Debug.Log("Clearing the queue...");
        sentences.Clear();
        Debug.Log("Queue size after clearing: " + sentences.Count);

        foreach (string sentence in dialouge.sentences)
        {
            Debug.Log("Enqueuing sentence: " + sentence);
            sentences.Enqueue(sentence);
        }

        Debug.Log("Queue size after enqueuing: " + sentences.Count);

        // Set which dialogue box to show
        animator.SetBool("IsOpen", !showSecondBox);
        animator2.SetBool("IsOpen", showSecondBox);

        useSecondBox = showSecondBox;

        // Start displaying the sentences
        DisplayNextSentence();
    }

    // Display the next sentence in the queue
    public void DisplayNextSentence()
    {
        Debug.Log("Displaying next sentence");

        if (sentences.Count == 0)
        {
            Debug.Log("No more sentences in the queue. Ending dialogue.");
            EndDialouge();  // End dialogue if there are no more sentences
            return;
        }

        // Get the next sentence from the queue
        string sentence = sentences.Dequeue();
        Debug.Log("Next sentence dequeued: " + sentence);

        // Stop any existing typing effect
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));  // Start typing the new sentence
    }

    // Coroutine to type out the sentence
    IEnumerator TypeSentence(string sentence)
    {
        Debug.Log("Typing sentence: " + sentence);

        // Determine which dialogue box to use (Main or Second)
        TextMeshProUGUI currentText = useSecondBox ? dialougeText2 : dialougeText;

        // Check if the TextMeshProUGUI reference is valid
        if (currentText == null)
        {
            Debug.LogError("TextMeshProUGUI reference is missing!");
            yield break;
        }

        // Clear the current text and start typing the new sentence
        currentText.text = "";
        Debug.Log("Cleared text, starting to type...");

        foreach (char letter in sentence.ToCharArray())
        {
            currentText.text += letter;  // Add the letter to the text
            Debug.Log("Added letter: " + letter);
            yield return new WaitForSeconds(0.05f);  // Delay for the typing effect
        }

        Debug.Log("Finished typing sentence: " + currentText.text);
    }

    // End the dialogue
    public void EndDialouge()
    {
        // Hide both dialogue boxes
        animator.SetBool("IsOpen", false);
        animator2.SetBool("IsOpen", false);
        Debug.Log("End of dialogue");

        // Log whether the dialogue boxes are still active
        Debug.Log("Dialouge Box 1 Active (End): " + dialougeText.gameObject.activeSelf);
        Debug.Log("Dialouge Box 2 Active (End): " + dialougeText2.gameObject.activeSelf);
    }
}
