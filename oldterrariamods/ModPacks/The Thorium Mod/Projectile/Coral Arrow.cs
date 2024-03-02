public void AI()
{
	projectile.AI(true);
}

public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
	if (Main.rand.Next(2) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Coral Arrow"].type, 1, false);
		projectile.active = false;
	}
	projectile.active = false;
}

public void PreKill(){
Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 73, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 28, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 73, 0, 0, 0, default(Color), 1f);
}
