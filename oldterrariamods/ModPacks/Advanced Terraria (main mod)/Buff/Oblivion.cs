public void NPCEffects(NPC npc)
{
	{
		npc.life = 0;
		npc.NPCLoot();
		npc.active = false;
		Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, npc.soundKilled);
	}
} 