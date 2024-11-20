using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge)
    {
        Debug.Log("Start Test" + dialouge.sentences);
    }

}
