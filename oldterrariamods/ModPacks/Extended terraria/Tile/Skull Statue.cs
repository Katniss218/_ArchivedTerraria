//bool spawned = false;
int CD = 0;
public void hitWire(int x, int y)
{
	//if (CD > 0) return;
	if (Main.tile[x, y].type == (ushort)Config.tileDefs.ID["Skull Statue"])
	{
		NPC.NewNPC(x*16, y*16, (int)(Config.npcDefs.byName["Cursed Skull 2"].type), 0);
		CD = 90;
	}
}
public void Update()
{
	if (--CD < 0) CD = 0;
}