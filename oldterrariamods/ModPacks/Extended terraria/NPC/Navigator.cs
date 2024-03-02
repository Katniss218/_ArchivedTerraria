public bool TownSpawn() {
	if(Main.hardMode && ModWorld.superHardmode) return true;
	else return false;
}
public string SetName()
{
	int result = Main.rand.Next(11);
	string name = "";
	
	if (result == 0)
        {
          name = "John";
        }
	else if (result == 1)
        {
          name = "Cameron";
        }
	else if (result == 2)
        {
          name = "Benjamin";
        }
	else if (result == 3)
        {
          name = "Samuel";
        }
	else if (result == 4)
        {
          name = "Miles";
        }
	else if (result == 5)
        {
          name = "Julian";
        }
	else if (result == 6)
        {
          name = "Roger";
        }
	else if (result == 7)
        {
          name = "Steven";
        }
	else if (result == 8)
        {
          name = "Tom";
        }
	else if (result == 9)
        {
          name = "Arnold";
        }
	else if (result == 10)
        {
          name = "Peter";
        }
	return name;
}
public string Chat()
{
	bool flag = false;
	for (int j = 0; j < 50; j++)
	{
		if (Main.npc[j].active && Main.npc[j].type == 108 && !Main.npc[j].homeless) flag = true;
	}

	string text = "";

	if (Main.bloodMoon)
	{
		int result = Main.rand.Next(3);
		if (result == 0) text = "Oh no! My compass isn't working! Must be the Blood Moon out there.";
		else if (result == 1) text = "...I wonder if I'll survive this night. I've never seen anything worse.";
		else if (result == 2) text = "I'm too scared to fight off these zombies. Can you do it so I can work on this watch?";
		//if (result == 0) text = "Quit it! You've broken my compass!";
		//else if (result == 1) text = "Go find someone else to show you the way!";
		//else if (result == 2) text = "I won't be bothered by scum like you.";
	}
	else
	{
		int result = Main.rand.Next(9);

		if (result == 0) text = "Navigating is easy if you have the right tools."; 
		else if (result == 1) text = "Navigation for the right price: cheap!"; 
		else if (result == 2) text = "Lost your way? I have exactly what you need!"; 
		else if (result == 3)
		{
			if (Main.dayTime) text = "Hard to port!";
			else
			{
				int randNum = Main.rand.Next(2);
				if (randNum == 0) text = "Hard to port!";
				else text = "Look up to find your way.";
			} 
		}
		else if (result == 4)
		{
			if (Main.dayTime) text = "Ahoy matey!";
			else
			{
				int randNum = Main.rand.Next(2);
				if (randNum == 0) text = "Ahoy matey!";
				else text = "The north star is exceptionally bright tonight.";
			} 
		}
		else if (result == 5) text = "...the arctangent of the angle of inclination-- Oh, did you need something?";
		else if (result == 6)
		{
			if (!NPC.savedWizard) text = "I once dreamt I was piloting a starship.";
			else if (NPC.savedWizard && flag)
			{
				int randomNum = Main.rand.Next(2);
				if (randomNum == 0) text = "I once dreamt I was piloting a starship.";
				else text = Main.chrName[108] + " doesn't know anything about stars!";
			}
		}
		else if (result == 7) text = "Compass: check. GPS: check. Watch: check. Sextant: Wait, I know I have one somewhere...";
		else if (result == 8) text = "My GPS keeps leading me astray. Care to help me fix it?";
	}
	return text;
}
public void SetupShop(Chest chest)
{
	int index=0;

	chest.item[index].SetDefaults("Compass");
	index++;
	chest.item[index].SetDefaults("GPS");
	chest.item[index].value = 200000;
	index++;
	chest.item[index].SetDefaults("Navigator's Array");
	index++;
	chest.item[index].SetDefaults("Gold Watch");
	index++;
	chest.item[index].SetDefaults("Silver Watch");
	index++;
	chest.item[index].SetDefaults("Copper Watch");
	index++;
	chest.item[index].SetDefaults("Depth Meter");
	index++;
	chest.item[index].SetDefaults("Navigation Potion");
	index++;
	if (Main.bloodMoon)
	{
		chest.item[index].SetDefaults("Shadow Potion");
		index++;
	}
	if (!Main.dayTime)
	{
		chest.item[index].SetDefaults("Torch");
		index++;
	}
	/*chest.item[index].SetDefaults("Musket Ball");
	chest.item[index].stack = 10000;
	index++;
	chest.item[index].SetDefaults("Silver Bullet");
	chest.item[index].stack = 200000;
	index++;
	chest.item[index].SetDefaults("Crystal Bullet");
	chest.item[index].stack = 400000;
	index++;
	chest.item[index].SetDefaults("Cursed Bullet");
	chest.item[index].stack = 400000;
	index++;*/
}
public void NPCLoot()
{
	Gore.NewGore(npc.position, npc.velocity, "Navigator Head Gore", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Navigator Arm Gore", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Navigator Arm Gore", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Navigator Leg Gore", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Navigator Leg Gore", 1f, -1);
}