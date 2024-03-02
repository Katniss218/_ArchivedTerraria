
public static void UseItem(Player player, int playerID)
{
	int targetX = Player.tileTargetX;
	int targetY = Player.tileTargetY;

	if (!IsSafe(targetX, targetY)) return;

	bool safe = false;
	int x = 0;int y = 0;

	for (int k = -2; k < 1; k++)
		if (IsSafe(targetX, targetY + k) && IsSafe(targetX, targetY + k + 1) && IsSafe(targetX, targetY + k + 2))
		{
			if (IsSafe(targetX + 1, targetY + k) && IsSafe(targetX + 1, targetY + k + 1) && IsSafe(targetX + 1, targetY + k + 2))
			{
				x = targetX;
				y = targetY + k;
				safe = true;
				break;
			}
			if (IsSafe(targetX - 1, targetY + k) && IsSafe(targetX - 1, targetY + k + 1) && IsSafe(targetX - 1, targetY + k + 2));
			{
				x = targetX - 1;
				y = targetY + k;
				safe = true;
				break;
			}
		}

	if (!safe) return;

	// move player to next portal
	player.noFallDmg = true;
	player.AddBuff(8, 120, false);
	player.position.X = x * 16 + 8;
	player.position.Y = y * 16;
	player.noFallDmg = false;
}

private static bool IsSafe(int x, int y)
{
	return !(Main.tile[x, y].active && Main.tileSolid[Main.tile[x, y].type]);;
}
