
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
        if (projectile.position.X + (float)(projectile.width / 2) > Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2))
        {
            if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width*7.4f), projectile.position.Y + (float)(projectile.height*-0.3f), 0, 0, "Spell Ice Wave", (int) ((21 + (Main.player[projectile.owner].statMana/10)) * (Main.player[projectile.owner].magicDamage)), 4f, projectile.owner);
        }
        else
        {
            if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width*-8), projectile.position.Y + (float)(projectile.height*-0.3f), 0, 0, "Spell Ice Wave Reverse", (int) ((21 + (Main.player[projectile.owner].statMana/10)) * (Main.player[projectile.owner].magicDamage)), 4f, projectile.owner);
        }
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