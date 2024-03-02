public void UpdateSpawn() {	
	if (ModWorld.PoGoblinInvasion)
	{
		//SoundHandler.SetMusicVanilla(12);
		NPC.spawnRate = 30;
		NPC.maxSpawns = 20;
		for (int k = 0; k < 50; k++)
		{
			if (Main.npc[k].townNPC) continue;
			int NT = Main.npc[k].type;
			if (NT != Config.npcDefs.byName["Poison Goblin Archer"].type && 
				NT != Config.npcDefs.byName["Poison Goblin Peon"].type && 
				NT != Config.npcDefs.byName["Poison Goblin Sorcerer"].type && 
				NT != Config.npcDefs.byName["Poison Goblin Thief"].type && 
				NT != Config.npcDefs.byName["Poison Goblin Warrior"].type &&
				NT != Config.npcDefs.byName["Chaos Ball"].type &&
				NT != Config.npcDefs.byName["Eye Pet"].type &&
				NT != Config.npcDefs.byName["Aku-Aku"].type)
			{
				Main.npc[k].active = false;
			}
		}
	}
}