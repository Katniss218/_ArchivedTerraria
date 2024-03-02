public void UseItem(Player player, int playerID)
{
	
        NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Serris Head"].type);
	Main.PlaySound(15,(int)player.position.X,(int)player.position.Y,0);
}