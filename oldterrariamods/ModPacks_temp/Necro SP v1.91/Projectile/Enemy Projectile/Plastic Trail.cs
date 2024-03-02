

public void AI()
{
                            this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
                            if (this.projectile.ai[0] == 0f)
                            {
                                #region not last frame
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
                                    #region if not last thorn
                                    if (this.projectile.type == 7 && Main.myPlayer == this.projectile.owner)
                                    {
                                        int num14 = this.projectile.type;
                                        #region should be last thorn
                                        if (this.projectile.ai[1] >= 13f) // change for max parts
                                        {
                                            num14 = Config.projDefs.byName["Plastic Trail"].type;
                                        }
                                        else
                                            num14 = Config.projDefs.byName["Plastic Trails"].type;
                                        #endregion
                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
#region funtime
/*
                                        Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                        this.projectile.velocity=RotateByRightAngle(holdme);
                                        num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
                                        this.projectile.velocity=RotateByLeftAngle(holdme);
                                        num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
 */
#endregion
                                        return;
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                #region makes it pretty
                                if (this.projectile.alpha < 170 && this.projectile.alpha + 5 >= 170)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 18, this.projectile.velocity.X * 0.025f, this.projectile.velocity.Y * 0.025f, 170, default(Color), 1.2f);
                                    }
                                    Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 14, 0f, 0f, 170, default(Color), 1.1f);
                                }
                                #endregion
                                this.projectile.alpha += 5;
                                if (this.projectile.alpha >= 255)
                                {
                                    this.projectile.Kill();
                                    return;
                                }
                            }
                        
}

#region math is fun!        
public Vector2 RotateByRightAngle(Vector2 vector)
{
    return new Vector2(vector.Y, -vector.X);
}
public Vector2 RotateByLeftAngle(Vector2 vector)
{
    return new Vector2(-vector.Y, vector.X);
}


#endregion