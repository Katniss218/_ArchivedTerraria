//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
static Player player;
public static void StatusNPC(Player player, NPC npc)
{
    player.inventory[player.selectedItem].damage = (player.statLife);
}

public static void UseItem(Player player, int playerID)
{
    player.inventory[player.selectedItem].damage = (player.statLife);
    Lighting.addLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.5f, 0.5f, 1.0f);
}