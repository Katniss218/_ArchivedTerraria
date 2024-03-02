
float fakerot = 0;
static float orbitdist = 64f;

public void AI() {

fakerot+=0.2f;
this.projectile.rotation = fakerot;

int num54 = Projectile.NewProjectile(this.projectile.position.X+(float)Math.Cos(this.projectile.rotation)*orbitdist,this.projectile.position.Y+(float)Math.Sin(this.projectile.rotation)*orbitdist,0,0,"Good",this.projectile.damage,1f,this.projectile.owner);
Main.projectile[num54].timeLeft = 20;
Main.projectile[num54].rotation = this.projectile.rotation+1.75f;

num54 = Projectile.NewProjectile(this.projectile.position.X+(float)Math.Cos(this.projectile.rotation)*-orbitdist,this.projectile.position.Y+(float)Math.Sin(this.projectile.rotation)*-orbitdist,0,0,"Evil",this.projectile.damage,1f,this.projectile.owner);
Main.projectile[num54].timeLeft = 20;
Main.projectile[num54].rotation = this.projectile.rotation;

this.projectile.AI(true);
}