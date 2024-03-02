
public void AI()
{
    Projectile P = projectile;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    if(P.wet)P.Kill();
    int DustIndex = Dust.NewDust(
    new Vector2(P.position.X + P.velocity.X, P.position.Y + P.velocity.Y), 
    P.width, 
    P.height, 
    57, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, default(Color), 1f);
    Main.dust[DustIndex].noGravity = true;
    P.rotation = (float)Math.Atan2((double)P.velocity.Y, (double)P.velocity.X) + (float)(Math.PI/2);
}

public void Kill()
{
	if (Main.rand.Next(6) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Fallen Star", 1, false, 0);
	}
	for (int l = 0; l < 10; l++)
	{
		Color newColor = default(Color);
		Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, newColor, 1.2f);
	}
	for (int m = 0; m < 3; m++)
	{
		Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
	}
	if (projectile.owner == Main.myPlayer)
	{
		float x = projectile.position.X + (float)Main.rand.Next(-400, 400);
		float y = projectile.position.Y - (float)Main.rand.Next(600, 900);
		Vector2 vector = new Vector2(x, y);
		float num5 = projectile.position.X + (float)(projectile.width / 2) - vector.X;
		float num6 = projectile.position.Y + (float)(projectile.height / 2) - vector.Y;
		int num7 = 22;
		float num8 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
		num8 = (float)num7 / num8;
		num5 *= num8;
		num6 *= num8;
		int num9 = projectile.damage;
		num9 = (int)((float)num9 * 0.5f);
		int num10 = Projectile.NewProjectile(x, y, num5, num6, 92, num9, projectile.knockBack, projectile.owner);
		Main.projectile[num10].ai[1] = projectile.position.Y;
		Main.projectile[num10].ai[0] = 1f;
	}
	projectile.active = false;
}