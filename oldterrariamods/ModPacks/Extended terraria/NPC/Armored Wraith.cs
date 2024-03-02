public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.moonPhase == 4)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && y < Main.rockLayer + 10 && Main.rand.Next(10) == 0)
			{
				return true;
			}
			else return false;
		}
		else if (Main.moonPhase != 4)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && y < Main.rockLayer + 10 && Main.rand.Next(25) == 0)
			{
				return true;
			}
			else return false;
		}
		else return false;
	}
	if (ModWorld.WraithInvasion && Main.rand.Next(4) == 1) return true;
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(36, 10800, false);
	}
}