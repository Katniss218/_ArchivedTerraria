//change day to night and vice versa
//sets time to beginning of next period (4:30 AM or 7:30 PM)

public void UseItem()
{
	Main.dayTime = !Main.dayTime;
	Main.time = 0;
	if (Main.netMode == 0)
	{
		if (Main.dayTime)
		{
			Main.NewText("You shift time forward and a new day begins...", 175, 75, 255);
		}
		else Main.NewText("You shift time forward and a new night begins...", 175, 75, 255);
	}
	else if (Main.netMode == 2)
	{
		if (Main.dayTime)
		{
			NetMessage.SendData(25, -1, -1, "It is now Day.", 255, 50f, 255f, 130f, 0);
		}
		else NetMessage.SendData(25, -1, -1, "It is now Night.", 255, 50f, 255f, 130f, 0);
	}
}

 //also can use it as a watch
public static void Effects(Player player) {
    player.accWatch = 3;
}





