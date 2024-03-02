public void DealtNPC(NPC npc, double damage, Player player)
{
	if (projectile.penetrate != 1)
	{
		if (npc.type == Config.npcDefs.byName["Nightmare Hitbox1"].type || npc.type == Config.npcDefs.byName["Nightmare Hitbox2"].type || npc.type == Config.npcDefs.byName["Nightmare HitboxHead"].type)
		{
			npc.immune[player.whoAmi] = 10;
			foreach(NPC npc2 in Main.npc)
			{
				if (npc2.whoAmI != npc.whoAmI)
				{
					if (npc2.realLife == npc.realLife)
					{
						npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
					}
					if (npc2.whoAmI == npc.realLife)
					{
						npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
					}
				}
			}
		}
		if (npc.type == Config.npcDefs.byName["Nightmare HitboxCore"].type)
		{
			npc.immune[player.whoAmi] = 10;
			foreach(NPC npc2 in Main.npc)
			{
				if (npc2.realLife == npc.whoAmI)
				{
					npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
				}
			}
		}
	}
	else
	{
		if (npc.type == Config.npcDefs.byName["Nightmare Hitbox1"].type || npc.type == Config.npcDefs.byName["Nightmare Hitbox2"].type || npc.type == Config.npcDefs.byName["Nightmare HitboxHead"].type)
		{
			npc.immune[player.whoAmi] = 1;
			foreach(NPC npc2 in Main.npc)
			{
				if (npc2.whoAmI != npc.whoAmI)
				{
					if (npc2.realLife == npc.realLife)
					{
						npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
					}
					if (npc2.whoAmI == npc.realLife)
					{
						npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
					}
				}
			}
		}
		if (npc.type == Config.npcDefs.byName["Nightmare HitboxCore"].type)
		{
			npc.immune[player.whoAmi] = 1;
			foreach(NPC npc2 in Main.npc)
			{
				if (npc2.realLife == npc.whoAmI)
				{
					npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
				}
			}
		}
	}
}