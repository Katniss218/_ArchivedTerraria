public void AI()
{
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Freeze"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		npc.TargetClosest(true);
	}
	if ((double)npc.life > (double)(npc.lifeMax / 2))
	{
		int dir = 1;
		npc.ai[0]++;
		if (npc.ai[0] < 750)
		{
			if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
			{
				dir = -1;
			}
			else dir = 1;
			Vector2 npcPosRef = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float pposx = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(dir * 250) - npcPosRef.X;
			float pposy = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 250f - npcPosRef.Y;
			float posMod = (float)Math.Sqrt((double)(pposx * pposx + pposy * pposy));
			posMod = 12f / posMod;
			pposx *= posMod;
			pposy *= posMod;
			if (npc.velocity.X < pposx)
			{
				npc.velocity.X = npc.velocity.X + 0.4f;
				if (npc.velocity.X < 0f && pposx > 0f)
				{
					npc.velocity.X = npc.velocity.X + 0.4f;
				}
			}
			else
			{
				if (npc.velocity.X > pposx)
				{
					npc.velocity.X = npc.velocity.X - 0.4f;
					if (npc.velocity.X > 0f && pposx < 0f)
					{
						npc.velocity.X = npc.velocity.X - 0.4f;
					}
				}
			}
			if (npc.velocity.Y < pposy)
			{
				npc.velocity.Y = npc.velocity.Y + 0.4f;
				if (npc.velocity.Y < 0f && pposy > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.4f;
				}
			}
			else
			{
				if (npc.velocity.Y > pposy)
				{
					npc.velocity.Y = npc.velocity.Y - 0.4f;
					if (npc.velocity.Y > 0f && pposy < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - 0.4f;
					}
				}
			}
			npc.ai[1]++;
			if (npc.ai[1] >= 90)
			{
				float Speed = 13f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				int damage = 45;
				int type = 96;
				Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 20);
				float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
				npc.ai[1] = 0;
			}
		}
		else if (npc.ai[0] >= 750 && npc.ai[0] < 1350)
		{
			if (npc.ai[3] == 0f)
			{
				Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
				float num384 = 14f;
				Vector2 vector39 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num385 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector39.X;
				float num386 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector39.Y;
				float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
				num387 = num384 / num387;
				npc.velocity.X = num385 * num387;
				npc.velocity.Y = num386 * num387;
				npc.ai[3] = 1f;
				return;
			}
			if (npc.ai[3] == 1f)
			{
				npc.ai[2] += 1f;
				if (npc.ai[2] >= 50f)
				{
					npc.velocity.X *= 0.98f;
					npc.velocity.Y *= 0.98f;
					/*if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
					{
						npc.velocity.X = 0f;
					}
					if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
					{
						npc.velocity.Y = 0f;
					}*/
				}
				if (npc.ai[2] >= 80f)
				{
					npc.position.Y -= 500f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					return;
				}
			}
		}
		else npc.ai[0] = 0;
	}
	else
	{
		npc.soundHit = 4;
		npc.damage = (int)((double)npc.defDamage * 1.5);
		npc.defense = npc.defDefense + 25;
		npc.ai[0]++;
		if (npc.ai[0] < 300)
		{
			if (Main.player[npc.target].position.X < npc.position.X)
			{
				if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
			}
			if (Main.player[npc.target].position.X > npc.position.X)
			{
				if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
			}
			if (Main.player[npc.target].position.Y < npc.position.Y+250)
			{
				if (npc.velocity.Y < 0)
				{
					if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
				}
				else npc.velocity.Y -= 0.6f;
			}
			if (Main.player[npc.target].position.Y > npc.position.Y+250)
			{
				if (npc.velocity.Y > 0)
				{
					if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
				}
				else npc.velocity.Y += 0.6f;
			}
			npc.ai[1]++;
			if (npc.ai[1] >= 40)
			{
				float Speed = 8f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				int damage = 65;
				int type = 100;
				Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
				float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
				npc.ai[1] = 0;
			}
		}
		else if (npc.ai[0] >= 300 && npc.ai[0] < 600)
		{
			if (Main.player[npc.target].position.X < npc.position.X)
			{
				if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
			}
			if (Main.player[npc.target].position.X > npc.position.X)
			{
				if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
			}
			if (Main.player[npc.target].position.Y < npc.position.Y+250)
			{
				if (npc.velocity.Y < 0)
				{
					if (npc.velocity.Y > -3) npc.velocity.Y -= 0.7f;
				}
				else npc.velocity.Y -= 0.6f;
			}
			if (Main.player[npc.target].position.Y > npc.position.Y+250)
			{
				if (npc.velocity.Y > 0)
				{
					if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
				}
				else npc.velocity.Y += 0.6f;
			}
			float num381 = 6f;
			int num382 = 50;
			int num383 = 101;
			Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 34);
			Vector2 vector38 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float num378 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector38.X;
			float num379 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector38.Y;
			float num380 = (float)Math.Sqrt((double)(num378 * num378 + num379 * num379));
			num380 = num381 / num380;
			num378 *= num380;
			num379 *= num380;
			num379 += (float)Main.rand.Next(-40, 41) * 0.01f;
			num378 += (float)Main.rand.Next(-40, 41) * 0.01f;
			num379 += npc.velocity.Y * 0.5f;
			num378 += npc.velocity.X * 0.5f;
			vector38.X -= num378 * 1f;
			vector38.Y -= num379 * 1f;
			Projectile.NewProjectile(vector38.X, vector38.Y, num378, num379, num383, num382, 0f, Main.myPlayer);
		}
		else npc.ai[0] = 0;
	}
	if (Main.player[npc.target].dead) npc.TargetClosest(true);
	if (Main.player[npc.target].dead || npc.target == 255 || !Main.player[npc.target].active)
	{
		if (npc.timeLeft > 10) npc.timeLeft = 10;
	}
}
public void DamagePlayer(Player P, ref int dmg)
{
	if (Main.rand.Next(1) == 0)
	{
		P.AddBuff("Fracturing Armor", 1200, false);
	}
}