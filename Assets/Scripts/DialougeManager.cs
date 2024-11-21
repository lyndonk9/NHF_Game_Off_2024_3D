using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this at the top
public class DialougeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI dialougeText;
    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge)
    {
        Debug.Log("Start Test" + dialouge.sentences);

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

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
        //dialougeText.text = sentence;
        Debug.Log(sentence);
    }

    //IEnumerator TypeSentence (string sentence)
    //{
    //    dialougeText.text = "";
    //    foreach (char letter in sentence.ToCharArray()) 
    //    {
    //    dialougeText.text += letter;
    //        yield return null;
    //    }
    //}
    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";
        float typingSpeed = 0.05f; // Adjust this value for the desired speed (e.g., 0.05 seconds per character).

        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialouge() 
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End Text");
    }

}
