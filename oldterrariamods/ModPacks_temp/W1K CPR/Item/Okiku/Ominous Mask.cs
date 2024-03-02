public void UseItem(Player player, int playerID)
{
Main.NewText("The shadow-born mask has been awakened...", 175, 75, 255);
NPC.NewNPC((int)player.position.X, (int)player.position.Y, Config.npcDefs.byName["Dark Shogun Mask"].type, 0);
}