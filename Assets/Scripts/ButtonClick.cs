using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private DialougeManager dialougeManager;

    public void OnNext(InputValue inputValue)
    {
        dialougeManager.DisplayNextSentence();
    }
}
