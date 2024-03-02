public int hitDelay = 0;

public void AI()
{
	//npc.rotation += 0.3f;
    //npc.ai[0]; // Player's ID
	//npc.ai[1]; // Level
	
	if (npc.ai[1] == 1)
	{
		npc.scale = 0.8f;
	}
	if (npc.ai[1] == 2)
	{
		npc.scale = 0.9f;
	}
	if (npc.ai[1] == 3)
	{
		npc.scale = 1f;
	}
	if (npc.ai[1] == 4)
	{
		npc.scale = 1.1f;
	}
	if (npc.ai[1] == 5)
	{
		npc.scale = 1.2f;
	}
	if (npc.ai[1] == 6)
	{
		npc.scale = 1f;
	}
	if (npc.ai[1] == 7)
	{
		npc.scale = 1.1f;
	}
	if (npc.ai[1] == 8)
	{
		npc.scale = 1.2f;
	}
	if (npc.ai[1] == 9)
	{
		npc.scale = 1.3f;
	}
	if (npc.ai[1] == 10)
	{
		npc.scale = 1.4f;
	}
	
	npc.target = (int) npc.ai[0];
	
	bool buffOn = false;
	for (int num36 = 2; num36 <= 7; num36++)
	{
		if (Main.player[npc.target].armor[num36].type == Config.itemDefs.byName["Companion Bat"].type)
		{
			buffOn = true;
			break;
		}
	}
	if (!buffOn)
	{
		npc.active = false;
	}
	
	int enemyTarget = -1;
	
	foreach (NPC npcTarget in Main.npc)
	{
		if (npcTarget.active && !npcTarget.friendly && npcTarget.whoAmI != npc.whoAmI && npcTarget.defense < 100)
		{
			if (Collision.CanHit(Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height, npcTarget.position, npcTarget.width, npcTarget.height) && npc.Distance(npcTarget.Center) < 600)
			{
				if (enemyTarget == -1)
				{
					enemyTarget = npcTarget.whoAmI;
				}
				if (npc.Distance(npcTarget.Center) < npc.Distance(Main.npc[enemyTarget].Center))
				{
					enemyTarget = npcTarget.whoAmI;
				}
			}
		}
	}
	
	if (enemyTarget == -1)
	{
		if (Main.player[npc.target].Center.X+70 < npc.Center.X || Main.player[npc.target].Center.X-70 > npc.Center.X || Main.player[npc.target].Center.Y+70 < npc.Center.Y || Main.player[npc.target].Center.Y-70 > npc.Center.Y)
		{
			float r = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y,npc.Center.X-Main.player[npc.target].Center.X);
			npc.velocity.X += (float)(Math.Cos(r)/4f)*-1;
			npc.velocity.Y += (float)(Math.Sin(r)/4f)*-1;
			if (npc.velocity.X > 8) npc.velocity.X = 8;
			if (npc.velocity.X < -8) npc.velocity.X = -8;
			if (npc.velocity.Y > 8) npc.velocity.Y = 8;
			if (npc.velocity.Y < -8) npc.velocity.Y = -8;
			npc.velocity.X *= 0.98f; npc.velocity.Y *= 0.98f;
		}
		else
		{
			npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
			npc.ai[2]++;
			if (npc.ai[2] == 40)
			{
				npc.velocity.X += Config.syncedRand.Next(-3,3);
				npc.velocity.Y += Config.syncedRand.Next(-3,3);
				npc.ai[2] = 0;
			}
		}
		
		if (npc.Center.X > Main.player[npc.target].Center.X)
		{
			npc.spriteDirection = 1;
		}
		else
		{
			npc.spriteDirection = -1;
		}
	}
	else
	{
		if (hitDelay > 0) hitDelay--;
		if (!npc.Hitbox.Intersects(Main.npc[enemyTarget].Hitbox))
		{
			float r = (float) Math.Atan2(npc.Center.Y-Main.npc[enemyTarget].Center.Y,npc.Center.X-Main.npc[enemyTarget].Center.X);
			npc.velocity.X += (float)(Math.Cos(r)/4f)*-1;
			npc.velocity.Y += (float)(Math.Sin(r)/4f)*-1;
			if (npc.velocity.X > 8) npc.velocity.X = 8;
			if (npc.velocity.X < -8) npc.velocity.X = -8;
			if (npc.velocity.Y > 8) npc.velocity.Y = 8;
			if (npc.velocity.Y < -8) npc.velocity.Y = -8;
			npc.velocity.X *= 0.98f; npc.velocity.Y *= 0.98f;
		}
		else
		{
			npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
			if (hitDelay <= 0)
			{
				Main.npc[enemyTarget].StrikeNPC(3*(int)npc.ai[1], 0, 0);
				hitDelay = 30;
			}
		}
		
		if (npc.Center.X > Main.npc[enemyTarget].Center.X)
		{
			npc.spriteDirection = 1;
		}
		else
		{
			npc.spriteDirection = -1;
		}
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.rotation = npc.velocity.X * 0.08f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 4.0)
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
	Vector2 origin = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
	SpriteEffects effects = SpriteEffects.None;
	if (npc.spriteDirection == -1)
	{
		effects = SpriteEffects.FlipHorizontally;
	}
	Color color8 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
	Color alpha = npc.GetAlpha(color8);
	if (npc.ai[1] >= 6) spriteBatch.Draw(Main.npcTexture[Config.npcDefs.byName["Companion Bat 2"].type], new Vector2(npc.position.X - Main.screenPosition.X, npc.position.Y - Main.screenPosition.Y), new Rectangle(0,npc.frame.Y,Main.npcTexture[npc.type].Width,(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type])),alpha, npc.rotation, origin, npc.scale, effects, 0f);
	else spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X, npc.position.Y - Main.screenPosition.Y), new Rectangle(0,npc.frame.Y,Main.npcTexture[npc.type].Width,(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type])),alpha, npc.rotation, origin, npc.scale, effects, 0f);
}