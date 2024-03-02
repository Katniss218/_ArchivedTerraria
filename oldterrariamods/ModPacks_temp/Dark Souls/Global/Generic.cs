public void ModifySpawnList(List<int> spawns)
{

//Config.PrintConsole("EDITING SPAWNS");
	if(ModWorld.theEnd)
	{
		for(int m = 0; m < spawns.Count; m++)
		{
			int type = spawns[m];
			if(type >= 0 && Config.npcDefs[type].townNPC){ continue; }
			spawns.RemoveAt(m);
			m--;
		}
	}
}