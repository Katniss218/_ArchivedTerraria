public void Effects(Player P) //, int buffIndex, int buffType, int buffTime)
{
	P.lifeRegenTime = 0;
	P.lifeRegen = -11;
	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(P.position, P.width -20, P.height, 54, 0f, 0f, 100, new Color(), 1f);
		Main.dust[dust].noGravity = true;

		int dust2 = Dust.NewDust(P.position, P.width - 20, P.height, 58, 0f, 0f, 100, new Color(), 1f);
		Main.dust[dust2].noGravity = true;
	}
}

public void NPCEffects(NPC N) //, int buffIndex, int buffType, int buffTime)
{
	N.lifeRegen = -17;

	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(N.position, N.width / 2, N.height / 2, 54, 0f, 0f, 100, new Color(), 1f);
		Main.dust[dust].noGravity = true;

		int dust2 = Dust.NewDust(N.position, N.width / 2, N.height / 2, 58, 0f, 0f, 100, new Color(), 1f);
		Main.dust[dust2].noGravity = true;
	}
}