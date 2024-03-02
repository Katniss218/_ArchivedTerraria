public void AI()
{

this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.X, (double)this.projectile.velocity.Y);
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 75, 0, 0, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
}

public void Kill()
{
        float num48 = 25f;
		int damage = (projectile.damage/2)+5;
		int type = Config.projectileID["Miracle Vines"];
        Projectile.NewProjectile(projectile.position.X, projectile.position.Y,0,-num48, type, damage, 0f, Main.myPlayer);
        projectile.active = false;
		}