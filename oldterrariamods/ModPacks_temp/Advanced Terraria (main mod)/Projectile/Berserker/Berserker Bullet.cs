public void Kill()
{
	if (projectile.type == Config.projDefs.byName["Berserker Bullet"].type)
	{
		Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
		for (int num11 = 0; num11 < 5; num11++)
		{
			int num12 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 65, 0f, 0f, 100, default(Color), 1.2f);
			Main.dust[num12].noGravity = true;
			Main.dust[num12].velocity *= 1.5f;
			Main.dust[num12].scale *= 0.9f;
			Main.dust[num12].OverrideTexture = Main.goreTexture[Config.goreID["Berserker Dust"]]; //Custom Dust
			Main.dust[num12].frame = new Rectangle(0,0,10,10);
			/*int D = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 58, 0f, 0f, 0, default(Color), 1f);
			Main.dust[D].noGravity = true;
			Main.dust[D].velocity *= 1.5f;
			Main.dust[D].scale *= 0.9f;*/
		}
		if (projectile.type == Config.projDefs.byName["Berserker Bullet"].type && projectile.owner == Main.myPlayer)
		{
			for (int num13 = 0; num13 < 3; num13++)
			{
				float num14 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
				float num15 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
				Projectile.NewProjectile(projectile.position.X + num14, projectile.position.Y + num15, num14, num15, Config.projDefs.byName["Berserker Crystal"].type, (int)((double)projectile.damage * 0.6), 0f, projectile.owner);
			}
			projectile.active = false;
		}
		projectile.active = false;
	}
}