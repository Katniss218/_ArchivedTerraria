public bool SpawnNPC(int x, int y, int playerID)
{
	if (ModWorld.WraithInvasion && Main.rand.Next(2) == 1) return true;
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(36, 10800, false);
	}
}