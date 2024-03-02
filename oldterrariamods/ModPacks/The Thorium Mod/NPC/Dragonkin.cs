public static bool SpawnNPC(int x, int y, int playerID) {
	if (!Main.dayTime && Main.player[playerID].townNPCs < 1 && Main.hardMode)
    {
	   if( Main.rand.Next(20)==1) return true;
    return false;
    }
return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Dragonkin Wing L",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dragonkin Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dragonkin Wing R",1f,-1);
}