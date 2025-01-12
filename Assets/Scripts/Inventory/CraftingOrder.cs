using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CraftingOrder : MonoBehaviour
{
    private PotionBehaviour potionManager;
    public int FindPotion(HerbTypes[] inventoryHerbs)
    {
        HerbTypes[,] craftingRecipes = CraftingRecipes.craftingRecipes;

        HerbTypes[] invertedInventory =
        {
            inventoryHerbs[1],
            inventoryHerbs[0]
        };

        List<HerbTypes> currentRecipe = new List<HerbTypes>(2); 

        for (int i = 0; i < craftingRecipes.GetLength(0); i++)
        {
            for (int j = 0; j < craftingRecipes.GetLength(1); j++)
            {
                currentRecipe.Add(craftingRecipes[i, j]);
            }

            if (currentRecipe[0] == inventoryHerbs[0] && currentRecipe[1] == inventoryHerbs[1])
            {
                Debug.Log(craftingRecipes[i,0] + " " + craftingRecipes[i,1]);
                return i;
            }

            if (currentRecipe[0] == invertedInventory[0] && currentRecipe[1] == invertedInventory[1])
            {
                Debug.Log(craftingRecipes[i, 0] + " " + craftingRecipes[i, 1]);
                return i;
            }

            currentRecipe.Clear();
        }

        return -1;
    }

    public void BrewPotion(int currentPotion, GameObject PlayerGameObject)
    {
        if (currentPotion == -1)
        {
            return;
        }

        potionManager = new PotionBehaviour(PlayerGameObject);
        switch (currentPotion)
        {
            case 0:
                // Player Bonus Movespeed
                StartCoroutine(potionManager.TemporaryMovespeed(20f, 5f, 0));
                Debug.Log("Found it");
                break;
            case 1:
                // Tiny player
                // Change Prefab for X seconds.
                break;
            case 2:
                // Slippery Ground
                
                break;
            case 3:
                // Enemy Bonus MoveSpeed 
                StartCoroutine(potionManager.TemporaryMovespeed(10f, 5f, 1));
                Debug.Log("Found it");
                break;
            case 4:
                // Spawn Obstacles
                break;
            case 5:
                // Shield
                break;
            case 6:
                // Self Slow
                StartCoroutine(potionManager.TemporaryMovespeed(2f, 5f, 0));
                break;
            case 7:
                // Enemys run from player
                potionManager.ChangeEnemySpeed(-10f);
                foreach(var enemy in potionManager.GetEnemys())
                {
                    enemy.GetComponent<BoxCollider2D>().enabled = false;
                }
                break;
            case 8:
                // No Collision with obstacles
                break;
            case 9:
                // Freeze Enemys in Place
                StartCoroutine(potionManager.TemporaryMovespeed(0f, 5f, 1));
                break;
            case 10:
                // Slow Enemys
                StartCoroutine(potionManager.TemporaryMovespeed(2f, 5f, 1));
                break;
            case 11:
                // Destroy Rocks
                break;
            case 12:
                // Kill All Enemys
                break;
            case 13:
                // 
                break;
            case 14:
                // 
                break;
            default:
                Debug.Log("Not Found");
                break;
        }

    }
		
}
