public static void UseItem(Player P, int pID)
{
	Main.moonPhase++;
	if (Main.moonPhase >= 8) Main.moonPhase = 0;
	if (Main.netMode == 0)
	{
		if (Main.moonPhase == 0)
		{
			Main.NewText("Moon Phase changed to Full.", 50, 255, 130);
		}
		else if (Main.moonPhase == 1)
		{
			Main.NewText("Moon Phase changed to Last Gibbous.", 50, 255, 130);
		}
		else if (Main.moonPhase == 2)
		{
			Main.NewText("Moon Phase changed to Last Quarter.", 50, 255, 130);
		}
		else if (Main.moonPhase == 3)
		{
			Main.NewText("Moon Phase changed to Last Crescent.", 50, 255, 130);
		}
		else if (Main.moonPhase == 4)
		{
			Main.NewText("Moon Phase changed to New.", 50, 255, 130);
		}
		else if (Main.moonPhase == 5)
		{
			Main.NewText("Moon Phase changed to First Crescent.", 50, 255, 130);
		}
		else if (Main.moonPhase == 6)
		{
			Main.NewText("Moon Phase changed to First Quarter.", 50, 255, 130);
		}
		else if (Main.moonPhase == 7)
		{
			Main.NewText("Moon Phase changed to First Gibbous.", 50, 255, 130);
		}
	}
	else if (Main.netMode == 2)
	{
		if (Main.moonPhase == 0)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to Full.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 1)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to Last Gibbous.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 2)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to Last Quarter.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 3)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to Last Crescent.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 4)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to New.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 5)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to First Crescent.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 6)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to First Quarter.", 255, 50f, 255f, 130f, 0);
		}
		if (Main.moonPhase == 7)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase changed to First Gibbous.", 255, 50f, 255f, 130f, 0);
		}
	}
}