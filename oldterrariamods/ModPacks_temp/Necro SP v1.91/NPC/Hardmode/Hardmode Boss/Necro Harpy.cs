#region AI
public void AI()
{
	npc.netUpdate = true;
	npc.ai[2]++;
	npc.ai[1]++;
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	if (npc.ai[2] < 600)
	{
	if (Main.player[npc.target].position.X < npc.position.X)
	{
	if (npc.velocity.X > -8) {npc.velocity.X -= 0.22f;}
	}
	if (Main.player[npc.target].position.X > npc.position.X)
	{
	if (npc.velocity.X < 8) {npc.velocity.X += 0.22f;}
	}
	
	if (Main.player[npc.target].position.Y < npc.position.Y+300)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.player[npc.target].position.Y > npc.position.Y+300)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	
#region Projectile
	if (npc.ai[1] >= 0 && npc.ai[2] > 120 && npc.ai[2] < 600)
	{
		if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)) && Main.netMode != 2)
		{
			float num48 = 12f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			int damage = 30;
			int type = Config.projectileID["Necro Shot"];
            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, 0);
			Main.projectile[num54].timeLeft = 300;
			Main.projectile[num54].tileCollide=false;
			num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation+0.4) * num48)*-1),(float)((Math.Sin(rotation+0.4) * num48)*-1), type, damage, 0f, 0);
			Main.projectile[num54].timeLeft = 300;
			Main.projectile[num54].tileCollide=false;
			num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation-0.4) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, 0);
			Main.projectile[num54].timeLeft = 300;
			Main.projectile[num54].tileCollide=false;
			npc.ai[1] = -90;
		}
	}
	}
#endregion

	else if (npc.ai[2] >= 600 && npc.ai[2] < 1200)
	{
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((npc.position.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (npc.position.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float) (Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 25)*-1;
		}
	}
	else npc.ai[2] = 0;
	
	if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
	}
	if (npc.life > 4555)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 5, npc.velocity.X, npc.velocity.Y, 200, color, 1f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 5000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 5, npc.velocity.X, npc.velocity.Y, 140, color, 2f);
    Main.dust[dust].noGravity = true;
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
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Necro Harpy Gore 3", 1f, -1);
        }
}
#endregion