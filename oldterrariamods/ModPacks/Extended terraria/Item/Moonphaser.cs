public void UseItem(Player P, int pID)
{
	Main.moonPhase++;
	if (Main.moonPhase >= 8) Main.moonPhase = 0;
	if (Main.netMode == 0)
	{
		if (Main.moonPhase == 0)
		{
			Main.NewText("Moon Phase is now Full.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 1)
		{
			Main.NewText("Moon Phase is now Last Gibbous.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 2)
		{
			Main.NewText("Moon Phase is now Last Quarter.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 3)
		{
			Main.NewText("Moon Phase is now Last Crescent.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 4)
		{
			Main.NewText("Moon Phase is now New.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 5)
		{
			Main.NewText("Moon Phase is now First Crescent.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 6)
		{
			Main.NewText("Moon Phase is now First Quarter.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
		else if (Main.moonPhase == 7)
		{
			Main.NewText("Moon Phase is now First Gibbous.", 50, 255, 130);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				Main.NewText("The Blood Moon has risen...", 50, 255, 130);
			}
		}
	}
	else if (Main.netMode == 2)
	{
		if (Main.moonPhase == 0)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now Full.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 1)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now Last Gibbous.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 2)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now Last Quarter.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 3)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now Last Crescent.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 4)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now New.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 5)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now First Crescent.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 6)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now First Quarter.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
		if (Main.moonPhase == 7)
		{
			NetMessage.SendData(25, -1, -1, "Moon Phase is now First Gibbous.", 255, 50f, 255f, 130f, 0);
			if (Main.rand.Next(14) == 0 && !Main.dayTime)
			{
				Main.bloodMoon = true;
				NetMessage.SendData(25, -1, -1, "The Blood Moon has risen...", 255, 50f, 255f, 130f, 0);
			}
		}
	}
}