public void PostAI()
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 16, 0, 0, 100, color, 0.8f);
	Main.dust[dust].noGravity = true;
	}

public void PreKill()
	{
	Main.PlaySound(16, (int)projectile.position.X, (int)projectile.position.Y, 1);
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2(projectile.position.X - 4f, projectile.position.Y), projectile.width + 8, projectile.height +8, 16, -projectile.velocity.X * 0.5f, projectile.velocity.Y * 2.0f, 100, default(Color), 1.5f);
	Main.dust[dust].noGravity = true;
	int gore = Gore.NewGore(new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y + (projectile.height * 0.5f)), new Vector2(projectile.velocity.X * .25f, projectile.velocity.Y * .25f), Main.rand.Next(11, 14), 0.8f);
	}