public void AI()
{
	projectile.AI(true);

	projectile.rotation++;
	if (projectile.rotation == 360f)
	{
		projectile.rotation = 0f;
	}
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
	Main.dust[dust].noGravity = true;
}

public void PreKill()
{
	int x = (int)(projectile.position.X / 16f);
	int y = (int)(projectile.position.Y / 16f);
	WorldGen.PlaceTile(x, y, 58);
	if (Main.netMode == 2)
	{
		NetMessage.SendTileSquare(-1, x, y, 3);
	}
}