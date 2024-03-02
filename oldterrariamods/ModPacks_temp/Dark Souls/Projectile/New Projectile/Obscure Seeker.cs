

Vector2 []lastpos = new Vector2[20];
int lastposindex = 0;
public void AI()
{



projectile.rotation++;
	





this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);



if (this.projectile.timeLeft < 100)  {
this.projectile.scale*=0.9f;
this.projectile.damage = 0;
}

if (this.projectile.timeLeft > 200 && this.projectile.timeLeft < 500) {
this.projectile.velocity.X -= (this.projectile.position.X-Main.player[(int)this.projectile.ai[0]].position.X)/1000f;
this.projectile.velocity.Y -= (this.projectile.position.Y-Main.player[(int)this.projectile.ai[0]].position.Y)/1000f;

this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);
this.projectile.velocity.Y = (float)Math.Sin(this.projectile.rotation)*8;
this.projectile.velocity.X = (float)Math.Cos(this.projectile.rotation)*8;
}




lastpos[lastposindex] = this.projectile.position;
lastposindex++;
if (lastposindex > 19) lastposindex = 0;

                       
                        
int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.Red, 2.0f);
	Main.dust[dust].noGravity = true;



Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff(22, 18000, false);
Main.player[Main.myPlayer].AddBuff(20, 18000, false);
Main.player[Main.myPlayer].AddBuff(30, 18000, false);
Main.player[Main.myPlayer].AddBuff(36, 1200, false);

}



projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 3;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }



}