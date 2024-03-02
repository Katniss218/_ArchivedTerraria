public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.hardMode)
	{
		if (Main.player[playerID].zoneHoly && !Main.player[playerID].zoneDungeon && y > (Main.rockLayer + 70) && y < (Main.maxTilesY - 200) && Main.rand.Next(8) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(6) == 0)
	{
		player.AddBuff(23, 180, false);
	}
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Mime Head",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mime Arm",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mime Arm",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mime Leg",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mime Leg",1.3f,-1);
}