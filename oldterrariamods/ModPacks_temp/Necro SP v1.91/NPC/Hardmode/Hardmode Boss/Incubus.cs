public void DealtNPC(double damage, Player player)
{
	if (Main.rand.Next(2) == 0)
	{
	npc.ai[2] = 1;
	}
}

#region Mob Spawn
public void AI()
{
	npc.TargetClosest();
	npc.netUpdate = false;
	npc.ai[1]++;
	if (npc.ai[1] >= 90 && Main.netMode != 1)
	{
		int Succubusspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Succubus", 0);
		npc.ai[1] = 20-Main.rand.Next(80);
		if (Main.netMode == 2 && Succubusspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", Succubusspawn, 0f, 0f, 0f, 0);
		}
	}
#endregion

#region Projectile
	if (npc.ai[2] == 1 && Main.netMode != 2)
	{
	npc.ai[2] = 0;
	float num48 = 1f;
	int damageproj = 65;
	int type = Config.projectileID["Burning Ball"];
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	if (Main.player[npc.target].position.X > vector8.X-250 && Main.player[npc.target].position.X < vector8.X+250 && Main.player[npc.target].position.Y > vector8.Y-150 && Main.player[npc.target].position.Y < vector8.Y+150)
	{
	Main.player[npc.target].AddBuff(20, 150, false);
	}
	float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damageproj, 0f, 0);
	Main.projectile[num54].timeLeft = 75;
	}
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 2.5f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Incubus Gore 3", 1f, -1);
        }
}
#endregion