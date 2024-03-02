public bool SpawnNPC(int x, int y, int PID)
{
	if (Main.hardMode)
	{
		if (Main.player[PID].zone["Hellcastle"] && !Main.player[PID].zoneDungeon && !Main.player[PID].zoneMeteor && Main.rand.Next(5) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Gargoyle Head",0.8f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Gargoyle Wing",0.8f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Gargoyle Wing",0.8f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Gargoyle Leg",0.8f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Gargoyle Tail",0.8f,-1);
}