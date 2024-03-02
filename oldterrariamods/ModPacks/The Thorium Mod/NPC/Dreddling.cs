public bool SpawnNPC(int x, int y, int playerID) 
{
	if (y > Main.maxTilesY - 200 && Main.hardMode && Main.rand.Next(20) == 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}
public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Dredd Hand",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dredd Hand",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dredd Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dredd Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dredd Leg",1f,-1);
}