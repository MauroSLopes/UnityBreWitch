public class CraftingRecipes
{
    public static HerbTypes[,] craftingRecipes = {
        { HerbTypes.Sugarcane, HerbTypes.Sugarcane }, // Sugarcane + Sugarcane = MoveSpeed
        { HerbTypes.Sugarcane, HerbTypes.Cinnamon }, // Sugarcane + Cinnamon = Get Smow LMAO
        { HerbTypes.Sugarcane, HerbTypes.Mint }, // Sugarcane  + Mint = Slippery Ground
        { HerbTypes.Sugarcane, HerbTypes.Ginger }, // Sugarcane + Ginger = Enemy MoveSpeed
        { HerbTypes.Sugarcane, HerbTypes.Clove }, // Sugarcane + Clove = Spawn Obstacles
        { HerbTypes.Cinnamon, HerbTypes.Cinnamon}, // Cinnamon + Cinnamon = Shield
        { HerbTypes.Cinnamon, HerbTypes.Mint}, // Cinnamon + Mint = Self Slow
        { HerbTypes.Cinnamon, HerbTypes.Ginger}, // Cinnamon + Ginger = Enemys Flee
        { HerbTypes.Cinnamon, HerbTypes.Clove}, // Cinnamon + Clove = No Collision
        { HerbTypes.Mint, HerbTypes.Mint }, // Mint + Mint = Stops Enemys
        { HerbTypes.Mint, HerbTypes.Ginger }, // Mint + Ginger = Slow Enemy
        { HerbTypes.Mint, HerbTypes.Clove }, // Mint + Clove = Destroy Rocks
        { HerbTypes.Ginger, HerbTypes.Ginger }, // Ginger + Ginger = Kill All Enemys
        { HerbTypes.Ginger, HerbTypes.Clove }, // Ginger + Clove= Destroy Tree
        { HerbTypes.Clove, HerbTypes.Clove }, // Clove + Clove = Destroy All Objects
    };
}
