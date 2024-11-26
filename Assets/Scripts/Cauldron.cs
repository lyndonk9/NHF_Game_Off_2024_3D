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
        //{ "purplepotion", new List<string>() {"redpotion", "bluepotion"} }
         // Base combinations
    { "purplepotion", new List<string>() { "redpotion", "bluepotion" } },
    { "greenpotion", new List<string>() { "yellowpotion", "bluepotion" } },
    { "orangepotion", new List<string>() { "redpotion", "yellowpotion" } },
    
    // New potions created by combining the base results
    { "rainbowpotion", new List<string>() { "purplepotion", "greenpotion", "orangepotion" } },
    { "cyanpotion", new List<string>() { "bluepotion", "greenpotion" } },
    { "magenta", new List<string>() { "purplepotion", "redpotion" } },
    { "sunshinepotion", new List<string>() { "orangepotion", "yellowpotion" } },
    
    // Secondary-level combinations
    { "ultraviolet", new List<string>() { "purplepotion", "cyanpotion" } },
    { "forestbrew", new List<string>() { "greenpotion", "yellowpotion" } },
    { "sunsetelixir", new List<string>() { "orangepotion", "purplepotion" } },
    { "aquapotion", new List<string>() { "cyanpotion", "bluepotion" } },
    { "firestormpotion", new List<string>() { "orangepotion", "redpotion" } },
    { "goldbrew", new List<string>() { "sunshinepotion", "yellowpotion" } },
    
    // Final result (combining advanced potions)
    { "ultimatepotion", new List<string>() { "rainbowpotion", "ultraviolet", "goldbrew" }}
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

    //public void MixPotion()
    //{
    //    if (ingredients.Count > 0)
    //    {
    //        foreach(KeyValuePair<string, List<string>> recipe in recipes)
    //        {
    //            List<string> recipeCopy = new List<string>(recipe.Value);
    //            PrintList(recipeCopy);  // debugging code

    //            ingredients.ForEach(item =>
    //            {
    //                recipeCopy.Remove(item);
    //            });

    //            PrintList(recipeCopy);

    //            if (recipeCopy.Count > 0)
    //            {
    //                textPrompt.GetComponent<TMP_Text>().text = "Recipe Failed.";
    //            }
    //            else
    //            {
    //                textPrompt.GetComponent<TMP_Text>().text = "Recipe Success: " + recipe.Key + " was created!";
    //                dialogueTrigger.TriggerDialouge(); // Call the function from DialogueTrigger
    //            }
    //        }
    //        ingredients.Clear();
    //    }
    //}

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
