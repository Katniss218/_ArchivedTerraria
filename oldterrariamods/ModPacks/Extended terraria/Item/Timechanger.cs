public void UseItem()
{
	Main.dayTime = !Main.dayTime;
	Main.time = 0;
	if (Main.netMode == 0)
	{
		if (Main.dayTime)
		{
			Main.NewText("It is now Day.", 50, 255, 130);
		}
		else Main.NewText("It is now Night.", 50, 255, 130);
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