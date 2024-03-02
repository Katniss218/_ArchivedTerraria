public void AI()
{
	projectile.AI(true);
}

public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
	if (Main.rand.Next(0) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Toxic Hilt"].type, 1, false);
		projectile.active = false;
	}
	projectile.active = false;
}

public void PreKill(){
Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 40, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 53, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, 0, 0, 0, default(Color), 1f);
}
