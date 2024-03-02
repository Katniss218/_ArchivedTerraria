public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneDungeon && Main.hardMode)
    {
	   if( Main.rand.Next(10)==1) return true;
    return false;
    }
return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Flayer Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Dragon Skeleton Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flayer Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flayer Arm",1f,-1);
}