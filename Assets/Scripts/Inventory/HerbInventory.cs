using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbInventory : MonoBehaviour
{
    public HerbTypes[] herbInventory = new HerbTypes[2];
    public static int herbCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (!(herbCount == 2))
        {
            return;
        }

        CraftingOrder.FindPotion(herbInventory);
        herbCount = 0;
    }

    IEnumerator SpeedCountdown(float speedModifier)
    {
        PlayerMovement.playerSpeed = speedModifier;
        yield return new WaitForSeconds(5f);
        PlayerMovement.playerSpeed = 5f;
    }
}
