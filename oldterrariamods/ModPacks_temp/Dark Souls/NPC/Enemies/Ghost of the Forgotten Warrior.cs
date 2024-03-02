#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{

    if (!Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(2) == 0) return true;

	if (Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(20) == 0) return true;
	
	if (ModWorld.superHardmode && Main.player[playerID].zoneDungeon && Main.rand.Next(100) == 0) return true;

    return false;
}

#endregion

#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wild Warrior Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wild Warrior Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wild Warrior Gore 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wild Warrior Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wild Warrior Gore 3", 1f, -1);
}
}
#endregion