public void AI()
{
	if (npc.ai[0] == Main.myPlayer)
	{
	if (Main.rand.Next(2)==0)
	{
	Color color = new Color();
    	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 63, npc.velocity.X, npc.velocity.Y, 200, color, 1f);
    	Main.dust[dust].noGravity = true;
	}

	//npc.rotation += 0.3f;
    //npc.ai[0]; // Player's ID
	
	npc.target = (int) npc.ai[0];
	if (Main.player[npc.target].buffTime[(int)npc.ai[1]] <= 100)
	{
	npc.active = false;
	}
	else if (Main.player[npc.target].buffTime[(int)npc.ai[1]] < 600)
	{
	Main.player[npc.target].AddBuff(Config.buffID["Prince"], 600, false);
	}
	
	if (Main.player[npc.target].position.X+100 < npc.position.X || Main.player[npc.target].position.X-100 > npc.position.X || Main.player[npc.target].position.Y+100 < npc.position.Y || Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (Main.player[npc.target].position.X+100 < npc.position.X)
	{
	if (npc.velocity.X > -10) {npc.velocity.X -= 0.6f;}
	}
	else if (Main.player[npc.target].position.X-100 > npc.position.X)
	{
	if (npc.velocity.X < 10) {npc.velocity.X += 0.6f;}
	}
	if (Main.player[npc.target].position.Y+100 < npc.position.Y)
	{
	if (npc.velocity.Y > -10) npc.velocity.Y -= 0.6f;
	}
	else if (Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (npc.velocity.Y < 10) npc.velocity.Y += 0.6f;
	}
	}
	else
	{
	npc.velocity.X *= 0.94f; npc.velocity.Y *= 0.94f;
	npc.ai[2]++;
	if (npc.ai[2] == 60)
	{
	npc.velocity.X += Main.rand.Next(-5,5);
	npc.velocity.Y += Main.rand.Next(-5,5);
	npc.ai[2] = 0;
	}
	}
	
	if (npc.position.X > Main.player[npc.target].position.X)
	{
	npc.spriteDirection = 1;
	}
	else
	{
	npc.spriteDirection = -1;
	}
	}
}