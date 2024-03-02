static double tpCD = 0;
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
public void ModifyPlayerDrawColors(Player P, bool OverrideFire, ref float r, ref float g, ref float b, ref float a)
{
	OverrideFire = true;
	r *= 0.937f;
	g *= 0.8588f;
	b *= 0.0f;
}
public void Effects(Player player, int buffIndex, int buffType, int buffTime)
{
	player.gravControl = true;
	player.findTreasure = true;
	player.detectCreature = true;
	player.waterWalk = true;
	player.lavaImmune = true;
	player.nightVision = true;
	player.slowFall = true;
	if (tpCD > 300)
	{
		tpCD = 300;
	}
	tpCD += 1;
	if (IsHotkeyPressed("J"))
	{
		if (tpCD > 300)
		{
			if (ModPlayer.zoneHellcastle)
			{
				if (Main.netMode == 0)
				{
					Main.NewText("The power of Cataryst prevents you from teleporting...", 255, 194, 0);
				}
				else NetMessage.SendData(25, -1, -1, "The power of Cataryst prevents " + player.name + " from teleporting...", 255, 255f, 194f, 0f, 0);
			}
			else
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
}