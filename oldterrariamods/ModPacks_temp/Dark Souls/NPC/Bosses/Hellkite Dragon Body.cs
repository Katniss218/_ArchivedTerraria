public void AI()
{
	if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		NPCLoot();
		npc.active = false;
	}
	npc.AI(true);
}

public void NPCLoot()
{

npc.netUpdate = true;
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Hellkite Dragon Body Gore", 1f, -1);

}
}