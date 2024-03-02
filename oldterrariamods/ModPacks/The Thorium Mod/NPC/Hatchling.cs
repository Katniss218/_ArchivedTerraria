public void AI()
{
	npc.AI(true);
	if (npc.ai[0] != 0f)
	{
		if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
		{
			npc.ai[3]++;
			if (npc.ai[3] >= 120)
			{
				float Speed = 8f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				int damage = 3;
				int type = 38;
				Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 20);
				float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
				npc.ai[3] = 0;
			}
		}
	}
}

public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Thunder Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thunder Wing",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thunder Leg",1f,-1);
}