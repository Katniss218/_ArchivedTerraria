public bool SpawnNPC(int x, int y, int PID)
{
    //if (Main.hardMode && ModWorld.superHardmode)
    //{
		if (Main.player[PID].townNPCs < 1 && Main.tile[x, y].liquid >= 16 && Main.player[PID].zone["Tropics"] && Main.rand.Next(6) == 0)
		{
			return true;
		}
	//}
	return false;
}
public void HitEffect(int hitDirection, double dmg)
{
    if (npc.life > 0)
    {
        int num131 = 0;
        while ((double)num131 < dmg / (double)npc.lifeMax * 150.0)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 1f);
            num131++;
        }
    }
    else {
        Gore.NewGore(npc.position, npc.velocity * 0.8f, 89, 1f);
        Gore.NewGore(new Vector2(npc.position.X + 14f, npc.position.Y), npc.velocity * 0.8f, 90, 1f);
        Gore.NewGore(new Vector2(npc.position.X + 14f, npc.position.Y), npc.velocity * 0.8f, 91, 1f);
        Gore.NewGore(new Vector2(npc.position.X + 14f, npc.position.Y), npc.velocity * 0.8f, 92, 1f);
    }
    for (int num136 = 0; num136 < 75; num136++)
    {
        Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
    }
}