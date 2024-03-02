public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneMeteor)
    {
	   if( Main.rand.Next(15)==1) return true;
    return false;
    }
return false;
}

public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Flying Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flying Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flying Body",1f,-1);
}