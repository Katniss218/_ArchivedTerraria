bool fireFrame = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
	if (!Main.dayTime && Main.player[playerID].zoneDungeon)
	{
	if (Config.syncedRand.Next(3)==0)
	{
	return true;
	}
	}
	}
	return false;
}

public void AI()
{
	npc.netUpdate = false;
    npc.ai[0]++; // Timer Scythe
    npc.ai[1]++; // Timer Teleport
    // npc.ai[2] Shots

    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 200, Color.White, 2f);
	Main.dust[dust].noGravity = true;
	if (Config.syncedRand.Next(2)==0)
	{
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 255, Color.White, 1.0f);
    Main.dust[dust].noGravity = true;
	}

    if (npc.ai[0] >= 30 && npc.ai[2] < 3)
    {
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
        float num48 = 1f;
        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        int damage = 30;
        int type = Config.projectileID["Shadow Shot"];
        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
        if (Main.netMode != 2)
		{
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].scale = 1.5f;
        }
		npc.ai[0] = 0;
        npc.ai[2]++;
		fireFrame = true;
    }
	
	if (npc.ai[0] >= 15) fireFrame = false;

	if (npc.ai[1] >= 40)
	{
			npc.velocity.X *= 0.98f;
			npc.velocity.Y *= 0.98f;
	}
	
    if (npc.ai[1] >= 300)
    {
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
		for (int num36 = 0; num36 < 10; num36++)
		{
		dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Config.syncedRand.Next(-10,10), npc.velocity.Y+Config.syncedRand.Next(-10,10), 200, Color.White, 4f);
		Main.dust[dust].noGravity = true;
		}
		//if (Main.netMode != 1)
		//{
		npc.ai[3] = (float) (Config.syncedRand.Next(360)*(Math.PI/180));
		//}
		npc.ai[2] = 0;
        npc.ai[1] = 0;
		if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
		{
		npc.TargetClosest(true);
		}
		if (Main.player[npc.target].dead)
		{
		npc.position.X = 0;
        npc.position.Y = 0;
		if (npc.timeLeft > 10)
		{
			npc.timeLeft = 10;
			return;
		}
		}
		else
		{
        npc.position.X = Main.player[npc.target].position.X + (float) ((250* Math.Cos(npc.ai[3]))*-1);
        npc.position.Y = Main.player[npc.target].position.Y + (float) ((250* Math.Sin(npc.ai[3]))*-1);
		}
	}
		
	if (npc.position.X > Main.player[npc.target].position.X)
	{
		npc.spriteDirection = -1;
	}
	else npc.spriteDirection = 1;
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
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
	if (fireFrame)
	{
		npc.frame.Y = num;
	}
	else npc.frame.Y = 0;
}

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Death Caster Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Death Caster Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Death Caster Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Death Caster Gore 3", 1f, -1);
for (int num36 = 0; num36 < 10; num36++)
{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Config.syncedRand.Next(-5,5), npc.velocity.Y+Config.syncedRand.Next(-5,5), 200, Color.White, 4f);
	Main.dust[dust].noGravity = true;
}
}
}