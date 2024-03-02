int Timer = -Main.rand.Next(800);

public void AI()
{
npc.TargetClosest(true);
Timer++;

if (!Main.npc[(int)npc.ai[1]].active)
{
	npc.life = 0;
	npc.HitEffect(0, 10.0);
	npc.active = false;
}
if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = 1;
}
if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = -1;
}

	if (Timer >= 0)
	{
		if (Main.netMode != 2)
		{
			float num48 = 1f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Main.rand.Next(-50,50)/100;
            int damage = 60;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Metal Dragon Saw", 30, 0f, 0);
			Timer = -300-Main.rand.Next(300);
		}
	}
{
					Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
	                Color color = new Color();
                    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 58, npc.velocity.X, npc.velocity.Y, 100, color, 3f);
                    Main.dust[dust].noGravity = true;
}
npc.AI(true);
}