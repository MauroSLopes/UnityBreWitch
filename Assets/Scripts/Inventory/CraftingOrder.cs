using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingOrder : MonoBehaviour
{
    public static int currentPotion;
    public static void FindPotion(HerbTypes[] inventoryHerbs)
    {
        HerbTypes[,] craftingRecipes = CraftingRecipes.craftingRecipes;
        HerbTypes[] invertedInventory =
        {
            inventoryHerbs[1],
            inventoryHerbs[0]
        };

        for (int i = 0; i < craftingRecipes.GetLength(0); i++) {
            HerbTypes[] currentRecipe = new HerbTypes[2];

            for (int j = 0; j < craftingRecipes.GetLength(1); j++)
            {
                currentRecipe[j] = craftingRecipes[i, j];
            }

            if (inventoryHerbs[0] == currentRecipe[0] || invertedInventory[0] == currentRecipe[0])
            {
                if (inventoryHerbs[1] == currentRecipe[1] || invertedInventory[1] == currentRecipe[1])
                {
                    currentPotion = i;
                }
            }
        }
    }

    public static void BrewPotion()
    {
        switch (currentPotion)
        {
            case 1:
                // Aumenta o movespeed
                
                break;
        }
    }
		
}
