public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light, projectile.light * 0.8f, projectile.light * 0.6f);
	}
	int num10 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num10].noGravity = true;
		Main.dust[num10].scale *= 2f;
	}
	int num11 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num11].noGravity = true;
		Main.dust[num11].scale *= 2f;
	}
	projectile.AI(true);
}

public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(24, 300);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff(24, 300, false);
	}
}