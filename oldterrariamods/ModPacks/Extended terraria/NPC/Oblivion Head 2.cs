int astig = 0;
bool astigSpawned = false;

public void AI()
{
if (npc.ai[0] == 0f && Main.netMode != 1)
{
	npc.TargetClosest(true);
	npc.ai[0] = 1f;
}
/*if (Main.dayTime && npc.ai[1] != 3f && npc.ai[1] != 2f)
{
	npc.ai[1] = 2f;
	Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
}*/
if (Main.rand.Next(75) == 1)
{
	float Speed = 12f;
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	int damage = 68;
	Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
	float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
}
if (!Main.npc[(int)npc.ai[3]].active)
{
	npc.active = false;
}
if (npc.ai[1] == 0f)
{
	npc.defense = 10;
	npc.ai[2] += 1f;
	if (npc.ai[2] >= 800f)
	{
		npc.ai[2] = 0f;
		npc.ai[1] = 1f;
		npc.TargetClosest(true);
		npc.netUpdate = true;
	}
	npc.rotation = npc.velocity.X / 15f;
	if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
	{
		if (npc.velocity.Y > 0f)
		{
			npc.velocity.Y = npc.velocity.Y * 0.98f;
		}
		npc.velocity.Y = npc.velocity.Y - 0.02f;
		if (npc.velocity.Y > 2f)
		{
			npc.velocity.Y = 2f;
		}
	}
	else
	{
		if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
		{
			if (npc.velocity.Y < 0f)
			{
				npc.velocity.Y = npc.velocity.Y * 0.98f;
			}
			npc.velocity.Y = npc.velocity.Y + 0.02f;
			if (npc.velocity.Y < -2f)
			{
				npc.velocity.Y = -2f;
			}
		}
	}
	if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
	{
		if (npc.velocity.X > 0f)
		{
			npc.velocity.X = npc.velocity.X * 0.98f;
		}
		npc.velocity.X = npc.velocity.X - 0.05f;
		if (npc.velocity.X > 8f)
		{
			npc.velocity.X = 8f;
		}
	}
	if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
	{
		if (npc.velocity.X < 0f)
		{
			npc.velocity.X = npc.velocity.X * 0.98f;
		}
		npc.velocity.X = npc.velocity.X + 0.05f;
		if (npc.velocity.X < -8f)
		{
			npc.velocity.X = -8f;
		}
	}
}
else
{
	if (npc.ai[1] == 1f)
	{
		npc.defense = 0;
		npc.ai[2] += 1f;
		if (npc.ai[2] == 2f)
		{
			Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
		}
		if (npc.ai[2] >= 400f)
		{
			npc.ai[2] = 0f;
			npc.ai[1] = 0f;
		}
		npc.rotation += (float)npc.direction * 0.3f;
		Vector2 vector17 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
		float num180 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector17.X;
		float num181 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector17.Y;
		float num182 = (float)Math.Sqrt((double)(num180 * num180 + num181 * num181));
		num182 = 1.5f / num182;
		npc.velocity.X = num180 * num182;
		npc.velocity.Y = num181 * num182;
	}
	else
	{
		if (npc.ai[1] == 2f)
		{
			npc.damage = 9999;
			npc.defense = 9999;
			npc.rotation += (float)npc.direction * 0.3f;
			Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float num183 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector18.X;
			float num184 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector18.Y;
			float num185 = (float)Math.Sqrt((double)(num183 * num183 + num184 * num184));
			num185 = 8f / num185;
			npc.velocity.X = num183 * num185;
			npc.velocity.Y = num184 * num185;
		}
		else
		{
			if (npc.ai[1] == 3f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.1f;
				if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.95f;
				}
				npc.velocity.X = npc.velocity.X * 0.95f;
				if (npc.timeLeft > 500)
				{
					npc.timeLeft = 500;
				}
			}
		}
	}
	if (npc.life < (int)(npc.lifeMax / 2))
	{
		if (!astigSpawned)
		{
			astig = NPC.NewNPC((int) npc.position.X+(npc.width*2), (int) npc.position.Y+(npc.height/2), "Astigmatazer", 0);
			Main.npc[astig].target = npc.target;
			astigSpawned = true;
		}
	}
}
if (npc.ai[1] != 2f && npc.ai[1] != 3f && npc.type != 68)
{
	int num186 = Dust.NewDust(new Vector2(npc.position.X + (float)(npc.width / 2) - 15f - npc.velocity.X * 5f, npc.position.Y + (float)npc.height - 2f), 30, 10, 5, -npc.velocity.X * 0.2f, 3f, 0, default(Color), 2f);
	Main.dust[num186].noGravity = true;
	Dust expr_B88B_cp_0 = Main.dust[num186];
	expr_B88B_cp_0.velocity.X = expr_B88B_cp_0.velocity.X * 1.3f;
	Dust expr_B8A9_cp_0 = Main.dust[num186];
	expr_B8A9_cp_0.velocity.X = expr_B8A9_cp_0.velocity.X + npc.velocity.X * 0.4f;
	Dust expr_B8D3_cp_0 = Main.dust[num186];
	expr_B8D3_cp_0.velocity.Y = expr_B8D3_cp_0.velocity.Y + (2f + npc.velocity.Y);
	for (int num187 = 0; num187 < 2; num187++)
	{
		num186 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 120f), npc.width, 60, 5, npc.velocity.X, npc.velocity.Y, 0, default(Color), 2f);
		Main.dust[num186].noGravity = true;
		Main.dust[num186].velocity -= npc.velocity;
		Dust expr_B98C_cp_0 = Main.dust[num186];
		expr_B98C_cp_0.velocity.Y = expr_B98C_cp_0.velocity.Y + 5f;
	}
	return;
}
}
public void DamagePlayer(Player P, ref int damage) {
if (Main.rand.Next(5) == 1) {
P.AddBuff(32, 600); }
}
public void NPCLoot()
{
	Gore.NewGore(npc.position, npc.velocity, "Oblivion Gore 1", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Oblivion Gore 2", 1f, -1);
}