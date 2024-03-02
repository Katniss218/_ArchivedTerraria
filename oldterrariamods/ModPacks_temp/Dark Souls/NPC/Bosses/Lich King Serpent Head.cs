bool TailSpawned = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;
	if (Main.hardMode) 
	{
	if (underworld || undergroundEvil)
	{
	if (Main.rand.Next(800) == 0)
	{
	return true;
	}
	}
	}
	return false;
}

public void AI()
{
	npc.AI(true);
	if (!TailSpawned)
	{
	int Previous = npc.whoAmI;
	for (int num36 = 0; num36 < 44; num36++)
	{
		int lol = 0;
		if (num36 >= 0 && num36 < 43)
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.width/2), "Lich King Serpent Body", npc.whoAmI);
		}
		else
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.width/2), "Lich King Serpent Tail", npc.whoAmI);
		}
		Main.npc[lol].realLife = npc.whoAmI;
		Main.npc[lol].ai[2] = (float)npc.whoAmI;
		Main.npc[lol].ai[1] = (float)Previous;
		Main.npc[Previous].ai[0] = (float)lol;
		NetMessage.SendData(23, -1, -1, "", lol, 0f, 0f, 0f, 0);
		Previous = lol;
	}
	TailSpawned = true;
	}
}
public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Head Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Body Gore", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Tail Gore", 1f, -1);
}
}
