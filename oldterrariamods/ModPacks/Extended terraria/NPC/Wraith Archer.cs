public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.moonPhase == 4)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && y < Main.rockLayer + 10 && Main.rand.Next(10) == 0)
			{
				return true;
			}
			else return false;
		}
		else if (Main.moonPhase != 4)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && y < Main.rockLayer + 10 && Main.rand.Next(17) == 0)
			{
				return true;
			}
			else return false;
		}
		else return false;
	}
	else return false;
}
public void AI()
{
	npc.AI(true);
 
	npc.TargetClosest(true);
 
	int x = (int)Main.player[npc.target].position.X;
	int y = (int)Main.player[npc.target].position.Y;
 
	if(npc.velocity.Y == 0)
	{
		npc.velocity.X += 0.2f * npc.direction;
	}
 
	if (npc.life < 50)
	{
		npc.ai[3]++;
	}
 
	npc.ai[3]++;
 
	if ((npc.ai[3] >= 120) && (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
	{ 
		float Speed = 10f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
		int damage = 50;
		int type = Config.projDefs.byName["Shadow Arrow"].type;
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 1);
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 255);
		Main.projectile[num54].hostile = true;
		Main.projectile[num54].friendly = false;
		npc.ai[3] = 0;
	}
}