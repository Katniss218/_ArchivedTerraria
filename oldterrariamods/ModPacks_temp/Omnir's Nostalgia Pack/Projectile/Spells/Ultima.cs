#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 13)
	{                       
		projectile.Kill();                          
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), 0, 0, "Ultima Explosion", (int) ((500 + (Main.player[projectile.owner].statManaMax2/5)) * (Main.player[projectile.owner].magicDamage)), 8f, projectile.owner);
		return;
	}
	{
		if (projectile.ai[1] == 0f)
		{
			projectile.ai[1] = 1f;
			projectile.netUpdate = true;
		}
	}
	if (projectile.soundDelay == 0)
	{
		projectile.soundDelay = 20 + Main.rand.Next(40);
		Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
	}
	if (projectile.localAI[0] == 0f)
	{
		projectile.localAI[0] = 1f;
	}
	projectile.alpha += (int)(25f * projectile.localAI[0]);
	if (projectile.alpha > 200)
	{
		projectile.alpha = 200;
		projectile.localAI[0] = -1f;
	}
	if (projectile.alpha < 0)
	{
		projectile.alpha = 0;
		projectile.localAI[0] = 1f;
	}
	projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.01f * (float)projectile.direction;
	if (projectile.ai[1] == 1f || projectile.type == 92)
	{
		projectile.light = 0.9f;
		if (Main.rand.Next(10) == 0)
		{
			Vector2 arg_1328_0 = projectile.position;
			int arg_1328_1 = projectile.width;
			int arg_1328_2 = projectile.height;
			int arg_1328_3 = 58;
			float arg_1328_4 = projectile.velocity.X * 0.5f;
			float arg_1328_5 = projectile.velocity.Y * 0.5f;
			int arg_1328_6 = 150;
			Color newColor = default(Color);
			Dust.NewDust(arg_1328_0, arg_1328_1, arg_1328_2, arg_1328_3, arg_1328_4, arg_1328_5, arg_1328_6, newColor, 1.2f);
		}
		if (Main.rand.Next(20) == 0)
		{
			Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
			return;
		}
	}
}
#endregion


