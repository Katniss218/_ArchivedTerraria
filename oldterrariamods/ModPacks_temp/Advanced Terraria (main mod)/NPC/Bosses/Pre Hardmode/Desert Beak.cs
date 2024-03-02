public void AI()
{
	npc.ai[0]++;
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
	if (npc.ai[0] < 300)
	{
		Vector2 pVel = Main.player[npc.target].velocity;
		Vector2 pPos = Main.player[npc.target].position;
		if (pPos.X > npc.position.X)
		{
			if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
			//else npc.velocity.X = pVel.X;
		}
		if (pPos.X < npc.position.X)
		{
			if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
			//else npc.velocity.X = pVel.X;
		}
		if (pPos.Y > npc.position.Y + 300)
		{
			npc.dontTakeDamage = false;
			if (npc.velocity.Y > 0)
			{
				if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
			}
			else npc.velocity.Y += 0.6f;
		}
		if (pPos.Y < npc.position.Y + 200)
		{
			//npc.dontTakeDamage = false;
			if (npc.velocity.Y < 0)
			{
				if (npc.velocity.Y > -3) npc.velocity.Y -= 0.6f;
			}
			else npc.velocity.Y -= 0.5f;
		}
		if (pPos.Y + 75 < npc.position.Y)
		{
			npc.dontTakeDamage = true;
			npc.ai[1]++;
			if (npc.ai[1] >= 60)
			{
				float Speed = 8f;
				Vector2 npcPosRefined = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				Main.PlaySound(2, (int) npc.position.X, (int)npc.position.Y, 17);
				float rotation = (float)Math.Atan2(npcPosRefined.Y-(pPos.Y+(Main.player[npc.target].height * 0.5f)), npcPosRefined.X-(pPos.X+(Main.player[npc.target].width * 0.5f)));
				Projectile.NewProjectile(npcPosRefined.X, npcPosRefined.Y, (float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), Config.projDefs.byName["Beak"].type, 40, 0f, 0);
				npc.ai[1] = 0;
			}
		}
	}
	else if (npc.ai[0] >= 300 && npc.ai[0] < 330)
	{
		npc.dontTakeDamage = false;
		if (npc.velocity.X == 0) npc.velocity.X = 1;
		if (npc.velocity.Y == 0) npc.velocity.Y = 1;
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((vector8.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (vector8.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float)(Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float)(Math.Sin(rotation) * 25)*-1;
		}
	}
	else if (npc.ai[0] >= 330 && npc.ai[0] < 600)
	{
		npc.dontTakeDamage = false;
		Vector2 pVel = Main.player[npc.target].velocity;
		Vector2 pPos = Main.player[npc.target].position;
		if (pPos.X > npc.position.X)
		{
			if (npc.velocity.X < 7) npc.velocity.X += 0.22f;
		}
		if (pPos.X < npc.position.X)
		{
			if (npc.velocity.X > -7) npc.velocity.X -= 0.22f;
		}
		if (pPos.Y > npc.position.Y + 300)
		{
			if (npc.velocity.Y > 0)
			{
				if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
			}
			else npc.velocity.Y += 0.6f;
		}
		if (pPos.Y < npc.position.Y + 250)
		{
			if (npc.velocity.Y < 0)
			{
				if (npc.velocity.Y > -3) npc.velocity.Y -= 0.6f;
			}
			else npc.velocity.Y -= 0.5f;
		}
		npc.ai[2]++;
		if (npc.ai[2] >= 90)
		{
			float Speed = 5f;
			Vector2 npcPosRefined = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			Main.PlaySound(2, (int) npc.position.X, (int)npc.position.Y, 11);
			float rotation = (float)Math.Atan2(npcPosRefined.Y-(pPos.Y+(Main.player[npc.target].height * 0.5f)), npcPosRefined.X-(pPos.X+(Main.player[npc.target].width * 0.5f)));
			Projectile.NewProjectile(npcPosRefined.X, npcPosRefined.Y, (float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 102, 20, 0f, 0);
			npc.ai[2] = 0;
		}
	}
	else npc.ai[0] = 0;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Desert Beak Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Beak Wing",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Beak Wing",1f,-1);
}