public bool SpawnNPC(int x, int y, int PID)
{
	if (!ModWorld.superHardmode)
		return false;
		
	
	if (Main.tile[x,y-1].liquid > 0 && Main.rand.Next(2) == 0)  
	
		return true;
	
	else 
		return false;
}




public void DamagePlayer(Player player, ref int damage) //hook works!
{
	if (Main.rand.Next(2) == 0)
	{
		player.AddBuff(21, 3600, false); //potion sickness
	}
    
}




public void AI()
{
	
	npc.AI(true);
}

public void NPCLoot()
{

        Dust.NewDust(npc.position, npc.width, npc.height, 71, 0.3f, 0.3f, 200, default(Color), 1f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 2f);
        Dust.NewDust(npc.position, npc.width, npc.height, 71, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 3f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.width, npc.height, 71, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 71, 0.2f, 0.2f, 200, default(Color), 2f);
}