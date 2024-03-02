public bool SpawnNPC(int x, int y, int playerID)
{
	if (!Main.dayTime)
	{
		if (y > Main.rockLayer && y < Main.maxTilesY - 50 && Main.jungleTiles > 50 && !Main.player[playerID].zoneDungeon && Main.rand.Next(40) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void AI()
{
	npc.AI(true);
	npc.ai[3]++;
	if (npc.ai[3] >= 240)
	{
		if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
		{
			float num87 = 8f;
			Vector2 vector12 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)(npc.height / 2));
			float num88 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector12.X + (float)Main.rand.Next(-20, 21);
			float num89 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector12.Y + (float)Main.rand.Next(-20, 21);
			if ((num88 < 0f && npc.velocity.X < 0f) || (num88 > 0f && npc.velocity.X > 0f))
			{
				float num90 = (float)Math.Sqrt((double)(num88 * num88 + num89 * num89));
				num90 = num87 / num90;
				num88 *= num90;
				num89 *= num90;
				int num91 = (int)(13f * npc.scale);
				int num92 = 55;
				int num93 = Projectile.NewProjectile(vector12.X, vector12.Y, num88, num89, num92, num91, 0f, Main.myPlayer);
				Main.projectile[num93].timeLeft = 300;
				npc.ai[3] = 101f;
				npc.netUpdate = true;
			}
			else
			{
				npc.ai[3] = 0f;
			}
		}
		npc.ai[3] = 0;
	}
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Queen Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Queen Head",1f,-1);
}