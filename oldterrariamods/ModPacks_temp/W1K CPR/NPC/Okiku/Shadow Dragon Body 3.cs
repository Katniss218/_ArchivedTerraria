int Timer = -Config.syncedRand.Next(800);

public void AI()
{
npc.TargetClosest(true);
Timer++;

if (!Main.npc[(int)npc.ai[1]].active)
{
	npc.life = 0;
	npc.HitEffect(0, 10.0);
	npc.active = false;
}
if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = 1;
}
if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = -1;
}

	if (Timer >= 0)
	{
		if (Main.netMode != 2)
		{
			float num48 = 1f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Config.syncedRand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Obscure Saw", 45, 0f, Main.myPlayer);
			Timer = -300-Config.syncedRand.Next(300);
		}
	}

if (Config.syncedRand.Next(3)==0)
{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
}

npc.AI(true);
}

public bool PreDraw(SpriteBatch spriteBatch)
{
	Vector2 origin = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
	Color color8 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
	Color alpha = npc.GetAlpha(color8);
	byte b = (byte)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
	if (alpha.R < b)
	{
		alpha.R = b;
	}
	if (alpha.G < b)
	{
		alpha.G = b;
	}
	if (alpha.B < b)
	{
		alpha.B = b;
	}
	SpriteEffects effects = SpriteEffects.None;
	if (npc.spriteDirection == 1)
	{
		effects = SpriteEffects.FlipHorizontally;
	}
	spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + origin.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + 56f), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0f);
	return false;
}