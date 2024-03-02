
//Methods

public void PostAI() {
	if(((int)Main.time & 1) > 0) {
		float speedX = projectile.velocity.X * (float)Main.rand.Next(5) * 0.2f;
		float speedY = projectile.velocity.Y * (float)Main.rand.Next(5) * 0.2f;
		int i = Dust.NewDust(projectile.position,projectile.width,projectile.height,20,speedX,speedY,80,default(Color),1.2f);
		Main.dust[i].noGravity = true;
		int j = Dust.NewDust(projectile.position,projectile.width,projectile.height,21,speedX,speedY,80,default(Color),1.2f);
		Main.dust[j].noGravity = true;
	}
}
