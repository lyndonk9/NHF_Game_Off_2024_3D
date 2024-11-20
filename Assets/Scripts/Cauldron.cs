using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Cauldron : MonoBehaviour
{
    //text prompt object
    [SerializeField] GameObject textPrompt;
    [SerializeField] private DialougeTrigger dialogueTrigger; // Reference to DialogueTrigger component

    public List<string> ingredients = new List<string>();

    private Dictionary<string, List<string>> recipes = new Dictionary<string, List<string>>()
    {
        { "purplepotion", new List<string>() {"redpotion", "bluepotion"} }
    };

    public void AddItem(string potionKey)
    {
        ingredients.Add(potionKey);

        // printing the list for debugging
        Debug.Log("ingredients:");
        PrintList(ingredients);
    }

    private void Awake()
    {
        // Get the DialogueTrigger component attached to the same GameObject
        if (dialogueTrigger == null)
        {
            dialogueTrigger = GetComponent<DialougeTrigger>();
        }
    }

    public void MixPotion()
    {
        if (ingredients.Count > 0)
        {
            foreach(KeyValuePair<string, List<string>> recipe in recipes)
            {
                List<string> recipeCopy = new List<string>(recipe.Value);
                PrintList(recipeCopy);  // debugging code

                ingredients.ForEach(item =>
                {
                    recipeCopy.Remove(item);
                });

                PrintList(recipeCopy);

                if (recipeCopy.Count > 0)
                {
                    textPrompt.GetComponent<TMP_Text>().text = "Recipe Failed.";
                }
                else
                {
                    textPrompt.GetComponent<TMP_Text>().text = "Recipe Success: " + recipe.Key + " was created!";
                    dialogueTrigger.TriggerDialouge(); // Call the function from DialogueTrigger
                }
            }
            ingredients.Clear();
        }
    }

    private void PrintList(List<string> list)
    {
        string listString = "";
        list.ForEach(item =>
        {
            listString += item + ", ";
        });
        Debug.Log(listString);
    }
}
