public void UseItem(Player player, int playerID)
{

Main.NewText("A Gate has been opened. The Wall of Flesh has passed into this dimension!... ", 175, 75, 255);
NPC.NewNPC((int)Main.player[Main.myPlayer].position.X-(1070), (int)Main.player[Main.myPlayer].position.Y-150, Config.npcDefs.byName["Wall of Flesh"].type, 1);


}

