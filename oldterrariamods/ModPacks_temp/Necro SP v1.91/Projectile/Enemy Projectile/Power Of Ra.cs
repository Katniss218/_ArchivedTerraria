
float m = 0;
float n = 0;

public void AI() {


if (this.projectile.alpha > 255) this.projectile.alpha = 255;
if (this.projectile.alpha < 0) this.projectile.alpha = 0;

if (this.projectile.alpha > 100) this.projectile.hostile = false;
else this.projectile.hostile = true;

if (this.projectile.hostile) {


if (this.projectile.velocity.X == 0 && this.projectile.velocity.Y == 0) {
this.projectile.velocity.Y = (float)Math.Sin(this.projectile.rotation)*-7;
this.projectile.velocity.X = (float)Math.Cos(this.projectile.rotation)*-7;
}


int dust = Dust.NewDust(this.projectile.position, 108, 180, 64, Main.rand.Next(10)-5, Main.rand.Next(10)-5, 100, Color.Red, 5.0f);
Main.dust[dust].noGravity = true;
Main.dust[dust].rotation = this.projectile.rotation;
}

//Fade in
if (this.projectile.alpha > 100 && this.projectile.timeLeft > 100)
this.projectile.alpha -= 1;
//Fade out
if (this.projectile.alpha < 255 && this.projectile.timeLeft < 50) 
this.projectile.alpha += 4;
}
