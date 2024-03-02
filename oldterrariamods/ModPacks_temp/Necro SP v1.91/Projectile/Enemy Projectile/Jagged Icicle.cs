
public void AI() 
{

this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);

if (this.projectile.timeLeft == 150) {
this.projectile.velocity.X = (int)((float)this.projectile.velocity.X*-0.3);
this.projectile.velocity.Y = 3;

}
if (this.projectile.alpha > 0 && this.projectile.timeLeft > 100)
this.projectile.alpha -= 4;
if (this.projectile.alpha < 255 && this.projectile.timeLeft < 50) 
this.projectile.alpha += 4;

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff("Freezing", 60, true);
}
}
