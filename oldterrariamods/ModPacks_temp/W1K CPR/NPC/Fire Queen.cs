// npc.ai[0] = 0; TimerAI
// npc.ai[1] = 0; TimerDodge

public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{

	int closeTownNPCs = 0;
	if (!Main.bloodMoon)
	{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	}
	if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

	bool underworld= (y > Main.maxTilesY-190);
	
	if (underworld)
	{
	if (Config.syncedRand.Next(4) == 0)
	{
	return true;
	}
	}
	}
	return false;
}

public void AI()
{
	if (Config.syncedRand.Next(2)==0)
	{
		Color color = new Color();
    	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 6, npc.velocity.X, npc.velocity.Y, 200, color, 1f);
    	Main.dust[dust].noGravity = true;
	}

	npc.netUpdate = true;
	npc.ai[0] ++;
	
	npc.TargetClosest();
	if ((Main.player[npc.target].position.X+400 < npc.position.X || Main.player[npc.target].position.X-400 > npc.position.X || Main.player[npc.target].position.Y+400 < npc.position.Y || Main.player[npc.target].position.Y-400 > npc.position.Y))
	{
	if (Main.player[npc.target].position.X+400 < npc.position.X)
	{
	if (npc.velocity.X > -6) {npc.velocity.X -= 0.2f;}
	}
	else if (Main.player[npc.target].position.X-400 > npc.position.X)
	{
	if (npc.velocity.X < 6) {npc.velocity.X += 0.2f;}
	}
	if (Main.player[npc.target].position.Y+400 < npc.position.Y)
	{
	if (npc.velocity.Y > -6) npc.velocity.Y -= 0.2f;
	}
	else if (Main.player[npc.target].position.Y-400 > npc.position.Y)
	{
	if (npc.velocity.Y < 6) npc.velocity.Y += 0.2f;
	}
	}
	else
	{
	npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
	npc.ai[1]++;
	if (npc.ai[1] >= 30)
	{
	npc.velocity.X += Config.syncedRand.Next(-4,4);
	npc.velocity.Y += Config.syncedRand.Next(-4,4);
	npc.ai[1] = 0;
	}
	}

	Vector2 vector = npc.velocity;
	npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false);
	if (npc.velocity.X != vector.X)
	{
		npc.velocity.X = -vector.X;
	}
	if (npc.velocity.Y != vector.Y)
	{
		npc.velocity.Y = -vector.Y;
	}
	
	if (npc.ai[0] >= 0)
	{
		if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
		{
			float num48 = 12f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			int damage = 30;
			int type = Config.projectileID["Flame Shot"];
            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			if (Main.netMode != 2)
			{
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
        	Main.projectile[num54].rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			Main.projectile[num54].scale = 1;
			Main.projectile[num54].timeLeft = 1200;
			}
			npc.ai[0] = -100-Config.syncedRand.Next(100);
		}
	}
	
	if (Main.time % 2 == 0 && Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (npc.position.X < Main.player[npc.target].position.X)
	{
	npc.spriteDirection = -1;
	}
	else
	{
	npc.spriteDirection = 1;
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

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Fire Queen Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Fire Queen Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Fire Queen Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Fire Queen Gore 3", 1f, -1);
}
}