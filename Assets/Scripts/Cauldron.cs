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
         // Level 2
        { "10", new List<string>() { "1", "2" } },
        { "20", new List<string>() { "1", "3", "5" } },
        { "30", new List<string>() { "4", "5" } },
    
        // Level 3
        { "100", new List<string>() { "10", "3" } },
        { "200", new List<string>() { "2", "20", "5" } },
        { "300", new List<string>() { "4", "30" } },

        // Final result (combining advanced potions)
        { "1000", new List<string>() { "100", "200", "300", "1" }}
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
            bool recipeFound = false;

            foreach (KeyValuePair<string, List<string>> recipe in recipes)
            {
                List<string> recipeCopy = new List<string>(recipe.Value);

                ingredients.ForEach(item =>
                {
                    recipeCopy.Remove(item);
                });

                if (recipeCopy.Count == 0)
                {
                    textPrompt.GetComponent<TMP_Text>().text = "Recipe Success: " + recipe.Key + " was created!";
                    Debug.Log("Recipe Success: " + recipe.Key);

                    recipeFound = true;
                    // Trigger success dialogue and show DialogueBox2
                    dialogueTrigger.TriggerDialouge(true);
                    break;
                }
            }

            if (!recipeFound)
            {
                textPrompt.GetComponent<TMP_Text>().text = "Recipe Failed.";
                Debug.Log("Recipe Failed.");
                // Trigger failure dialogue and show DialogueBox2
                dialogueTrigger.TriggerDialouge(false);
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
