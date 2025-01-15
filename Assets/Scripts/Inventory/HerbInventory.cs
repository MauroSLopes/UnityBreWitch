using System.Collections;
using UnityEngine;

public class HerbInventory : MonoBehaviour
{
    [SerializeField] private HerbTypes[] herbInventory = new HerbTypes[2];
    [SerializeField] private GameObject tinyPlayerGameObject;
    [SerializeField] private GameObject[] obstaclesPrefabs;
    private CraftingOrder crafting;
    private int herbCount = 0;

    private void Start()
    {
        crafting = GetComponent<CraftingOrder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(herbCount == 2))
        {
            return;
        }

        herbCount = 0;

        int currentPotion = crafting.FindPotion(herbInventory);
        crafting.BrewPotion(currentPotion, gameObject, tinyPlayerGameObject, obstaclesPrefabs);

    }

    public void AddHerb(HerbTypes herb)
    {
        if (herbCount >= 2)
        {
            return;
        }
        
        herbInventory[herbCount] = herb;
        herbCount += 1;
    }
}
