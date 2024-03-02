public bool SpawnNPC(int x, int y, int playerID) 
{
	if ((Main.player[playerID].position.Y/16f) < 150 && Main.hardMode && Main.rand.Next(5) == 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

public void DamagePlayer(Player player, ref int damage) //hook works!
{

	if (Main.rand.Next(8) == 0)
	{
                
		player.AddBuff(31, 600, false); //confused
                
	}
    
}



public void NPCLoot()
{
	Gore.NewGore(npc.position, npc.velocity, "Cloud Bat Gore", 1f, -1);
}