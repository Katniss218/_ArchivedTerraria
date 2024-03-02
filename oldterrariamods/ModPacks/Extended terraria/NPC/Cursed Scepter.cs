public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zoneDungeon && Main.hardMode && Main.rand.Next(15) == 0)
	{
		return true;
	}
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(23, 180, false);
	}
}