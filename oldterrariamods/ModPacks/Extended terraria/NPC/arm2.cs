#region PreDraw() (chain)
public bool PreDraw(SpriteBatch spriteBatch)
{
	int direction = 0;
	
	if (Main.npc[(int)npc.ai[0]].spriteDirection == 1) direction = 33;
	if (Main.npc[(int)npc.ai[0]].spriteDirection == -1) direction = -33;
	
	Vector2 head1 = new Vector2(Main.npc[(int)npc.ai[0]].position.X+(Main.npc[(int)npc.ai[0]].width/2)+direction,Main.npc[(int)npc.ai[0]].position.Y+(Main.npc[(int)npc.ai[0]].height/2)+22);
	Vector2 arm2 = new Vector2(npc.position.X+(npc.width/2),npc.position.Y+(npc.height/2));
    //ModWorld.DrawChain(head1, arm2, "Oblivion Chain", spriteBatch);
	npc.rotation = (float)Math.Atan2(head1.Y-arm2.Y,head1.X-arm2.X)+(float) (Math.PI/2);
    return true;
}
#endregion

public void AI()
{
	npc.AI(true);
}

#region NPCLoot()
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Oblivion Arm 12 Gore",1f,-1);
}
#endregion

public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		P.AddBuff("Frozen", 120, false);
	}
}