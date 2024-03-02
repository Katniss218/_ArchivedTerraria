public void UseItem(Player player, int playerID)
{  
NPC.SpawnOnPlayer(playerID, "Mechanical Phoenix");
NPC.SpawnOnPlayer(playerID, "Mechanical Jungix");
NPC.SpawnOnPlayer(playerID, "Mechanical Aquatix");
}

public bool CanUse(Player player,int PlayerID)
{
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Mechanical Phoenix"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Mechanical Jungix"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    for (int num36 = 0; num36 < 200; num36++)
	{
	    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Mechanical Aquatix"].type)
	    {
            player.Hurt(9001+player.statDefense, 1, false, true, " was slain...", true);
            return false;
	    }
	}
    item.stack--;
    if(item.stack <= 0) item = new Item();
    return true;
}