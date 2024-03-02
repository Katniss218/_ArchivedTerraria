public void AI()
{
	if (projectile.velocity.Y < 0)
	{
	projectile.alpha = 200;
	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 200, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	}
	else
	{
	projectile.alpha = 10;
	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	}

	if (projectile.velocity.Y < 10) projectile.velocity.Y += 0.1f;

    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

    if (projrec.Intersects(prec))
    {
    Main.player[Main.myPlayer].AddBuff(39, 300, false);
    Main.player[Main.myPlayer].AddBuff("Freezing", 90, true);
    }
}