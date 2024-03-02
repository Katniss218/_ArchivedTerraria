public void NPCLoot()
{
	for (int i = 0; i < 3; i++)
	{
		NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Dark Matter Slime", npc.target);
		NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Dark Matter Slime", npc.target);
		NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, "Dark Matter Slime", npc.target);
	}
}