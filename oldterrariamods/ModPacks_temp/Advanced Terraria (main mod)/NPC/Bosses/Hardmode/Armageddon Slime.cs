//bool isShieldSpawned = false;
public void AI()
{
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Gold Inferno"])
		{
			npc.lifeRegen = -20;
		}
	}
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Freeze"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	/*if (!isShieldSpawned)
	{
		int c = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Config.npcDefs.byName["AS ForceField"].type, 0);
		Main.npc[c].ai[0] = npc.whoAmI;
		isShieldSpawned = true;
	}*/
	npc.aiAction = 0;
	if (npc.ai[3] == 0f && npc.life > 0)
	{
		npc.ai[3] = (float)npc.lifeMax;
	}
	if (npc.ai[2] == 0f)
	{
		npc.ai[0] = -100f;
		npc.ai[2] = 1f;
		npc.TargetClosest(true);
	}
	if (npc.velocity.Y == 0f)
	{
		npc.velocity.X = npc.velocity.X * 0.8f;
		if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
		{
			npc.velocity.X = 0f;
		}
		npc.ai[0] += 2f;
		if ((double)npc.life < (double)npc.lifeMax * 0.8)
		{
			npc.ai[0] += 1f;
		}
		if ((double)npc.life < (double)npc.lifeMax * 0.6)
		{
			npc.ai[0] += 1f;
		}
		if ((double)npc.life < (double)npc.lifeMax * 0.4)
		{
			npc.ai[0] += 2f;
		}
		if ((double)npc.life < (double)npc.lifeMax * 0.2)
		{
			npc.ai[0] += 3f;
		}
		if ((double)npc.life < (double)npc.lifeMax * 0.1)
		{
			npc.ai[0] += 4f;
		}
		if (npc.ai[0] >= 0f)
		{
			npc.netUpdate = true;
			npc.TargetClosest(true);
			if (npc.ai[1] == 3f)
			{
				npc.velocity.Y = -13f;
				npc.velocity.X = npc.velocity.X + 3.5f * (float)npc.direction;
				npc.ai[0] = -200f;
				npc.ai[1] = 0f;
			}
			else
			{
				if (npc.ai[1] == 2f)
				{
					npc.velocity.Y = -6f;
					npc.velocity.X = npc.velocity.X + 4.5f * (float)npc.direction;
					npc.ai[0] = -120f;
					npc.ai[1] += 1f;
				}
				else
				{
					npc.velocity.Y = -8f;
					npc.velocity.X = npc.velocity.X + 4f * (float)npc.direction;
					npc.ai[0] = -120f;
					npc.ai[1] += 1f;
				}
			}
		}
		else
		{
			if (npc.ai[0] >= -30f)
			{
				npc.aiAction = 1;
			}
		}
	}
	else
	{
		if (npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
		{
			if ((npc.direction == -1 && (double)npc.velocity.X < 0.1) || (npc.direction == 1 && (double)npc.velocity.X > -0.1))
			{
				npc.velocity.X = npc.velocity.X + 0.2f * (float)npc.direction;
			}
			else
			{
				npc.velocity.X = npc.velocity.X * 0.93f;
			}
		}
	}
	int num224 = Dust.NewDust(npc.position, npc.width, npc.height, 4, npc.velocity.X, npc.velocity.Y, 255, new Color(0, 80, 255, 80), npc.scale * 1.2f);
	Main.dust[num224].noGravity = true;
	Main.dust[num224].velocity *= 0.5f;
	if (npc.life > 0)
	{
		float num225 = (float)npc.life / (float)npc.lifeMax;
		num225 = num225 * 0.5f + 0.75f;
		if (num225 != npc.scale)
		{
			npc.position.X = npc.position.X + (float)(npc.width / 2);
			npc.position.Y = npc.position.Y + (float)npc.height;
			npc.scale = num225;
			npc.width = (int)(98f * npc.scale);
			npc.height = (int)(92f * npc.scale);
			npc.position.X = npc.position.X - (float)(npc.width / 2);
			npc.position.Y = npc.position.Y - (float)npc.height;
		}
		if (Main.netMode != 1)
		{
			int num226 = (int)((double)npc.lifeMax * 0.05);
			if ((float)(npc.life + num226) < npc.ai[3])
			{
				npc.ai[3] = (float)npc.life;
				int num227 = Main.rand.Next(1, 4);
				for (int num228 = 0; num228 < num227; num228++)
				{
					int x = (int)(npc.position.X + (float)Main.rand.Next(npc.width - 32));
					int y = (int)(npc.position.Y + (float)Main.rand.Next(npc.height - 32));
					int num229 = NPC.NewNPC(x, y, Config.npcDefs.byName["Dark Mother Slime"].type, 0);
					Main.npc[num229].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
					Main.npc[num229].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
					Main.npc[num229].ai[1] = (float)Main.rand.Next(3);
					float num48 = 12f;
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
					int damage = 50;
					int type = Config.projDefs.byName["Dark Matter Flame"].type;
					Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
					float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
					int num54;
					float f = 0f;
 
					while (f <= 4f)
					{
						num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation+f) * num48)*-1),(float)((Math.Sin(rotation+f) * num48)*-1), type, damage, 0f, 0);
						Main.projectile[num54].timeLeft = 600;
						Main.projectile[num54].tileCollide=false;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(27, -1, -1, "", num54, 0f, 0f, 0f, 0);
						}
						num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation-f) * num48)*-1),(float)((Math.Sin(rotation-f) * num48)*-1), type, damage, 0f, 0);
						Main.projectile[num54].timeLeft = 600;
						Main.projectile[num54].tileCollide=false;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(27, -1, -1, "", num54, 0f, 0f, 0f, 0);
						}
						f += .4f;
					}
					npc.ai[1] = -90;
					if (Main.netMode == 2 && num229 < 200)
					{
						NetMessage.SendData(23, -1, -1, "", num229, 0f, 0f, 0f, 0);
					}
				}
				return;
			}
		}
	}
}

public void NPCLoot()
{
	//ModWorld.armageddon++;
	int randomNum = Main.rand.Next(3);
	if (randomNum == 0) Item.NewItem((int)npc.position.X,(int)npc.position.Y,20,18,Config.itemDefs.byName["Armageddon Hat"].type,1,false);
	else if (randomNum == 1) Item.NewItem((int)npc.position.X,(int)npc.position.Y,38,20,Config.itemDefs.byName["Armageddon Suit"].type,1,false);
	else if (randomNum == 2) Item.NewItem((int)npc.position.X,(int)npc.position.Y,22,18,Config.itemDefs.byName["Armageddon Pants"].type,1,false);
	{
		{
		}
		if (Main.netMode == 0)
		{
		}
		else if (Main.netMode == 2)
		{
		}
	}
}