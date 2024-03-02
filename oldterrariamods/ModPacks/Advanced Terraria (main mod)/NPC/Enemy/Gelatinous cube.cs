public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneDungeon)
    {
	   if( Main.rand.Next(10)==1) return true;
    return false;
    }
return false;
}
public void NPCLoot()
{
	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Sludge", npc.target);
	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Sludge", npc.target);
	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Sludge", npc.target);
	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Sludge", npc.target);
}
