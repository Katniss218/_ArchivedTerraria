public int timerDespawn = 420;

public void AI()
{
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	
	#region Player is ded
	if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
	}
	#endregion
	

	if (Main.player[npc.target].Center.X < npc.Center.X)
	{
	if (npc.velocity.X > -6) npc.velocity.X -= 0.1f;
	}
	
	if (Main.player[npc.target].Center.X > npc.Center.X)
	{
	if (npc.velocity.X < 6) npc.velocity.X += 0.1f;
	}
	
	if (Main.player[npc.target].Center.Y < npc.Center.Y)
	{
	if (npc.velocity.Y > -6) npc.velocity.Y -= 0.1f;
	}

	if (Main.player[npc.target].Center.Y > npc.Center.Y)
	{
	if (npc.velocity.Y < 6) npc.velocity.Y += 0.1f;
	}
	
	if (Main.rand.Next(4)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = false;
	}
	
	if (timerDespawn <= 2)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
	}
	timerDespawn--;
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 2.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
}

public bool PreDraw(SpriteBatch spriteBatch)
{
	return false;
}

public void PostDraw(SpriteBatch spriteBatch)
{
	spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X, npc.position.Y - Main.screenPosition.Y), new Rectangle(0,npc.frame.Y,Main.npcTexture[npc.type].Width,(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type])),new Color(255,255,255,255));
}

public void DamagePlayer(Player player, ref int damage)
{
	npc.life = 0;
	npc.HitEffect(0, 10.0);
}

public void NPCLoot()
{
	for (int num36 = 0; num36 < 15; num36++)
	{
		int dustDeath = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, Config.syncedRand.Next(-6,6), Config.syncedRand.Next(-6,6), 200, Color.White, 2f);
		Main.dust[dustDeath].noGravity = true;
	}
	npc.damage = 0;
	npc.active = false;
}