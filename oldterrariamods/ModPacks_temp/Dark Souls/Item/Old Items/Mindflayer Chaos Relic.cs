

public static void UseItem(Player player, int playerID) {

NPC.NewNPC((int)player.position.X-700, (int)player.position.Y-500, Config.npcDefs.byName["Blight"].type, 1);
Main.NewText("You will be destroyed");
}

