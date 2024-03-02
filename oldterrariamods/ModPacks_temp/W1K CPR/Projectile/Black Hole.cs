public void AI()
{
	if (Main.rand.Next(4) == 0)
	{
		int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 54, 0, 0, 100, Color.White, 2f);
		Main.dust[dust].noGravity = true;
	}
	foreach (Player player in Main.player)
	{
		if (player.active && player.Distance(projectile.Center) < 500)
		{
			float num48 = player.Distance(projectile.Center)/300f; // CHANGE WITH DIST
			Vector2 vector8 = new Vector2(player.Center.X, player.Center.Y);
			float rotation = (float) Math.Atan2(projectile.Center.Y-vector8.Y, projectile.Center.X-vector8.X);
			player.velocity.X += (float)((Math.Cos(rotation) * num48));
			player.velocity.Y += (float)((Math.Sin(rotation) * ((num48*300)/200)));
			player.baseGravity = 0;
			player.maxGravity = 0;
		}
	}
}