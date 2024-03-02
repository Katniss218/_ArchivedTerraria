public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode || ModWorld.superHardmode)
	{
		if (Main.player[playerID].townNPCs < 1 && Main.evilTiles >= 50 && Main.tile[x,y-1].liquid > 0 && y > Main.rockLayer - 30 && Main.rand.Next(5) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}


public void DamagePlayer(Player player, ref int damage) //hook works!
{

	if (Main.rand.Next(4) == 0)
	{
                
		player.AddBuff(1, 1800, false); //obsidian skin
        	player.AddBuff(30, 3600, false); //bleeding
                
	}
    
}





public void AI()
{
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Frozen"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	npc.AI(true);
}