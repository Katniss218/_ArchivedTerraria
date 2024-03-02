public int count = 0;
public void Effects(Player P, int buffIndex, int buffType, int buffTime)
{
	int x = (int)P.position.X;
	int y = (int)P.position.Y;
	for (int k = 0; k < Main.npc.Length; k++)
	{
		NPC N = Main.npc[k];
		if (N.townNPC) continue;
		if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
		if (N.position.X >= x - 320 && N.position.X <= x + 320 && N.position.Y >= y - 320 && N.position.Y <= y + 320)
		{
			count++;
			if (count % 50 == 0)
			{
				foreach (NPC N2 in Main.npc)
				{
					if (N2.position.X >= x - 320 && N2.position.X <= x + 320 && N2.position.Y >= y - 320 && N2.position.Y <= y + 320)
					{
						if (!N2.active || N2.dontTakeDamage || N2.townNPC || N2.life < 1 || N2.boss || N2.type == Config.npcDefs.byName["Juggernaut"].type || N2.realLife >= 0) continue;
						N2.StrikeNPC(1, 0f, 1);
					}
				}
				count = 0;
			}
		}
	}
}