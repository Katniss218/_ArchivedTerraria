static double tpCD = 0;
byte mode = 1;
bool runonce = false;
bool isNDown = false;
public static bool IsHotkeyPressed(string NameOfHotkey)
{
	Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.keyState.GetPressedKeys();
	for (int j = 0; j < pressedKeys.Length; j++)
	{
		string a = string.Concat(pressedKeys[j]);
		if (a == NameOfHotkey)
		{
			return true;
		}
	}
	return false;
}
public void Save(BinaryWriter W)
{
    W.Write(mode);
}
public void Load(BinaryReader R, int V)
{
    try
    {
        mode = R.ReadByte();
    }
    catch
    {
        mode = 1;
    }
}
public void HoldStyle(Player P)
{
	if (!runonce && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.N) && !isNDown)
	{
		mode++;
		runonce = true;
		isNDown = true;
	}
	if (!Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.N) && isNDown)
	{
		isNDown = false;
	}
	if (mode > 6)
	{
		mode = 1;
	}
	if (mode == 1 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Spawn point");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Spawn point", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
	else if (mode == 2 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Dungeon");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Dungeon", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
	else if (mode == 3 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Jungle (approx. pos)");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Jungle (approx. pos)", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
	else if (mode == 4 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Left ocean");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Left ocean", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
	else if (mode == 5 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Right ocean");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Right ocean", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
	else if (mode == 6 && runonce)
	{
		if (Main.netMode == 0) Main.NewText("Mirror Mode: Underworld");
		else if (Main.netMode == 1)
		{
			NetMessage.SendData(25, -1, -1, P.name + "'s Mirror Mode: Underworld", 255, 255f, 255f, 255f, 0);
		}
		runonce = false;
	}
}
public void Effects(Player player)
{
	if (tpCD > 300)
	{
		tpCD = 300;
	}
	tpCD += 1;
	if (IsHotkeyPressed("J"))
	{
		if (tpCD > 300)
		{
			tpCD = 0;
			for (int num89 = 0; num89 < 70; num89++)
			{
				Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.1f);
			}
			player.position.X = (Main.mouseX + Main.screenPosition.X);
			player.position.Y = (Main.mouseY + Main.screenPosition.Y);
			for (int num91 = 0; num91 < 70; num91++)
			{
				Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.1f);
			}
		}
	}
}
public void UseItem(Player P, int PID)
{
	item.alpha += 3;
	if (item.alpha >= 180) item.alpha = 0;
	if (Main.rand.Next(2) == 0)
	{
		Dust.NewDust(P.position, P.width, P.height, 15, 0f, 0f, 150, default(Color), 1.1f);
	}
	for (int num89 = 0; num89 < 70; num89++)
	{
		Dust.NewDust(P.position, P.width, P.height, 15, P.velocity.X * 0.5f, P.velocity.Y * 0.5f, 150, default(Color), 1.5f);
	}
	P.grappling[0] = -1;
	P.grapCount = 0;
	for (int num90 = 0; num90 < 1000; num90++)
	{
		if (Main.projectile[num90].active && Main.projectile[num90].owner == P.whoAmi && Main.projectile[num90].aiStyle == 7)
		{
			Main.projectile[num90].Kill();
		}
	}
	if (mode == 1)
	{
		P.Spawn();
	}
	else if (mode == 2)
	{
		// dungeon
		P.position.X = (float)(Main.dungeonX * 16);
		P.position.Y = (float)(Main.worldSurface / 2f) * 16f;
		if (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active)
		{
			while (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y += 16f;
			}
		}
		else
		{
			while (Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y -= 16f;
			}
		}
		if (Main.netMode == 1) NetMessage.SendTileSquare(PID, (int)Main.dungeonX, (int)(Main.worldSurface / 2f), 10);
	}
	else if (mode == 3)
	{
		// jungle
		if (ModWorld.jungleEx == 0) P.position.X = (float)((Main.maxTilesX - Main.dungeonX) * 16);
		else P.position.X = ModWorld.jungleEx * 16;
		P.position.Y = (float)(Main.worldSurface / 2f) * 16f;
		if (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active)
		{
			while (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y += 16f;
			}
		}
		else
		{
			while (Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y -= 16f;
			}
		}
		if (Main.netMode == 1) NetMessage.SendTileSquare(PID, (int)(P.position.X / 16f), (int)(P.position.Y / 16f), 10);
		//if (Main.netMode == 1) NetMessage.SendTileSquare(PID, (ModWorld.jungleEx == 0 ? (int)((Main.maxTilesX - Main.dungeonX)) : (int)ModWorld.jungleEx), (int)(Main.worldSurface / 2), 10);
	}
	else if (mode == 4)
	{
		// left ocean
		P.position.X = 200 * 16;
		P.position.Y = (float)(Main.worldSurface / 2f) * 16f;
		if (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active)
		{
			while (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y += 16f;
			}
		}
		else
		{
			while (Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y -= 16f;
			}
		}
		if (Main.netMode == 1) NetMessage.SendTileSquare(PID, 200, (int)Main.worldSurface / 2, 10);
	}
	else if (mode == 5)
	{
		// right ocean
		P.position.X = (Main.maxTilesX - 200) * 16;
		P.position.Y = (float)(Main.worldSurface / 2f) * 16f;
		if (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active)
		{
			while (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y += 16f;
			}
		}
		else
		{
			while (Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y -= 16f;
			}
		}
		if (Main.netMode == 1) NetMessage.SendTileSquare(PID, Main.maxTilesX - 200, (int)Main.worldSurface / 2, 10);
	}
	else if (mode == 6)
	{
		// hell
		P.position.X = (Main.maxTilesX / 2) * 16;
		P.position.Y = (float)(Main.maxTilesY - 180) * 16f;
		if (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active)
		{
			while (!Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y += 16f;
				if ((int)(P.position.Y / 16f) > Main.maxTilesY)
				{
					P.position.Y = (float)(Main.maxTilesY * 16) - 130f;
					break;
				}
			}
		}
		else
		{
			while (Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 4].active)
			{
				P.position.Y -= 16f;
			}
		}
		if (Main.netMode == 1) NetMessage.SendTileSquare(PID, Main.maxTilesX / 2, (int)Main.maxTilesY - 180, 10);
	}
	for (int num91 = 0; num91 < 70; num91++)
	{
		Dust.NewDust(P.position, P.width, P.height, 15, 0f, 0f, 150, default(Color), 1.5f);
	}
}