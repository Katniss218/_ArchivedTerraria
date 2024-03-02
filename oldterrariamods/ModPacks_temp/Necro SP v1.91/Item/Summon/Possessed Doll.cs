public void UseItem(Player player, int playerID)
{  
NPC.SpawnOnPlayer(playerID, "Devil Doll");
}

public bool CanUse(Player player,int PlayerID)
{
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Devil Doll"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    
    double num16 = (double)(Main.maxTilesY - 230);
    double num17 = (double)((int)((num16 - Main.worldSurface) / 6.0) * 6);
    num16 = Main.worldSurface + num17 - 5.0;
	bool underworld= (player.position.Y > num16*16);
    if(!underworld) Main.NewText("You can only use this in Hell");
    if(underworld) item.stack--;
    if(item.stack <= 0) item = new Item();
	return underworld;
}