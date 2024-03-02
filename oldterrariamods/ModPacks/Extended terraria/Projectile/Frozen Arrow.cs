public void AI()
{
	projectile.AI(true);
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff("Freeze", 540);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff("Frozen", 120, false);
	}
}
public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
	if (Main.rand.Next(2) == 0)
	{
		int a = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, Config.itemDefs.byName["Frozen Arrow"].type, 1, false);
		NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		projectile.active = false;
	}
	projectile.active = false;
}