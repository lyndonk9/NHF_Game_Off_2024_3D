using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Cauldron : MonoBehaviour
{
    //text prompt object
    [SerializeField] GameObject textPrompt;

    public List<string> ingredients = new List<string>();

    private List<List<string>> recipes = new List<List<string>>()
    {
        new List<string>() {"redpotion", "bluepotion"}
    };

    public void AddItem(string potionKey)
    {
        ingredients.Add(potionKey);

        // printing the list for debugging
        Debug.Log("ingredients:");
        PrintList(ingredients);
    }

    public void MixPotion()
    {
        if (ingredients.Count > 0)
        {
            recipes.ForEach(recipe =>
            {
                List<string> recipeCopy = new List<string>(recipe);
                PrintList(recipeCopy);

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
                    textPrompt.GetComponent<TMP_Text>().text = "Recipe Success!";
                }
            });
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
