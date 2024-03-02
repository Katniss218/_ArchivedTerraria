public void UseItem(Player player, int playerID)
{  
NPC.SpawnOnPlayer(playerID, "Jungix");
}

public bool CanUse(Player player,int PlayerID)
{
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Jungix"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    
   bool zoneJ = player.zoneJungle;
    if(!zoneJ) Main.NewText("You can only use this in the Jungle!");
    if(zoneJ) item.stack--;
    if(item.stack <= 0) item = new Item();
	return zoneJ;
}