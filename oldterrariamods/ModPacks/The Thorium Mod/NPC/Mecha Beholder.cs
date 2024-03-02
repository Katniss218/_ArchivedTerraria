public void NPCLoot()
{
	Rectangle R = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
	int C = 50;
	float vR = 0.4f;
	for (int i = 1; i <= C; i++)
	{
		int D = Dust.NewDust(npc.position, R.Width, R.Height, 54, 0, 0, 100, new Color(), 2f);
		Main.dust[D].noGravity = true;
		Main.dust[D].velocity.X = vR * (Main.dust[D].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[D].velocity.Y = vR * (Main.dust[D].position.Y - (npc.position.Y + (npc.height/2)));
    }
	for (int i2 = 1; i2 <= C; i2++)
	{
		int D2 = Dust.NewDust(npc.position, R.Width, R.Height, 1, 0, 0, 100, new Color(), 1f);
		Main.dust[D2].noGravity = true;
		Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (npc.position.Y + (npc.height/2)));
    }
    int pr = Projectile.NewProjectile(npc.position.X + (int)npc.width / 2, npc.position.Y + (int)npc.height / 2, 0f, 0f, 30, 0, 0f, npc.target);
    Main.projectile[pr].Kill();
}