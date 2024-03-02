public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.snowTiles >= 10 && !Main.dayTime)
					{

	   if( Main.rand.Next(5)==1) return true;
		return false;
		}
	return false;
    }
	
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Snow Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Snow Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Snow Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Snow Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Snow Head",1f,-1);
}