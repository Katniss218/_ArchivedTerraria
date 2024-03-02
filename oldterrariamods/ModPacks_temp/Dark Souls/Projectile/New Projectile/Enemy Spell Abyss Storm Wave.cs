public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, 0f, 80, color, 2f);
	Main.dust[dust].noGravity = false;
	projectile.AI(true);
}

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
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width*+3f), projectile.position.Y + (float)(projectile.height*+5.5f), 0, 0, "Enemy Spell Abyss Storm", 106, 8f, projectile.owner);
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
