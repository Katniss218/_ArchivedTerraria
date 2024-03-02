public bool CanUse(Player player, int pID)
{
	bool use = true;
	for (int j = 0; j < 50; j++)
	{
		if (Main.npc[j].type == 22 && Main.npc[j].active)
		{
			use = false;
		}
		else
		{
			use = true;
		}
	}
	return use;
}
public void UseItem(Player player, int playerID)
{
	NPC.NewNPC(Main.spawnTileX, (int)(Main.topWorld + 400f), 22, 0);
	Main.NewText("The Guide has arrived!", 0, 148, 255);
}