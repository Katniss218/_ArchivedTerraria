public void NPCEffects(NPC N)
{
	N.lifeRegen = -15;
	Rectangle npc1 = ModGeneric.NewRect(N);
	for (int i = 0; i < Main.npc.Length; i++)
	{
		NPC N2 = Main.npc[i];
		if (N2.townNPC || N2.friendly) continue;
		Rectangle npc2 = ModGeneric.NewRect(N2);
		if (npc2.Intersects(npc1)) N2.AddBuff("Inferno", 540);
	}

	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(N.position, N.width / 2, N.height / 2, 64, 0f, 0f, 100, new Color(), 1f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].OverrideTexture = Main.goreTexture[Config.goreID["Magmatic Dust"]];
		Main.dust[dust].frame = new Rectangle(0,0,10,10);
	}
}
