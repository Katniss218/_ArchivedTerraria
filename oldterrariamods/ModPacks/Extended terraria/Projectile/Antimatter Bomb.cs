public void Kill()
{
	ModWorld.ExplodeCircle((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 20);
	/*int fx = (int)((projectile.position.X / 16f) - 20f);
	int lx = (int)((projectile.position.Y / 16f) + 20f);
	int fy = (int)((projectile.position.X / 16f) - 20f);
	int ly = (int)((projectile.position.Y / 16f) + 20f);
	foreach (Player P in Main.player)
	{
		Rectangle player = new Rectangle((int)P.position.X, (int)P.position.Y, P.width, P.height);
		Rectangle explosion = new Rectangle(fx, fy, lx, ly);
		if (player.Intersects(explosion))
		{
			P.Hurt(700, P.direction, false, false, " was vaporized...");
		}
	}*/
	projectile.active = false;
}