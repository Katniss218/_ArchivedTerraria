float movingSpeed = 0;
bool movingUp = false;
bool grappled = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zoneMeteor && Config.syncedRand.Next(5)==1) return true;
	return false;
}

public void AI()
{
	if (grappled)
	{
	if (Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	grappled = false;
	return;
	}
	npc.rotation = 0;
	npc.position = new Vector2(Main.player[npc.target].position.X+(Main.player[npc.target].width/2)-(npc.width/2),Main.player[npc.target].position.Y+(Main.player[npc.target].height/2)-(npc.height/2)-16);
	Main.player[npc.target].velocity.X *= 0.95f;
	}
	else
	{
	npc.TargetClosest();
	
	if (Main.player[npc.target].position.X < npc.position.X)
	{
	if (npc.velocity.X > -2) {npc.velocity.X -= 0.2f;}
	}
	else if (Main.player[npc.target].position.X > npc.position.X)
	{
	if (npc.velocity.X < 2) {npc.velocity.X += 0.2f;}
	}
	if (Main.player[npc.target].position.Y < npc.position.Y)
	{
	if (npc.velocity.Y > -2) npc.velocity.Y -= 0.2f;
	}
	else if (Main.player[npc.target].position.Y > npc.position.Y)
	{
	if (npc.velocity.Y < 2) npc.velocity.Y += 0.2f;
	}

	if (movingUp)
	{
	movingSpeed -= 0.02f;
	}
	else
	{
	movingSpeed += 0.02f;
	}
	if (movingSpeed <= -0.20f)
	{
	movingUp = false;
	}
	if (movingSpeed >= 0.20f)
	{
	movingUp = true;
	}
	npc.velocity.Y += movingSpeed;
	
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
	
	Player player = Main.player[npc.target];
	if (Vector2.Distance(new Vector2(npc.position.X+(npc.width/2),npc.position.Y+(npc.height/2)), new Vector2(player.position.X+(player.width/2),player.position.Y+(player.height/2))) <= 25)
	{
	grappled = true;
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
	if (!grappled) npc.rotation = npc.velocity.X * 0.1f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 8.0)
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
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Metroid Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Metroid Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Metroid Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Metroid Gore 2", 1f, -1);
}
}