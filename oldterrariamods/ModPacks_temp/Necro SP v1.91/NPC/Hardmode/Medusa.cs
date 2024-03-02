#region AI
public void AI()
{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 44, npc.velocity.X, npc.velocity.Y, 200, color, 1f);
    Main.dust[dust].noGravity = true;
	npc.TargetClosest();
	if (npc.velocity.Y == 0 && npc.velocity.X == 0)
	{
	if (npc.position.X > Main.player[npc.target].position.X)
	{
	npc.velocity.X = -3;
	npc.spriteDirection = 1;
	}
	else
	{
	npc.velocity.X = 3;
	npc.spriteDirection = -1;
	}
	if (Main.rand.Next(2)==0)
	{
		npc.ai[0] = 1;
	}
	else
	{
		npc.ai[0] = -1;
	}
	}
	
	if (npc.ai[0] == 1)
	{
		npc.velocity.Y += 0.2f;
		if (npc.velocity.Y > 6) npc.ai[0] = -1;
	}
	else
	{
		npc.velocity.Y -= 0.2f;
		if (npc.velocity.Y < -6) npc.ai[0] = 1;
	}
}
#endregion

#region Loot
public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Medusa Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Medusa Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Medusa Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Medusa Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Medusa Gore 3", 1f, -1);
}
}
#endregion