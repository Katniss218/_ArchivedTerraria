public bool SpawnNPC(int x, int y, int PID) {
    if (ModWorld.PoGoblinInvasion && Main.rand.Next(2) == 0) {
         return true;
    }
    return false;
}

public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(3) == 0)
	{
		player.AddBuff(20, 300, false);
	}
}