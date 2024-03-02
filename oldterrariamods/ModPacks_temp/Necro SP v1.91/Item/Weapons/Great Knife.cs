
static Player player;
public static void StatusNPC(Player player, NPC npc)
{
    player.inventory[player.selectedItem].damage = (player.statLife);
}

public static void UseItem(Player player, int playerID)
{
    player.inventory[player.selectedItem].damage = (player.statLife);
}