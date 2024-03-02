int TimerHeal = 0;
float TimerAnim = 0;

#region AI
public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 200, color, 2.0f);
	Main.dust[dust].noGravity = true;

	if (Main.npc[(int) npc.ai[1]].active)
	{
		if (Main.npc[(int) npc.ai[1]].ai[2] == -1)
		{
			if (Main.netMode == 1) npc.ai[3] += 0.5f;
			if (Main.netMode < 1) npc.ai[3]++; 
			npc.TargetClosest();
			if (npc.ai[3] >= 0)
			{
				if (Main.netMode != 2 && npc.ai[3] % 7 == 0)
				{
					float num48 = 0.5f;
					float rotation = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y, npc.Center.X-Main.player[npc.target].Center.X);
					rotation += Config.syncedRand.Next(-50,50)/100;
					int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Tortured Soul", 50, 0f, Main.myPlayer);
					if (npc.ai[3] >= 35) npc.ai[3] = -100-Config.syncedRand.Next(100);
				}
			}
		}
	}
}
#endregion