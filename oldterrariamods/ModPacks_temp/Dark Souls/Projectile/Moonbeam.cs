
float m = 0;
float n = 0;

public void AI() {

//this.projectile.velocity.X = 0;
//this.projectile.velocity.Y = 0;
if (this.projectile.alpha > 255) this.projectile.alpha = 255;
if (this.projectile.alpha < 0) this.projectile.alpha = 0;

if (this.projectile.alpha != 0) this.projectile.hostile = false;
else this.projectile.hostile = true;

if (this.projectile.hostile && Main.rand.Next(5) < 1) {
int dust = Dust.NewDust(this.projectile.position, 64, 0, 45, Main.rand.Next(10)-5, Main.rand.Next(10)-5, 255, Color.Cyan, 5.0f);
Main.dust[dust].noGravity = true;
Main.dust[dust].rotation = this.projectile.rotation;
}

//Fade in
if (this.projectile.alpha > 0 && this.projectile.timeLeft > 100)
this.projectile.alpha -= 2;
//Fade out
if (this.projectile.alpha < 255 && this.projectile.timeLeft < 50) 
this.projectile.alpha += 4;
}
