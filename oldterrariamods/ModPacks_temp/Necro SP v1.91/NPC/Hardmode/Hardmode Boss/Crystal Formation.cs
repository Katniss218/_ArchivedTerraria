float customAi1;

#region PreDraw
public bool PreDraw(SpriteBatch spriteBatch)
{
	int direction = 0;
	if (Main.npc[(int)npc.ai[0]].spriteDirection == 1) direction = 33;
	if (Main.npc[(int)npc.ai[0]].spriteDirection == -1) direction = -33;
	
	Vector2 Ridley = new Vector2(Main.npc[(int)npc.ai[0]].position.X+(Main.npc[(int)npc.ai[0]].width/2)+direction,Main.npc[(int)npc.ai[0]].position.Y+(Main.npc[(int)npc.ai[0]].height/2)+22);
	Vector2 Tail = new Vector2(npc.position.X+(npc.width/2),npc.position.Y+(npc.height/2));
    ModWorld.DrawChain(Ridley, Tail, "Mother Vertabrate", spriteBatch);
	npc.rotation = (float)Math.Atan2(Ridley.Y-Tail.Y,Ridley.X-Tail.X)+(float) (Math.PI/2);
    return true;

	if (npc.life > 5000)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 59, npc.velocity.X, npc.velocity.Y, 200, color, 2f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 2000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 140, color, 4f);
    Main.dust[dust].noGravity = true;
	}
}
#endregion

#region AI
public void AI()
{
	if (!Main.npc[(int)npc.ai[0]].active)
	{
	npc.active = false;
	}
	
	npc.netUpdate = true;
	npc.ai[1]++;
	
	if (npc.velocity.X > 30 || npc.velocity.X < -30 || npc.velocity.Y > 30 || npc.velocity.Y < -30)
	{
	npc.velocity.X *= 0.75f;
	npc.velocity.Y *= 0.75f;
	}
	
	npc.target = Main.npc[(int)npc.ai[0]].target;
	
	if (npc.ai[2] < 200)
	{
	npc.ai[2]++;
	if (Main.npc[(int)npc.ai[0]].position.X < npc.position.X)
	{
	if (npc.velocity.X > 0) {npc.velocity.X -= 0.44f;}
	else if (npc.velocity.X > -8) {npc.velocity.X -= 0.33f;}
	}
	if (Main.npc[(int)npc.ai[0]].position.X > npc.position.X)
	{
	if (npc.velocity.X < 0) {npc.velocity.X += 0.44f;}
	else if (npc.velocity.X < 8) {npc.velocity.X += 0.33f;}
	}
	
	if (Main.npc[(int)npc.ai[0]].position.Y < npc.position.Y-200)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.npc[(int)npc.ai[0]].position.Y > npc.position.Y-200)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	}
	
	else if (npc.ai[2] >= 200)
	{
		float rotation = (float) Math.Atan2((npc.position.Y+(npc.height/2))-(Main.player[npc.target].position.Y+100+(Main.player[npc.target].height * 0.5f)), (npc.position.X+(npc.width/2))-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		npc.velocity.X = (float) (Math.Cos(rotation) * 50*(Vector2.Distance(Main.player[npc.target].position,npc.position)/200)/3)*-1;
		npc.velocity.Y = (float) (Math.Sin(rotation) * 50*(Vector2.Distance(Main.player[npc.target].position,npc.position)/200)/3)*-1;
		npc.ai[2] = 0;
	}
	if (npc.life > 3550)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 27, npc.velocity.X, npc.velocity.Y, 140, color, 2f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 2000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 27, npc.velocity.X, npc.velocity.Y, 140, color, 4f);
    Main.dust[dust].noGravity = true;
	}
#endregion

#region Projectile
    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
		if (Main.rand.Next(50)==1)
        {
			float num48 = 8f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			{
				float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				num51 = num48 / num51;
				speedX *= num51;
				speedY *= num51;
				int damage = 50;
				int type = Config.projectileID["Energy Shot"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }

		if (Main.rand.Next(75)==1)
        {
			float num48 = 8f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			{
				float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				num51 = num48 / num51;
				speedX *= num51;
				speedY *= num51;
				int damage = 60;
				int type = Config.projectileID["Energy Shot2"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
    }
}
#endregion