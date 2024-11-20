using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge = new Dialouge();

    public void TriggerDialouge ()
    {
        FindAnyObjectByType<DialougeManager>().StartDialouge(dialouge);
    }
}
