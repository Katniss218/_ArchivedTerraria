public void Kill()
{
	if (projectile.type == Config.projDefs.byName["Crystal Shot"].type)
	{
		Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
		for (int num11 = 0; num11 < 5; num11++)
		{
        Color color = new Color();
	    int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y-10), projectile.width, projectile.height, 67, 0, 0, 100, color, 1.0f);
	    Main.dust[dust].noGravity = true;
		}
		if (projectile.type == Config.projDefs.byName["Crystal Shot"].type && projectile.owner == Main.myPlayer)
		{
			for (int num13 = 0; num13 < 3; num13++)
			{
				float num14 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
				float num15 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
				Projectile.NewProjectile(projectile.position.X + num14, projectile.position.Y + num15, num14, num15, Config.projDefs.byName["Crystal Fragment"].type, (int)((double)projectile.damage * 0.6), 0f, projectile.owner);
			}
			projectile.active = false;
		}
		projectile.active = false;
	}
}