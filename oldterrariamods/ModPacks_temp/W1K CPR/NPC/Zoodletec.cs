public void AI()
{
if (Config.mods.IndexOf("Necro") != -1) npc.active = false;
}

public bool TownSpawn()
{
if (Config.mods.IndexOf("Necro") != -1) return false;
for (int num36 = 0; num36 < 200; num36++)
{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Zoodletec"].type)
	{
	return false;
	}
}
if (Main.hardMode && Config.mods.IndexOf("Necro") == -1) return true;
return false;
}

public string SetName()
{
	return "Zoodletec";
}

public string Chat() {
int x=Config.syncedRand.Next(5);
if(x==0)
{
	return "I put Bacon in your soap.";
}
if(x==1)
{
	return "I'm gonna sing the DOOM song now.";
}
if(x==2)
{
	return "I miss my cup cake.";
}
if(x==3)
{
	return "I made mashed po-ta-toes!";
}
if(x==4)
{
	return "Have you heard about my tConfig Modpacks? I sell some samples here. Go search it on TerrariaOnline for more!";
}
return "... ;)";
}

public void SetupShop(Chest chest)
{
	int index=0;
	chest.item[index].SetDefaults("Zoodle's Alien Mask");
	index++;	
	if (Config.mods.IndexOf("Binding of Terraria") == -1)
	{
	chest.item[index].SetDefaults("Zoodle's Meat Boy");
	index++;
	chest.item[index].SetDefaults("Zoodle's Sister Maggy");
	index++;
	}
	chest.item[index].SetDefaults("Zoodle's Alucard Jacket");
	index++;
	chest.item[index].SetDefaults("Zoodle's Alucard Leggings");
	index++;
	chest.item[index].SetDefaults("Zoodle's Alucard Mask");
	index++;
	chest.item[index].SetDefaults("Zoodle's Lisa Corset");
	index++;
	chest.item[index].SetDefaults("Zoodle's Lisa Dress");
	index++;
	chest.item[index].SetDefaults("Zoodle's Lisa Mask");
	index++;
	chest.item[index].SetDefaults("Zoodle's Maria Corset");
	index++;
	chest.item[index].SetDefaults("Zoodle's Maria Mask");
	index++;
	chest.item[index].SetDefaults("Zoodle's Maria Skirt");
	index++;
	chest.item[index].SetDefaults("Zoodle's Richter Belmont Jacket");
	index++;
	chest.item[index].SetDefaults("Zoodle's Richter Belmont Mask");
	index++;
	chest.item[index].SetDefaults("Zoodle's Richter Belmont Pants");
	index++;
}