public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer - 10 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(40) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void NPCLoot()
{
	int a = Projectile.NewProjectile(npc.position.X, npc.position.Y, 0f, 0f, 28, 50, 0f, 0);
	Main.projectile[a].timeLeft = 0;
}