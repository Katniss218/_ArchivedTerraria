public void AI()
{
	npc.TargetClosest(true);
	float num74 = 0.05f;
	Vector2 vector11 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
	float num75 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
	float num76 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
	num75 = (float)((int)(num75 / 8f) * 8);
	num76 = (float)((int)(num76 / 8f) * 8);
	vector11.X = (float)((int)(vector11.X / 8f) * 8);
	vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
	num75 -= vector11.X;
	num76 -= vector11.Y;
	float num77 = (float)Math.Sqrt((double)(num75 * num75 + num76 * num76));
	float num78 = num77;

	if (num78 > 100f)
	{
		npc.ai[0] += 1f;
		if (npc.ai[0] > 0f)
		{
			npc.velocity.Y = npc.velocity.Y + 0.023f;
		}
		else
		{
			npc.velocity.Y = npc.velocity.Y - 0.023f;
		}
		if (npc.ai[0] < -100f || npc.ai[0] > 100f)
		{
			npc.velocity.X = npc.velocity.X + 0.023f;
		}
		else
		{
			npc.velocity.X = npc.velocity.X - 0.023f;
		}
		if (npc.ai[0] > 200f)
		{
			npc.ai[0] = -200f;
		}
	}
	if (num78 < 150f)
	{
		npc.velocity.X = npc.velocity.X + num75 * 0.007f;
		npc.velocity.Y = npc.velocity.Y + num76 * 0.007f;
	}
	if (npc.velocity.X < num75)
	{
		npc.velocity.X = npc.velocity.X + num74;
	}
	npc.ai[1]++;
	if (npc.ai[1] >= 150)
	{
		float Speed = 13f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
		int damage = 70;
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
		npc.ai[1] = 0;
	}
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(10) == 0)
	{
		player.AddBuff(20, 420, false);
	}
}