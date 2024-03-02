public void AI()
{
	projectile.AI(true);
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 11, 0, 0, 100, color, 1f);
	Main.dust[dust].noGravity = true;

	projectile.rotation++;

	if (projectile.rotation == 360f)
	{
		projectile.rotation = 0f;
	}
}

public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	npc.AddBuff(24, 60, false);
}

public void DamagePlayer(ref int damage, Player player)
{
	player.AddBuff(24, 60, false);
}