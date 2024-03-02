public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneDungeon)
    {
	   if( Main.rand.Next(20)==1) return true;
    return false;
    }
return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Darksteel body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Darksteel Legs",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Shambler Head",1f,-1);
	
}

public static void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff("Sunder", 180, false);
		//player.AddBuff(23, 180, false);
	}
}