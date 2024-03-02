public bool SpawnNPC(int x, int y, int PID) {
    if (ModWorld.PoGoblinInvasion && Main.rand.Next(2) == 0) { // when the invasion is active, and a 1 in 3 chance
         return true; // let the npc be spawned
    }
    return false; // else: nope.avi
}

public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(3) == 0)
	{
		player.AddBuff(20, 300, false);
	}
}