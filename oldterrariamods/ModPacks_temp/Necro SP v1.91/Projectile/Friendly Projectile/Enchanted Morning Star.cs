
public void AI()
{
    Projectile P = projectile;
    Player Pr = Main.player[P.owner];
    
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    Vector2 PrC = Pr.position+new Vector2(Pr.width/2,Pr.height/2);
    
    Vector2 PD = new Vector2(P.width,P.height);
    if (Main.myPlayer == P.owner)
    {
        if (Pr.channel)
        {
            float DFO = 0f; //distance from owner
            if (Pr.inventory[Pr.selectedItem].shoot == P.type)
            {
                DFO = Pr.inventory[Pr.selectedItem].shootSpeed * P.scale;
            }
            Vector2 MouseSpot = Main.screenPosition + new Vector2(Main.mouseX,Main.mouseY);
            Vector2 Intended = MouseSpot - PrC;
            float IntendedTotal= Intended.Length();
            IntendedTotal = DFO / IntendedTotal;
            Intended *= IntendedTotal;
            if (Intended.X != P.velocity.X || Intended.Y != P.velocity.Y)
            {
                P.netUpdate = true;
            }
            P.velocity = Intended;
        }
        else
        {
            P.Kill();
        }
    }
    if (P.velocity.X >= 0f)
    {
        Pr.direction = 1;
        P.spriteDirection = 1;
    }
    else
    {
        Pr.direction = -1;
        P.spriteDirection = 1;
    }
    P.spriteDirection = P.direction;
    Pr.direction = P.direction;
    Pr.heldProj = projectile.whoAmI;
    Pr.itemTime = 2;
    Pr.itemAnimation = 2;
    
    int R = (int)P.velocity.Length()*2;
    Vector2 RandomVec = new Vector2(Main.rand.Next(R*2 +1)-R,Main.rand.Next(R*2 +1)-R);
    P.position=PrC-(PD/2)+RandomVec;
    P.rotation = (float)(Math.Atan2((double)P.velocity.Y, (double)P.velocity.X));

    Pr.itemRotation = (float)Math.Atan2((double)(P.velocity.Y * (float)P.direction), (double)(P.velocity.X * (float)P.direction));
    
    if (P.spriteDirection == -1)
    {
        P.rotation -= (float)Math.PI;
    }
    PC = P.position+new Vector2(P.width/2,P.height/2);
    Vector2 DesPos = PC+(P.velocity*6);
    Lighting.addLight((int)(DesPos.X)/16,(int)(DesPos.Y)/16,0.8f,0.8f,0.8f);
    if(Main.rand.Next(3)!=0) return;
    int Dix = Dust.NewDust(DesPos-(PD/2),(int)PD.X,(int)PD.Y,63,P.velocity.X,P.velocity.Y,100,new Color(),2f);
    Main.dust[Dix].noGravity = true;
    Main.dust[Dix].position-=P.velocity;
}
