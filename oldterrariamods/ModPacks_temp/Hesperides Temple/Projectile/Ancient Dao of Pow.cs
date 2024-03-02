public static void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(3) == 0) {
		npc.AddBuff (31, (120), false);
	}
}

public void AI()
{
    projectile.aiStyle = 15;
    projectile.AI(true); //-screw memo's
}
 
public bool PreDraw(SpriteBatch spriteBatch)
{
    projectile.aiStyle = -1; //THERE
    Player Pr = Main.player[Main.myPlayer];
    Vector2 PrC = Pr.position+new Vector2(Pr.width/2,Pr.height/2);
    Projectile P = projectile;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    ModWorld.DrawChain(PrC, PC, "Chain", spriteBatch);
    Vector2 Diff = PrC-PC;
    float Rotation = (float)Math.Atan2(Diff.Y,Diff.X) - 1.57f;
    if(P.alpha == 0)
    {
        int mult = -1;
        if(PC.X < PrC.Y) mult = 1;
        Pr.itemRotation = (float)Math.Atan2(Diff.Y*mult,Diff.X*mult);
    }
    return true;
}

public void Initialize()
{
      projectile.timeLeft = 3600;
}