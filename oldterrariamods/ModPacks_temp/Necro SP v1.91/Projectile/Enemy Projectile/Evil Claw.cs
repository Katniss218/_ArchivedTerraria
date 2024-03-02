public void AI()
{
                            this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
                            if (this.projectile.ai[0] == 0f)
                            {

                                this.projectile.alpha -= 50;
                                if (this.projectile.alpha <= 0)
                                {
                                    this.projectile.alpha = 0;
                                    this.projectile.ai[0] = 1f;
                                    if (this.projectile.ai[1] == 0f)
                                    {
                                        this.projectile.ai[1] += 1f;
                                        this.projectile.position += this.projectile.velocity * 1f;
                                    }
 
                                    if (this.projectile.type == 7 && Main.myPlayer == this.projectile.owner)
                                    {
                                        int num14 = this.projectile.type;

                                        if (this.projectile.ai[1] >= 13f) // change for max parts
                                        {
                                            num14 = Config.projDefs.byName["Plastic Trail"].type;
                                        }
                                        else
                                            num14 = Config.projDefs.byName["Plastic Trails"].type;

                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
                                        return;
                                    }

                                }

                            }
                            else
                            {

                                if (this.projectile.alpha < 170 && this.projectile.alpha + 5 >= 170)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 18, this.projectile.velocity.X * 0.025f, this.projectile.velocity.Y * 0.025f, 170, default(Color), 1.2f);
                                    }
                                    Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 14, 0f, 0f, 170, default(Color), 1.1f);
                                }

                                this.projectile.alpha += 5;
                                if (this.projectile.alpha >= 255)
                                {
                                    this.projectile.Kill();
                                    return;
                                }
                            }
    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

    if (projrec.Intersects(prec))
    {
    Main.player[Main.myPlayer].AddBuff(30, 800, false);
    Main.player[Main.myPlayer].AddBuff("Deep Cut", 600, true);
    }                        
}
   
public Vector2 RotateByRightAngle(Vector2 vector)
{
    return new Vector2(vector.Y, -vector.X);
}
public Vector2 RotateByLeftAngle(Vector2 vector)
{
    return new Vector2(-vector.Y, vector.X);
}


