public bool AccCheck(Player player, int slot) {
	for (int i = 3; i <= 7; i++) if (player.armor[i].type == item.type) return false;
	for (int i = 0; i < ModGeneric.extraSlots; i++) if (ModWorld.slots.itemSlots[i].type == item.type) return false;
	return true;
}
public void Initialize()
{
	Main.colorRarity[7] = new float[3] { 250f, 250f, 100f };
	Main.colorRarity[8] = new float[3] { 110f, 255f, 48f };
	//Config.itemDefs.byName["Cisgemhibyashoo Bar"].rare = 7;
}
public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	if (ModPlayer.HasBuff("Pierce"))
	{
		int a = Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner);
		if (Main.projectile[a].penetrate > 0)
		{
			Main.projectile[a].penetrate++;
		}
		//Main.projectile[Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner)].penetrate++;
	}
	return !ModPlayer.HasBuff("Pierce");
}