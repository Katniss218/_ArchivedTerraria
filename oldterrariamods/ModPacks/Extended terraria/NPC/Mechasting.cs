public void AI() {
	npc.TargetClosest(true);

	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Freeze"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Gold Inferno"])
		{
			npc.lifeRegen = -20;
		}
	}
	if (Main.player[npc.target].position.X < npc.position.X)
	{
		if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
	}

	if (Main.player[npc.target].position.X > npc.position.X)
	{
		if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
	}

	if (Main.player[npc.target].position.Y < npc.position.Y+300)
	{
		if (npc.velocity.Y < 0)
		{
			if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
		}
		else npc.velocity.Y -= 0.6f;
	}

	if (Main.player[npc.target].position.Y > npc.position.Y+300)
	{
		if (npc.velocity.Y > 0)
		{
			if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
		}
		else npc.velocity.Y += 0.6f;
	}
	npc.ai[0]++;
	if (npc.ai[0] >= 70)
	{
		float Speed = 12f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
		int damage = 45;
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
		npc.ai[0] = 0;
	}
	npc.ai[1]++;
	if (npc.ai[1] >= 300)
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
	//if (npc.life == 0) {
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,14,16,"Gold Coin",73,false,11);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,16,18,"Stinger",209,false,6);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,16,18,"Soul of Delight",209,false,25);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,18,18,"Heart",58,false,10);
	//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,20,26,"Greater Healing Potion",499,false,10);
	//	Main.NewText("Mechasting has been defeated!", 175, 75, 255);
	//}
	npc.ai[2]++;
	if (npc.ai[2] >= 60)
	{
		NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, Config.npcDefs.byName["Stinger Probe"].type, npc.target);
		npc.ai[2] = 0;
	}
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(10) == 0)
	{
		player.AddBuff(20, 420, false);
	}
}