
int ShieldTolorence = 0;
int ShieldDefense = 63;

public void SHIELD_STATS()
{
    int Defense_Total = ShieldDefense;
    Player Pr = Main.player[projectile.owner];
    //Defense_Total+=(int)Math.Abs(Pr.velocity.X);
    projectile.RunMethod("SHIELD_FX",Pr,Defense_Total);
}

public void AI()
{
    SHIELD_STATS();
    #region Aesthetics
    if (Main.myPlayer == projectile.owner)
    {
        if (Main.player[projectile.owner].channel)
        {
            float num119 = 0f;
            if (Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shoot == projectile.type)
            {
                num119 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
            }
            Vector2 vector14 = new Vector2(Main.player[projectile.owner].position.X + (float)Main.player[projectile.owner].width * 0.5f, Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height * 0.5f);
            float num120 = (float)Main.mouseX + Main.screenPosition.X - vector14.X;
            float num121 = (float)Main.mouseY + Main.screenPosition.Y - vector14.Y;
            float num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
            num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
            num122 = num119 / num122;
            num120 *= num122;
            num121 *= num122;
            if (num120 != projectile.velocity.X || num121 != projectile.velocity.Y)
            {
                projectile.netUpdate = true;
            }
            projectile.velocity.X = num120;
            projectile.velocity.Y = num121;
        }
        else
        {
            projectile.Kill();
        }
    }
    if (projectile.velocity.X > 0f)
    {
        Main.player[projectile.owner].direction = 1;
        projectile.spriteDirection = 1;
    }
    else
    {
        if (projectile.velocity.X < 0f)
        {
            Main.player[projectile.owner].direction = -1;
            projectile.spriteDirection = 1;
        }
    }
    projectile.spriteDirection = projectile.direction;
    Main.player[projectile.owner].direction = projectile.direction;
    Main.player[projectile.owner].heldProj = projectile.whoAmI;
    Main.player[projectile.owner].itemTime = 2;
    Main.player[projectile.owner].itemAnimation = 2;
    projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
    projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
    projectile.rotation = (float)(Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) );
    if (Main.player[projectile.owner].direction == 1)
    {
        Main.player[projectile.owner].itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
    }
    else
    {
        Main.player[projectile.owner].itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
    }
    if (projectile.spriteDirection == -1)
    {
        projectile.rotation -= (float)Math.PI; //half pie
    }
    #endregion
    #region blocking projectiles
    
    Vector2 ShieldDims = new Vector2(20f,20f);
    Vector2 ShieldOFFs = -ShieldDims + ShieldDims*0.5f;
    Rectangle MyCol = new Rectangle((int)projectile.position.X+(int)ShieldOFFs.X, (int)projectile.position.Y+(int)ShieldOFFs.Y, (int)(projectile.width+ShieldDims.X), (int)(projectile.height+ShieldDims.Y));
    foreach(Projectile P in Main.projectile)
    {
        if(P != projectile && P.hostile && P.damage > 0)
        {
            Rectangle ItsCol = new Rectangle((int)(P.position.X+P.velocity.X), (int)(P.position.Y+P.velocity.Y),P.width, P.height);
            if (MyCol.Intersects(ItsCol))	
            {
                P.Kill();
            }		
        }
        if (projectile.damage > 0 && Main.player[Main.myPlayer].hostile) 
        {
            if(P != projectile &&
            P.owner != projectile.owner && 
            Main.player[P.owner].hostile && 
            (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[P.owner].team) &&
            P.damage > 0)
            {
                Rectangle ItsCol = new Rectangle((int)(P.position.X+P.velocity.X), (int)(P.position.Y+P.velocity.Y),P.width, P.height);
                if (MyCol.Intersects(ItsCol))
                {
                    P.Kill();
                }		
            }
        }
    }
				

    #endregion
}