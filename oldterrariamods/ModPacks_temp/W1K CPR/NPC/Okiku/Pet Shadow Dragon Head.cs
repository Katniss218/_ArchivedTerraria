public void AI()
{
	if (Main.netMode != 1)
	{
		if (npc.ai[0] == 0f)
		{
			this.npc.ai[2] = (float)npc.whoAmI;
			this.npc.realLife = npc.whoAmI;
			int num96 = this.npc.whoAmI;
			for (int num97 = 0; num97 < 24; num97++)
			{
				int num98 = Config.npcDefs.byName["Pet Shadow Dragon Body"].type;
				if (num97 == 4 || num97 == 9 || num97 == 14 || num97 == 19)
				{
					num98 = Config.npcDefs.byName["Pet Shadow Dragon Legs"].type;
				}
				else if (num97 == 21)
				{
					num98 = Config.npcDefs.byName["Pet Shadow Dragon Body 2"].type;
				}
				else if (num97 == 22)
				{
					num98 = Config.npcDefs.byName["Pet Shadow Dragon Body 3"].type;
				}
				else if (num97 == 23)
				{
					num98 = Config.npcDefs.byName["Pet Shadow Dragon Tail"].type;
				}
				int num99 = NPC.NewNPC((int)(this.npc.position.X -20 + (float)(this.npc.width / 2)), (int)(this.npc.position.Y -20 + (float)this.npc.height), num98, this.npc.whoAmI);
				Main.npc[num99].ai[2] = (float)this.npc.whoAmI;
				Main.npc[num99].realLife = this.npc.whoAmI;
				Main.npc[num99].ai[1] = (float)num96;
				Main.npc[num96].ai[0] = (float)num99;
				NetMessage.SendData(23, -1, -1, "", num99, 0f, 0f, 0f, 0);
				num96 = num99;
			}
		}
	//NetMessage.SendData(28, -1, -1, "", this.npc.whoAmI, -1f, 0f, 0f, 0);
	}
	
	if (Main.player[(int)npc.ai[3]].controlLeft && npc.velocity.X > -15)
	{
		if (npc.velocity.X < 0) npc.velocity.X -= 0.3f;
		else npc.velocity.X -= 0.6f;
	}
	if (Main.player[(int)npc.ai[3]].controlRight && npc.velocity.X < 15)
	{
		if (npc.velocity.X < 0) npc.velocity.X += 0.6f;
		else npc.velocity.X += 0.3f;
	}
	if (Main.player[(int)npc.ai[3]].controlUp && npc.velocity.Y > -15)
	{
		if (npc.velocity.Y < 0) npc.velocity.Y -= 0.3f;
		else npc.velocity.Y -= 0.6f;
	}
	if (Main.player[(int)npc.ai[3]].controlDown && npc.velocity.Y < 15)
	{
		if (npc.velocity.Y < 0) npc.velocity.Y += 0.6f;
		else npc.velocity.Y += 0.3f;
	}
	npc.velocity *= 0.99f;
	
	if (npc.position.X < 0) npc.position.X = 0;
	if (npc.position.X > Main.maxTilesX*16f) npc.position.X = Main.maxTilesX*16f;
	if (npc.position.Y < 0) npc.position.Y = 0;
	if (npc.position.Y > Main.maxTilesY*16f) npc.position.Y = Main.maxTilesY*16f;
	Vector2 vector = npc.velocity;
	npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false);
	if (npc.velocity.X != vector.X)
	{
		npc.velocity.X = -vector.X/2;
	}
	if (npc.velocity.Y != vector.Y)
	{
		npc.velocity.Y = -vector.Y/2;
	}
	
	Main.player[(int) npc.ai[3]].Center = npc.Center;
	Main.player[(int) npc.ai[3]].velocity *= 0;
	Main.player[(int) npc.ai[3]].fallStart = (int) (Main.player[(int) npc.ai[3]].position.Y / 16f);
	//Main.player[(int) npc.ai[3]].Center.Y = npc.Center.Y;
	
	if (Main.player[(int) npc.ai[3]].active == false)
	{
		if (npc.ai[3] == Main.myPlayer)
		{
			ModPlayer.DragonMorph = false;
			ModPlayer.DragonId = -1;
			npc.active = false;
		}
	}
	
	if (npc.velocity.X < 0f)
	{
		npc.spriteDirection = 1;
	}
	if (npc.velocity.X > 0f)
	{
		npc.spriteDirection = -1;
	}
	this.npc.rotation = (float)Math.Atan2((double)this.npc.velocity.Y, (double)this.npc.velocity.X) + 1.57f;

	if (Config.syncedRand.Next(3)==0)
	{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 2.0f);
		Main.dust[dust].noGravity = true;
	}
		
	if (npc.life <= 0)
	{
	npc.active = false;
	}
}

public bool PreDraw(SpriteBatch spriteBatch)
{
	Vector2 origin = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
	Color color8 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
	Color alpha = npc.GetAlpha(color8);
	SpriteEffects effects = SpriteEffects.None;
	if (npc.spriteDirection == 1)
	{
		effects = SpriteEffects.FlipHorizontally;
	}
	spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + origin.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + 56f), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0f);
	return false;
}