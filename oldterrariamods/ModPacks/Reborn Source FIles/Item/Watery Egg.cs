public void UseItem(Player player, int playerID)
{  
NPC.SpawnOnPlayer(playerID, "Aquatix");
}

public bool CanUse(Player player,int PlayerID)
{
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Aquatix"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    
   bool zoneJ = (player.position.X < 250*16 || player.position.X > (Main.maxTilesX - 250)*16);
    if(!zoneJ) Main.NewText("You can only use this in the Ocean!");
    if(zoneJ) item.stack--;
    if(item.stack <= 0) item = new Item();
	return zoneJ;
}