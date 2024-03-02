//npc.ai[2] FRAMES

public bool PreDraw(SpriteBatch spriteBatch)
{
	int direction = 0;
	if (Main.npc[(int)npc.ai[0]].spriteDirection == 1) direction = 33;
	if (Main.npc[(int)npc.ai[0]].spriteDirection == -1) direction = -33;
	
	Vector2 Ridley = new Vector2(Main.npc[(int)npc.ai[0]].position.X+(Main.npc[(int)npc.ai[0]].width/2)+direction,Main.npc[(int)npc.ai[0]].position.Y+(Main.npc[(int)npc.ai[0]].height/2)+22);
	Vector2 Tail = new Vector2(npc.position.X+(npc.width/2),npc.position.Y+(npc.height/2));
    ModWorld.DrawChain(Ridley, Tail, "ridleyTail", spriteBatch);
	npc.rotation = (float)Math.Atan2(Ridley.Y-Tail.Y,Ridley.X-Tail.X)+(float) (Math.PI/2);
    return true;
}

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
	
	if (Main.npc[(int)npc.ai[0]].position.Y < npc.position.Y-300)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.npc[(int)npc.ai[0]].position.Y > npc.position.Y-300)
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
}