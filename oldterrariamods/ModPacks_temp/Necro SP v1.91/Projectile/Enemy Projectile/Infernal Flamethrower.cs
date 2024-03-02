int alphaParticle = 0;

public void AI()
{
	projectile.scale += 0.04f;
	alphaParticle += 3;
	if (Main.rand.Next(4) == 0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, alphaParticle, Color.White, projectile.scale*2f);
	Main.dust[dust].noGravity = true;
	}
	if (projectile.timeLeft <= 2 && alphaParticle >= 255) projectile.active = false;
}