Vector2 initPosition;

public void Initialize()
{
	initPosition = projectile.position;
}

public void DealtNPC(NPC npc, double damage, Player player)
{
	npc.AddBuff(31, (int) Vector2.Distance(initPosition,projectile.position)/2, false);
	Main.PlaySound(2,(int)npc.position.X,(int)npc.position.Y,SoundHandler.soundID["bat_baseball_hit2"]);
}

public void DealtPVP(double damage, Player enemyPlayer)
{
	enemyPlayer.AddBuff(31, (int) Vector2.Distance(initPosition,projectile.position)/2, false);
	Main.PlaySound(2,(int)enemyPlayer.position.X,(int)enemyPlayer.position.Y,SoundHandler.soundID["bat_baseball_hit2"]);
}

public void AI()
{
	projectile.AI(true);
	projectile.rotation += 0.5f;
	//if (Main.rand.Next(4)==0)
	//{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 17, 0, 0, 150, Color.White, 0.5f);
	Main.dust[dust].noGravity = false;
	//}
}