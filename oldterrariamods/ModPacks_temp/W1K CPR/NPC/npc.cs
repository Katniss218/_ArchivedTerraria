public void NPCLoot()
{
	if (Config.syncedRand.Next(100) == 0 && npc.value > 0 && (npc.type == 49 || npc.type == 51 || npc.type == 60 || npc.type == 93 || npc.type == 137))
	{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, "Companion Bat");
	}
}