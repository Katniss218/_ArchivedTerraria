public static void UseTile(Player player, int x, int y) {
	Config.OpenCustomDoor(Player.tileTargetX, Player.tileTargetY, player.direction, "Open Stone Door");
}
public static bool OpenCustomDoor(int i, int j, int direction, int openDoorType)
{
	int num3;
	int num = 0;
	if (Main.tile[i, j - 1] == null)
	{
		Main.tile[i, j - 1] = new Tile();
	}
	if (Main.tile[i, j - 2] == null)
	{
		Main.tile[i, j - 2] = new Tile();
	}
	if (Main.tile[i, j + 1] == null)
	{
		Main.tile[i, j + 1] = new Tile();
	}
	if (Main.tile[i, j] == null)
	{
		Main.tile[i, j] = new Tile();
	}
	if ((Main.tile[i, j - 1].frameY == 0) && (Main.tile[i, j - 1].type == Main.tile[i, j].type))
	{
		num = j - 1;
	}
	else if ((Main.tile[i, j - 2].frameY == 0) && (Main.tile[i, j - 2].type == Main.tile[i, j].type))
	{
		num = j - 2;
	}
	else if ((Main.tile[i, j + 1].frameY == 0) && (Main.tile[i, j + 1].type == Main.tile[i, j].type))
	{
		num = j + 1;
	}
	else
	{
		num = j;
	}
	int num2 = i;
	short num4 = 0;
	if (direction == -1)
	{
		num2 = i - 1;
		num4 = 0x24;
		num3 = i - 1;
	}
	else
	{
		num2 = i;
		num3 = i + 1;
	}
	bool flag = true;
	for (int k = num; k < (num + 3); k++)
	{
		if (Main.tile[num3, k] == null)
		{
			Main.tile[num3, k] = new Tile();
		}
		if (Main.tile[num3, k].active)
		{
			if ((((Main.tile[num3, k].type == 3) || (Main.tile[num3, k].type == 0x18)) || ((Main.tile[num3, k].type == 0x34) || (Main.tile[num3, k].type == 0x3d))) || (((Main.tile[num3, k].type == 0x3e) || (Main.tile[num3, k].type == 0x45)) || (((Main.tile[num3, k].type == 0x47) || (Main.tile[num3, k].type == 0x49)) || (Main.tile[num3, k].type == 0x4a))))
			{
				WorldGen.KillTile(num3, k, false, false, false);
			}
			else
			{
				flag = false;
				break;
			}
		}
	}
	if (flag)
	{
		Main.PlaySound(8, i * 0x10, j * 0x10, 1);
		Main.tile[num2, num].active = true;
		Main.tile[num2, num].type = (byte)openDoorType;
		Main.tile[num2, num].frameY = 0;
		Main.tile[num2, num].frameX = num4;
		if (Main.tile[num2 + 1, num] == null)
		{
			Main.tile[num2 + 1, num] = new Tile();
		}
		Main.tile[num2 + 1, num].active = true;
		Main.tile[num2 + 1, num].type = (byte)openDoorType;
		Main.tile[num2 + 1, num].frameY = 0;
		Main.tile[num2 + 1, num].frameX = (short)(num4 + 0x12);
		if (Main.tile[num2, num + 1] == null)
		{
			Main.tile[num2, num + 1] = new Tile();
		}
		Main.tile[num2, num + 1].active = true;
		Main.tile[num2, num + 1].type = (byte)openDoorType;
		Main.tile[num2, num + 1].frameY = 0x12;
		Main.tile[num2, num + 1].frameX = num4;
		if (Main.tile[num2 + 1, num + 1] == null)
		{
			Main.tile[num2 + 1, num + 1] = new Tile();
		}
		Main.tile[num2 + 1, num + 1].active = true;
		Main.tile[num2 + 1, num + 1].type = (byte)openDoorType;
		Main.tile[num2 + 1, num + 1].frameY = 0x12;
		Main.tile[num2 + 1, num + 1].frameX = (short)(num4 + 0x12);
		if (Main.tile[num2, num + 2] == null)
		{
			Main.tile[num2, num + 2] = new Tile();
		}
		Main.tile[num2, num + 2].active = true;
		Main.tile[num2, num + 2].type = (byte)openDoorType;
		Main.tile[num2, num + 2].frameY = 0x24;
		Main.tile[num2, num + 2].frameX = num4;
		if (Main.tile[num2 + 1, num + 2] == null)
		{
			Main.tile[num2 + 1, num + 2] = new Tile();
		}
		Main.tile[num2 + 1, num + 2].active = true;
		Main.tile[num2 + 1, num + 2].type = (byte)openDoorType;
		Main.tile[num2 + 1, num + 2].frameY = 0x24;
		Main.tile[num2 + 1, num + 2].frameX = (short)(num4 + 0x12);
		for (int m = num2 - 1; m <= (num2 + 2); m++)
		{
			for (int n = num - 1; n <= (num + 2); n++)
			{
				WorldGen.TileFrame(m, n, false, false);
			}
		}
	}
	return flag;
}
 public static bool CloseCustomDoor(int i, int j, int closedDoorType, bool forced = false)
{
	int num = 0;
	int num2 = i;
	int num3 = j;
	if (Main.tile[i, j] == null)
	{
		Main.tile[i, j] = new Tile();
	}
	int frameX = Main.tile[i, j].frameX;
	int frameY = Main.tile[i, j].frameY;
	switch (frameX)
	{
		case 0:
			num2 = i;
			num = 1;
			break;

		case 0x12:
			num2 = i - 1;
			num = 1;
			break;

		case 0x24:
			num2 = i + 1;
			num = -1;
			break;

		case 0x36:
			num2 = i;
			num = -1;
			break;
	}
	switch (frameY)
	{
		case 0:
			num3 = j;
			break;

		case 0x12:
			num3 = j - 1;
			break;

		case 0x24:
			num3 = j - 2;
			break;
	}
	int num6 = num2;
	if (num == -1)
	{
		num6 = num2 - 1;
	}
	if (!forced)
	{
		for (int n = num3; n < (num3 + 3); n++)
		{
			if (!Collision.EmptyTile(num2, n, true))
			{
				return false;
			}
		}
	}
	for (int k = num6; k < (num6 + 2); k++)
	{
		for (int num9 = num3; num9 < (num3 + 3); num9++)
		{
			if (k == num2)
			{
				if (Main.tile[k, num9] == null)
				{
					Main.tile[k, num9] = new Tile();
				}
				Main.tile[k, num9].type = (byte)closedDoorType;
				Main.tile[k, num9].frameX = (short)(WorldGen.genRand.Next(3) * 0x12);
			}
			else
			{
				if (Main.tile[k, num9] == null)
				{
					Main.tile[k, num9] = new Tile();
				}
				Main.tile[k, num9].active = false;
			}
		}
	}
	for (int m = num2 - 1; m <= (num2 + 1); m++)
	{
		for (int num11 = num3 - 1; num11 <= (num3 + 2); num11++)
		{
			WorldGen.TileFrame(m, num11, false, false);
		}
	}
	Main.PlaySound(9, i * 0x10, j * 0x10, 1);
	return true;
}