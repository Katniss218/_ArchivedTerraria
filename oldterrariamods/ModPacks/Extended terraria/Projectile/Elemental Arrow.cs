public void AI()
{
	projectile.AI(true);
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Dark Inferno", 540);
	}
	if (Main.rand.Next(5) == 0)
	{
		npc.AddBuff("Freeze", 120);
	}
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff(20, 600);
	}
	if (Main.rand.Next(5) == 0)
	{
		npc.AddBuff(24, 600);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(4) == 0)
	{
		enemyPlayer.AddBuff("Dark Inferno", 540, false);
	}
	if (Main.rand.Next(5) == 0)
	{
		enemyPlayer.AddBuff("Freeze", 120, false);
	}
	if (Main.rand.Next(4) == 0)
	{
		enemyPlayer.AddBuff(20, 540, false);
	}
	if (Main.rand.Next(5) == 0)
	{
		enemyPlayer.AddBuff(24, 600, false);
	}
}
public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
	if (Main.rand.Next(2) == 0)
	{
		int a = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Elemental Arrow"].type, 1, false);
		NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		projectile.active = false;
	}
	/*int randomNum = Main.rand.Next(3);
	if (randomNum == 0)
	{
		int a = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Elemental Arrow"].type, 1, false);
		NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		projectile.active = false;
	}
	else if (randomNum == 2)
	{
		int a = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Wooden Arrow"].type, 1, false);
		NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		projectile.active = false;
	}*/
	projectile.active = false;
}