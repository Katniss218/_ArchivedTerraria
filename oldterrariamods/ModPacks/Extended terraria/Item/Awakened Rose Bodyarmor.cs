static double tpCD = 0;
public void Effects(Player player)
{
	int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
	int j2 = (int)(player.position.Y + 2f) / 16;
	Lighting.addLight(i2,j2,2,2,2);
	player.starCloak = true;
	player.longInvince = true;
	player.findTreasure = true;
	player.detectCreature = true;
	player.statManaMax2 += 160;
}

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

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 30;
}

public void SetBonus(Player player)
{
	player.setBonus = "Enables teleportation to the cursor, press J";
	player.ShadowTail = true;
	player.ShadowAura = true;
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