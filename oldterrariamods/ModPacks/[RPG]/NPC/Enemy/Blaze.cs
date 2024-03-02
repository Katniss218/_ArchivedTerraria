public bool SpawnNPC(int x, int y, int PID) 
{
	if (Main.hardMode)
	{
		if (y > Main.maxTilesY - 200 && Main.rand.Next(20) == 0)
		{
			return true;
		}
	}
	return false;
}
public bool IsInWater(Vector2 pos, int w, int h)
{
    for (int i = (int)pos.X; i < (int)pos.X + w / 16; i++)
    {
        for (int j = (int)pos.Y; j < (int)pos.Y + h / 16; j++)
        {
            if (Main.tile[i, j].liquid > 0 && !Main.tile[i, j].lava)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
    }
    return false;
}
public void AI()
{
	npc.netUpdate = true;
	npc.ai[1]++;
	npc.TargetClosest();
    Player tarP = Main.player[npc.target];    float num74 = 0.022f;
    float num75 = tarP.position.X + (float)(tarP.width / 2);
    float num76 = tarP.position.Y + (float)(tarP.height / 2);
    Vector2 vector11 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
    num75 = (float)((int)(num75 / 8f) * 8);
    num76 = (float)((int)(num76 / 8f) * 8);
    vector11.X = (float)((int)(vector11.X / 8f) * 8);
    vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
    num75 -= vector11.X;
    num76 -= vector11.Y;
	if ((tarP.position.X + 300 < npc.position.X || tarP.position.X - 300 > npc.position.X || tarP.position.Y + 300 < npc.position.Y || tarP.position.Y - 300 > npc.position.Y)) {
	    if (tarP.position.X + 300 < npc.position.X) {
	        if (npc.velocity.X > -6) {
                npc.velocity.X -= 0.2f;
            }
	    }
	    else if (tarP.position.X - 300 > npc.position.X) {
	        if (npc.velocity.X < 6) {
                npc.velocity.X += 0.2f;
            }
	    }
	    if (tarP.position.Y + 300 < npc.position.Y) {
	        if (npc.velocity.Y > -6) {
                npc.velocity.Y -= 0.2f;
            }
	    }
	    else if (tarP.position.Y - 300 > npc.position.Y) {
	        if (npc.velocity.Y < 6) {
                npc.velocity.Y += 0.2f;
            }
	    }
	}
	else {
	    npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
	    npc.ai[2]++;
	    if (npc.ai[2] == 60)  {
	        npc.ai[0] = Main.rand.Next(-7, 7);
	        npc.velocity.X += npc.ai[0];
	        npc.velocity.Y += npc.ai[0];
	        npc.ai[2] = 0;
	    }
	}
	Vector2 vector = npc.velocity;
	npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false);
	if (npc.velocity.X != vector.X) {
		npc.velocity.X = -vector.X;
	}
	if (npc.velocity.Y != vector.Y) {
		npc.velocity.Y = -vector.Y;
	}
    npc.rotation = (float)Math.Atan2((double)num76, (double)num75) - 1.57f;
    float num83 = 0.7f;
    if (npc.collideX)
    {
        npc.netUpdate = true;
        npc.velocity.X = npc.oldVelocity.X * -num83;
        if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
        {
            npc.velocity.X = 2f;
        }
        if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
        {
            npc.velocity.X = -2f;
        }
    }
    if (npc.collideY)
    {
        npc.netUpdate = true;
	    npc.velocity.Y = npc.oldVelocity.Y * -num83;
        if (npc.velocity.Y > 0f && (double)npc.velocity.Y < 1.5)
        {
            npc.velocity.Y = 2f;
        }
        if (npc.velocity.Y < 0f && (double)npc.velocity.Y > -1.5)
        {
            npc.velocity.Y = -2f;
        }
    }
    if (Main.rand.Next(20) == 0)
    {
        int num85 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 6, npc.velocity.X, 2f, 75, npc.color, npc.scale);
        Dust expr_5B51_cp_0 = Main.dust[num85];
        expr_5B51_cp_0.velocity.X = expr_5B51_cp_0.velocity.X * 0.5f;
        Dust expr_5B6F_cp_0 = Main.dust[num85];
        expr_5B6F_cp_0.velocity.Y = expr_5B6F_cp_0.velocity.Y * 0.1f;
    }
    if (Main.rand.Next(40) == 0)
    {
        int num86 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 55, npc.velocity.X, 2f, 0, default(Color), 1f);
        Dust expr_5C0C_cp_0 = Main.dust[num86];
        expr_5C0C_cp_0.velocity.X = expr_5C0C_cp_0.velocity.X * 0.5f;
        Dust expr_5C2A_cp_0 = Main.dust[num86];
        expr_5C2A_cp_0.velocity.Y = expr_5C2A_cp_0.velocity.Y * 0.1f;
    }
    //if (IsInWater(npc.position, npc.width, npc.height))
    if (npc.wet && !npc.lavaWet)
    {
        npc.StrikeNPC(50, 0f, 0, false, false);
    }
    if (Main.netMode != 1 && !Main.player[npc.target].dead)
    {
        if (npc.justHit)
        {
            npc.localAI[0] = 0f;
        }
        npc.localAI[0] += 1f;
        if (npc.localAI[0] == 180f)
        {
            if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
            {
                NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2) + npc.velocity.X), (int)(npc.position.Y + (float)(npc.height / 2) + npc.velocity.Y), Config.npcDefs.byName["Blaze Orb"].type, 0);
            }
            npc.localAI[0] = 0f;
        }
    }
    if (Main.dayTime && Main.player[npc.target].dead)
    {
        npc.velocity.Y = npc.velocity.Y - num74 * 2f;
        if (npc.timeLeft > 10)
        {
            npc.timeLeft = 10;
        }
        if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
        {
            npc.netUpdate = true;
            return;
        }
    }
}
public void NPCLoot()
{
	Rectangle R = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
	int C = 50;
	float vR = 0.4f;
	for (int i = 1; i <= C; i++)
	{
		int D = Dust.NewDust(npc.position, R.Width, R.Height, 6, 0, 0, 100, new Color(), 2f);
		Main.dust[D].noGravity = true;
		Main.dust[D].velocity.X = vR * (Main.dust[D].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[D].velocity.Y = vR * (Main.dust[D].position.Y - (npc.position.Y + (npc.height/2)));
    }
	for (int i2 = 1; i2 <= C; i2++)
	{
		int D2 = Dust.NewDust(npc.position, R.Width, R.Height, 54, 0, 0, 100, new Color(), 1f);
		Main.dust[D2].noGravity = true;
		Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (npc.position.Y + (npc.height/2)));
    }
    int pr = Projectile.NewProjectile(npc.position.X + (int)npc.width / 2, npc.position.Y + (int)npc.height / 2, 0f, 0f, 30, 0, 0f, npc.target);
    Main.projectile[pr].Kill();
}