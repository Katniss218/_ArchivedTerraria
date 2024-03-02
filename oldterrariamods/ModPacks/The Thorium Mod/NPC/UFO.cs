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
	Gore.NewGore(npc.position,npc.velocity,"Alien",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"UFO piece 2",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"UFO piece 1",1f,-1);
}