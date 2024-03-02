public void AI()
{
projectile.AI(true);
Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff(20, 600, false);
Main.player[Main.myPlayer].AddBuff(22, 600, false);
}

projectile.netUpdate=true;

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
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width), projectile.position.Y + (float)(projectile.height), 0, 0, "Enemy Spell Abyss Poison Strike", 95, 1f, projectile.owner);
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


