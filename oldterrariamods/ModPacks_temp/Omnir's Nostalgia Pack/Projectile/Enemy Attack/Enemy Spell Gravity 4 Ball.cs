Vector2 []lastpos = new Vector2[20];
int lastposindex = 0;

#region AI
public void AI()// ai code is from Draykon's Blight boss
{
    this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);
    if (this.projectile.timeLeft > 200 && this.projectile.timeLeft < 500) 
    {
        this.projectile.velocity.X -= (this.projectile.position.X-Main.player[(int)this.projectile.ai[0]].position.X)/1000f;
        this.projectile.velocity.Y -= (this.projectile.position.Y-Main.player[(int)this.projectile.ai[0]].position.Y)/1000f;
        this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);
        this.projectile.velocity.Y = (float)Math.Sin(this.projectile.rotation)*8;
        this.projectile.velocity.X = (float)Math.Cos(this.projectile.rotation)*8;
    }
    lastpos[lastposindex] = this.projectile.position;
    lastposindex++;
    if (lastposindex > 19) lastposindex = 0;      
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
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height - 16), 0, 0, "Enemy Spell Gravity 4 Strike", 0, 3f, projectile.owner);
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