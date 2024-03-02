public void DealtNPC(NPC npc, double damage, Player player)
{
	Color color = new Color();
	int dust1 = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 74, 0, 0, 100, color, 1f);
	Main.dust[dust1].noGravity = true;
	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);

	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(39, 60, false);
	}
}