public void AI() {
	
	if (Main.rand.Next(2) == 0) {
		Color color = new Color();
		int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, 0f, 0f, 80, color, 1.5f);
		int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 36, 0f, 0f, 80, color, 1.5f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust2].noGravity = true;
	}
	projectile.AI(true);
}

public void DamageNPC(NPC N, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		Projectile.NewProjectile(N.position.X + (N.width * 0.5f), N.position.Y - 200, 0f, 4f, Config.projDefs.byName["Lightning Bolt"].type, 50, 6, Main.myPlayer);
		Main.PlaySound(2, (int)N.position.X, (int)N.position.Y, SoundHandler.soundID["Thunder"]);
	}
}