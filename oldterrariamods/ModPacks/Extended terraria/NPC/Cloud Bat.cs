public bool SpawnNPC(int x, int y, int playerID) 
{
	if ((Main.player[playerID].position.Y/16f) < 150 && Main.rand.Next(3) == 0)
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
	Gore.NewGore(npc.position, npc.velocity, "Cloud Bat Gore", 1f, -1);
}