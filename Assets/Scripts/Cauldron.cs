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
        { "Powerful Elixir", new List<string>() { "1", "2" } },
        { "Ocean potion", new List<string>() { "1", "3", "5" } },
        { "Fairy wings", new List<string>() { "4", "5" } },
    
        // Level 3
        { "100", new List<string>() { "Powerful Elixir", "3" } },
        { "200", new List<string>() { "2", "Ocean Potion", "5" } },
        { "300", new List<string>() { "4", "Fairy Wings" } },

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
                    textPrompt.GetComponent<TMP_Text>().text = "Meowow,I did it!!! Recipe Success: " + recipe.Key + " was created!";
                    Debug.Log("Recipe Success: " + recipe.Key);

                    recipeFound = true;
                    // Trigger success dialogue and show DialogueBox2
                    dialogueTrigger.TriggerDialouge(true);
                    break;
                }
            }

            if (!recipeFound)
            {
                textPrompt.GetComponent<TMP_Text>().text = "Oops, meow bad Meow ay ay Recipe Failed.";
                Debug.Log("Recipe Failed.");
                // Trigger failure dialogue and show DialogueBox2
                dialogueTrigger.TriggerDialouge(true);
            }

            ingredients.Clear();
        }
    }
    //public void MixPotion()
    //{
    //    if (ingredients.Count > 0)
    //    {
    //        bool recipeFound = false;

    //        foreach (KeyValuePair<string, List<string>> recipe in recipes)
    //        {
    //            List<string> recipeCopy = new List<string>(recipe.Value);

    //            ingredients.ForEach(item =>
    //            {
    //                recipeCopy.Remove(item);
    //            });

    //            if (recipeCopy.Count == 0)
    //            {
    //                string successText = "Recipe Success: " + recipe.Key + " was created!";
    //                textPrompt.GetComponent<TMP_Text>().text = successText;
    //                Debug.Log(successText);

    //                recipeFound = true;
    //                // Trigger success dialogue with custom text in DialogueBox2
    //                dialogueTrigger.TriggerDialouge(true, successText);
    //                break;
    //            }
    //        }

    //        if (!recipeFound)
    //        {
    //            string failureText = "Recipe Failed.";
    //            textPrompt.GetComponent<TMP_Text>().text = failureText;
    //            Debug.Log(failureText);

    //            // Trigger failure dialogue with custom text in DialogueBox2
    //            dialogueTrigger.TriggerDialouge(true, failureText);
    //        }

    //        ingredients.Clear();
    //    }
    //}



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