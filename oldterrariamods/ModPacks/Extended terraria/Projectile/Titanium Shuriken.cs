public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
	if (Main.rand.Next(2) == 0)
	{
		int a = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Titanium Shuriken"].type, 1, false);
		NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		projectile.active = false;
	}
	projectile.active = false;
}