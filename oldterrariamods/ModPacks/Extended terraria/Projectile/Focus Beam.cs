/*public void AI()
{
	if (projectile.type == Config.projDefs.byName["Focus Beam"].type)
	{
		int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
		Main.dust[num40].noGravity = true;
		if (Main.rand.Next(10) == 0)
		{
			num40 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
		}
	}
}*/
public bool tileCollide(Vector2 CollideVel)
{
	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
	projectile.ai[0] += 1f;
	if (projectile.ai[0] >= 2f)
	{
		projectile.position += projectile.velocity;
		projectile.Kill();
	}
	else
	{
		if (projectile.type == Config.projDefs.byName["Focus Beam"].type && projectile.velocity.Y > 4f)
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y * 0.8f;
			}
		}
		else
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y;
			}
		}
		if (projectile.velocity.X != CollideVel.X)
		{
			projectile.velocity.X = -CollideVel.X;
		}
	}
	return false;
}