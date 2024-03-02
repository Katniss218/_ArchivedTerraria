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
	if (Main.rand.Next(75) == 0)
	{
		float Speed = 12f;
		Vector2 vector8 = new Vector2(npc.position.X + 70, npc.position.Y + 112);
		int damage = 60;
		int type = Config.projectileID["Dark Flames"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
	}
	npc.AI(true);
}

#region NPCLoot()
public void NPCLoot()
{

}
#endregion

public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		P.AddBuff("Frozen", 120, false);
	}
}