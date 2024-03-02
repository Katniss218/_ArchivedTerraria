public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(4) == 0) //25% chance to occur
	{
		npc.AddBuff(24, 300, false);
	}
}

public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, color, 1.0f);
	Main.dust[dust].noGravity = true;
	if (projectile.wet)
	{
	projectile.Kill();
	}
}