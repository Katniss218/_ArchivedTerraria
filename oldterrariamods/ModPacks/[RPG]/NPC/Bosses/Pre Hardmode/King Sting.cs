public void AI()
{
	npc.ai[0]++;
	npc.ai[1]++;
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
	if (npc.justHit)
	{
		Dust.NewDust(npc.position, npc.width, npc.height, 18, 0.2f, 0.2f, 100, default(Color), 1f);
		Dust.NewDust(npc.position, npc.width, npc.height, 18, 0.2f, 0.2f, 100, default(Color), 1f);
		Dust.NewDust(npc.position, npc.width, npc.height, 18, 0.2f, 0.2f, 100, default(Color), 1f);
	}
	if (npc.ai[1] < 300)
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
				if (npc.velocity.Y > -3) npc.velocity.Y -= 0.6f;
			}
			else npc.velocity.Y -= 0.5f;
		}

		if (Main.player[npc.target].position.Y > npc.position.Y+250)
		{
			if (npc.velocity.Y > 0)
			{
				if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
			}
			else npc.velocity.Y += 0.6f;
		}
	}
	else if (npc.ai[1] >= 300 && npc.ai[1] < 330)
	{
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((vector8.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (vector8.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float) (Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 25)*-1;
		}
	}
	else npc.ai[1] = 0;
	if (npc.ai[0] >= 120)
	{
		float Speed = 12f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
		int damage = 20;
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 55, damage, 0f, 0);
		npc.ai[0] = 0;
	}
	if (Main.player[npc.target].dead)
	{
		npc.velocity.Y -= 0.04f;
		if (npc.timeLeft > 10)
		{
			npc.timeLeft = 10;
			return;
		}
	}
	if (npc.life <= 0)
	{
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,16,18,"Stinger",209,false,2);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,18,18,"Heart",58,false,10);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,20,26,"Lesser Healing Potion",28,false,7);
		Main.NewText("King Sting has been defeated!", 175, 75, 255);
	}
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"King Sting Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"King Sting Wing",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"King Sting Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"King Sting Stinger",1f,-1);
}