public void AI()
{
	if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		npc.active = false;
	}
	npc.AI(true);
}