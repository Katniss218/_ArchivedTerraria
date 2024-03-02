#region AI
public void AI()
{
    if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
    {
	    projectile.soundDelay = 10;
	    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
    }
    Vector2 arg_2675_0 = new Vector2(projectile.position.X, projectile.position.Y);
    int arg_2675_1 = projectile.width;
    int arg_2675_2 = projectile.height;
    int arg_2675_3 = 15;
    float arg_2675_4 = 0f;
    float arg_2675_5 = 0f;
    int arg_2675_6 = 100;
    Color newColor = default(Color);
    int num47 = Dust.NewDust(arg_2675_0, arg_2675_1, arg_2675_2, arg_2675_3, arg_2675_4, arg_2675_5, arg_2675_6, newColor, 2f);
    Dust expr_2684 = Main.dust[num47];
    expr_2684.velocity *= 0.3f;
    Main.dust[num47].position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
    Main.dust[num47].position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-4, 5);
    Main.dust[num47].noGravity = true;
	if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
	{
		projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
	}
	if (projectile.velocity.Y > 16f)
	{
		projectile.velocity.Y = 16f;
		return;
	}
}
#endregion

#region Kill
public void Kill()
{
	if (!projectile.active)
	{
		return;
	}
	projectile.timeLeft = 0;
    {
		Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width/2), projectile.position.Y + (float)(projectile.height/2), 0, 0, "Enemy Spell Flare", 200, 3f, projectile.owner);
		Vector2 arg_1394_0 = new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y);
		int arg_1394_1 = projectile.width;
		int arg_1394_2 = projectile.height;
		int arg_1394_3 = 15;
		float arg_1394_4 = 0f;
		float arg_1394_5 = 0f;
		int arg_1394_6 = 100;
		Color newColor = default(Color);
		int num41 = Dust.NewDust(arg_1394_0, arg_1394_1, arg_1394_2, arg_1394_3, arg_1394_4, arg_1394_5, arg_1394_6, newColor, 2f);
		Main.dust[num41].noGravity = true;
		Dust expr_13B1 = Main.dust[num41];
		expr_13B1.velocity *= 2f;
		Vector2 arg_1422_0 = new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y);
		int arg_1422_1 = projectile.width;
		int arg_1422_2 = projectile.height;
		int arg_1422_3 = 15;
		float arg_1422_4 = 0f;
		float arg_1422_5 = 0f;
		int arg_1422_6 = 100;
		newColor = default(Color);
		num41 = Dust.NewDust(arg_1422_0, arg_1422_1, arg_1422_2, arg_1422_3, arg_1422_4, arg_1422_5, arg_1422_6, newColor, 1f);
	}
	projectile.active = false;
}
#endregion
