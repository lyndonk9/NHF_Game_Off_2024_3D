using UnityEngine;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    public List<string> ingredients = new List<string>();

    public void AddItem(string potionKey)
    {
        ingredients.Add(potionKey);

        // printing the list for debugging
        string ingredientsString = "ingredients: ";
        ingredients.ForEach(ingredient =>
        {
            ingredientsString += ingredient + ", ";
        });
        Debug.Log(ingredientsString);
    }
}
