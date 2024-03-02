public void AI(){

Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y-10), projectile.width, projectile.height, 27, 0, 0, 100, color, 1.0f);
	Main.dust[dust].noGravity = true;

if(this.projectile.timeLeft <= 140){
this.projectile.scale = 0.5f;
this.projectile.damage = 70;
}
if(this.projectile.timeLeft <= 110){
this.projectile.scale = 0.6f;
this.projectile.damage = 75;
}
if(this.projectile.timeLeft <= 90){
this.projectile.scale = 0.8f;
this.projectile.damage = 78;
}
if(this.projectile.timeLeft <= 70){
this.projectile.scale =1f;
this.projectile.damage = 80;
}
if(this.projectile.timeLeft <= 50){
this.projectile.scale = 1.2f;
this.projectile.damage = 85;
}
if(this.projectile.timeLeft <= 40){
this.projectile.scale = 1.4f;
this.projectile.damage = 95;
}
					
					this.projectile.ai[0] += 1f;
				
				
				this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
				if (this.projectile.velocity.Y > 16f)
				{
					this.projectile.velocity.Y = 16f;
					return;
				}
}