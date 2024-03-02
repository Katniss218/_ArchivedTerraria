public void AI()
{
	npc.AI(true);
	if (npc.life > (int)(npc.lifeMax / 2))
	{
		//Main.musicBox = 13;
		if (Main.rand.Next(60) == 0)
		{
			float Speed = 12f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			int damage = 50;
			Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
		}
		if (Main.rand.Next(2000) == 0)
		{
			NPC.NewNPC((int)npc.position.X, (int)(npc.position.Y + 100f), 98, 0);
		}
	}
	else
	{
		if (Main.rand.Next(3000) == 0)
		{
			NPC.NewNPC((int)npc.position.X, (int)(npc.position.Y + 100f), Config.npcDefs.byName["Mechanical Digger Head"].type, npc.target);
		}
		if (Main.rand.Next(2000) == 0)
		{
			NPC.NewNPC((int)npc.position.X, (int)(npc.position.Y), 139, 0);
		}
	}
}
public void NPCLoot()
{
	NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, "Oblivion Phase 1 Dead", 0);
}