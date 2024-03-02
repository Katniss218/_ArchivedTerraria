public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.snowTiles >= 5)
					{

	   if( Main.rand.Next(5)==1) return true;
    return false;
    }
return false;
}

#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Snow Owl Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Snow Owl Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Snow Owl Gore 3", 1f, -1);
}
}
#endregion