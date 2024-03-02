int Timer = -Main.rand.Next(800);

#region AI
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
#endregion

#region Saw Attack
	if (Timer >= 0)
	{
		if (Main.netMode != 2)
		{
			float num48 = 1f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Main.rand.Next(-50,50)/100;
            int damage = 75;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Dragon Saw3", 30, 0f, 0);
			Timer = -300-Main.rand.Next(300);
		}
	}
{
					Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					Vector2 arg_1394_0 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_1394_1 = this.npc.width;
					int arg_1394_2 = this.npc.height;
					int arg_1394_3 = 15;
			        float arg_1394_4 = 0f;
			        float arg_1394_5 = 0f;
			        int arg_1394_6 = 100;
			        Color newColor = default(Color);
			        int num41 = Dust.NewDust(arg_1394_0, arg_1394_1, arg_1394_2, arg_1394_3, arg_1394_4, arg_1394_5, arg_1394_6, newColor, 2f);
			        Main.dust[num41].noGravity = true;
}
npc.AI(true);
}
#endregion


