public void UseItem(Player player, int playerID)
{
Main.NewText("You are a fool, Red. You think you can defeat me?...", 175, 75, 255);
NPC.NewNPC((int)player.position.X, (int)player.position.Y, Config.npcDefs.byName["Dark Shogun Mask"].type, 0);
}