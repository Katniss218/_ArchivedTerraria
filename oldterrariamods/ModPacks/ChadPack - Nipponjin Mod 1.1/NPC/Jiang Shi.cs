float customAi1;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
	if (!Main.dayTime && Main.hardMode && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor)
    {
        if (Main.rand.Next(10)==1) return true;
        return false;
    }
    return false;
}
#endregion

public void NPCLoot ()
{


	Gore.NewGore(npc.position,npc.velocity,"Jiang Shi 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Jiang Shi 2",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Jiang Shi 2",1f,-1);



}