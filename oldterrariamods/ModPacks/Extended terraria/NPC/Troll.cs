public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.hardMode)
	{
		if (Main.player[playerID].zoneEvil && y > (Main.rockLayer + 30) && y < (Main.maxTilesY - 200) && Main.rand.Next(21) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(10) == 0)
	{
		player.AddBuff(36, 10800, false);
	}
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Troll Head",1.4f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Troll Arm",1.4f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Troll Bone",0.8f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Troll Bone",0.8f,-1);
}