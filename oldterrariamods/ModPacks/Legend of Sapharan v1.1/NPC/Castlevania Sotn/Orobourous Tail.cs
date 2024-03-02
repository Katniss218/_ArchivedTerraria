public void AI()
{
	if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		Gore.NewGore(npc.position,npc.velocity,"Orobourous Tail Gore",1.25f,-1);
		npc.active = false;
	}
	npc.AI(true);
}