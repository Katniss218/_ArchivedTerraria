
public void AI()
{
                            this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
                            if (this.projectile.ai[0] == 0f)
                            {
#region phoenix shit
    for (int num154 = 0; num154 < 1; num154++)
    {
        int num155 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
        if (Main.rand.Next(3) != 0 || true)
        {
            Main.dust[num155].noGravity = true;
            Main.dust[num155].scale *= 3f;
            Dust expr_6767_cp_0 = Main.dust[num155];
            expr_6767_cp_0.velocity.X = expr_6767_cp_0.velocity.X * 2f;
            Dust expr_6785_cp_0 = Main.dust[num155];
            expr_6785_cp_0.velocity.Y = expr_6785_cp_0.velocity.Y * 2f;
        }
        Main.dust[num155].scale *= 1.5f;
        Dust expr_67BC_cp_0 = Main.dust[num155];
        expr_67BC_cp_0.velocity.X = expr_67BC_cp_0.velocity.X * 1.2f;
        Dust expr_67DA_cp_0 = Main.dust[num155];
        expr_67DA_cp_0.velocity.Y = expr_67DA_cp_0.velocity.Y * 1.2f;
        Main.dust[num155].scale *= (float)((((projectile.ai[0]+1)/2)*25)/50);
        
    }
#endregion
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
                                        if (this.projectile.ai[1] >= 17f) // change for max parts
                                        {
                                            num14 = Config.projDefs.byName["Plastic Trail"].type;
                                        }
                                        else
                                            num14 = Config.projDefs.byName["Plastic Trails"].type;
                                        #endregion
/*
                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
 */
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
#region more funtime
/*
                                        Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                        this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*7)/4f));
                                        num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
                                        this.projectile.velocity.X = holdme.X;
                                        this.projectile.velocity.Y = holdme.Y;
                                        this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*1)/4f));
                                        num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
 */
#endregion
#region most fun ever
/*
if((int)(this.projectile.ai[1])%8<4)
{
                                        Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                        this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*1)/8f));
                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
}
else
{
                                        Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                        this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*15)/8f));
                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
}
 */
#endregion
    int z1 = Main.rand.Next(2,3);
    if(projectile.ai[1]%3!=0) z1 = 1;
    else z1=(6-(int)(projectile.ai[1]/3))/2;
for(int zzz = 0; zzz < z1;zzz++)
{
                                        
                                
    int z2 = Main.rand.Next(-1,2);
    if(z2 < 0 ) z2+=16;
                                        Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                        holdme=RotateAboutOrigin(holdme,(float)((Math.PI*z2)/8f));
                                        int num15 = Projectile.NewProjectile(this.projectile.position.X + holdme.X + (float)(this.projectile.width / 2), this.projectile.position.Y + holdme.Y + (float)(this.projectile.height / 2), holdme.X, holdme.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                        Main.projectile[num15].damage = this.projectile.damage;
                                        Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
}
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
                                    /*
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 18, this.projectile.velocity.X * 0.025f, this.projectile.velocity.Y * 0.025f, 170, default(Color), 1.2f);
                                    }
                                    Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 14, 0f, 0f, 170, default(Color), 1.1f);
                                
                                     */
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
/*
public Vector2 MyRotate(Vector2 vector,float rot)
{
    float (
    px = cos(rot) * (px-ox) - sin(rot) * (py-oy) + ox;
    py = sin(rot) * (px-ox) + cos(rot) * (py-oy) + oy;
}
*/
public Vector2 RotateAboutOrigin(Vector2 point, float rotation)
        {
            if(rotation < 0)
                rotation+=(float)(Math.PI*4);
            Vector2 u = point; //point relative to origin  

            if (u == Vector2.Zero)
                return point;

            float a = (float)Math.Atan2(u.Y, u.X); //angle relative to origin  
            a += rotation; //rotate  

            //u is now the new point relative to origin  
            u = u.Length() * new Vector2((float)Math.Cos(a), (float)Math.Sin(a));
            return u;
        } 
#endregion