using System.Collections;
using UnityEngine;

public class HerbInventory : MonoBehaviour
{
    [SerializeField] private HerbTypes[] herbInventory = new HerbTypes[2];
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

        int currentPotion = crafting.FindPotion(herbInventory);
        crafting.BrewPotion(currentPotion, gameObject);

        herbCount = 0;
    }

    public void AddHerb(HerbTypes herb)
    {
        herbInventory[herbCount] = herb;
        herbCount++;
    }
}
