public void Effects(Player P) //, int buffIndex, int buffType, int buffTime)
{
	P.lifeRegenTime = 0;
	P.lifeRegen = -11;
	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(P.position, P.width / 2, P.height / 2, 54, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, new Color(), 1f);
		Main.dust[dust].noGravity = true;

		int dust2 = Dust.NewDust(P.position, P.width / 2, P.height / 2, 58, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, new Color(), 1f);
		Main.dust[dust2].noGravity = true;
	}
}

public void NPCEffects(NPC N) //, int buffIndex, int buffType, int buffTime)
{
	N.lifeRegen = -17;

	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(N.position, N.width / 2, N.height / 2, 54, (N.velocity.X * 0.2f) + (N.direction * 3), N.velocity.Y * 0.2f, 100, new Color(), 1f);
		Main.dust[dust].noGravity = true;

		int dust2 = Dust.NewDust(N.position, N.width / 2, N.height / 2, 58, (N.velocity.X * 0.2f) + (N.direction * 3), N.velocity.Y * 0.2f, 100, new Color(), 1f);
		Main.dust[dust2].noGravity = true;
	}
}