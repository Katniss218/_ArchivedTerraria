#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) {
	if (!Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 25.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 0.44999998807907104)))
    {
	    if (Main.player[playerID].position.Y > ((Main.rockLayer * 15.0)) && Main.player[playerID].position.X < ((Main.rockLayer * 60.0)) && Main.rand.Next(30)==1) return true;
	    if (Main.player[playerID].position.Y > ((Main.rockLayer * 15.0)) && Main.player[playerID].position.X > ((Main.rockLayer * 145.0)) && Main.rand.Next(30)==1) return true;
        return false;
    }
return false;
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0){
    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piscodemon Gore 1", 1f, -1);
    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piscodemon Gore 2", 1f, -1);
    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piscodemon Gore 3", 1f, -1);
    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piscodemon Gore 2", 1f, -1);
    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piscodemon Gore 3", 1f, -1);
    }
}
#endregion