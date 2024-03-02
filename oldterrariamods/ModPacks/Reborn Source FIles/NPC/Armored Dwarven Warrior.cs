public static bool SpawnNPC(int x, int y, int playerID) {
	if (!Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 35.0)))
    {
	if (Main.player[playerID].position.X > ((Main.worldSurface * 130.0)) && Main.rand.Next(100)==1) return true;
	else if (Main.player[playerID].position.Y > ((Main.rockLayer*10)) && Main.player[playerID].position.Y < ((Main.rockLayer * 30.0)) && Main.player[playerID].position.X > ((Main.rockLayer * 100.0)) && Main.rand.Next(15)==1) return true;
	return false;
    }
return false;
}

public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
}
}