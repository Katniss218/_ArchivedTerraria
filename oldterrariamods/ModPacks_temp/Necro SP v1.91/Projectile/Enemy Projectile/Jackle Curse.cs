
public void AI()
{
    Main.player[Main.myPlayer].AddBuff(31, 180, false);
    projectile.rotation += 0.2f;
	
	if (Main.player[(int)projectile.ai[0]].position.X < projectile.position.X)
	{
	if (projectile.velocity.X > -6) projectile.velocity.X -= 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.X > projectile.position.X)
	{
	if (projectile.velocity.X < 6) projectile.velocity.X += 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.Y < projectile.position.Y)
	{
	if (projectile.velocity.Y > -6) projectile.velocity.Y -= 0.05f;
	}

	if (Main.player[(int)projectile.ai[0]].position.Y > projectile.position.Y)
	{
	if (projectile.velocity.Y < 6) projectile.velocity.Y += 0.05f;
	}
}

