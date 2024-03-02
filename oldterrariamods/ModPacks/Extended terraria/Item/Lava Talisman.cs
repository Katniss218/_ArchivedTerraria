/*public void AffixName(ref string name)
{
	name = "Hades' Cross";
}*/

public void Effects(Player player)
{
	bool isLavaMerman = Collision.LavaCollision(player.position, player.width, player.height);
	if (isLavaMerman)
	{
		ModPlayer.LavaMerman = true;
		player.lavaImmune = true;
		//player.breath = 255;
		//player.breathMax = 255;
		if (player.breath < player.breathMax - 1)
		{
			player.breath = player.breathMax - 1;
		}
		//player.swimTime = 90;
		player.accFlipper = true;
		if (Main.netMode != 2)
		{
			player.merman = true;
			Main.armorArmTexture[22] = Main.goreTexture[Config.goreID["LavaMermanArm"]];
			Main.armorBodyTexture[22] = Main.goreTexture[Config.goreID["LavaMermanBody"]];
			Main.armorHeadTexture[39] = Main.goreTexture[Config.goreID["LavaMermanHead"]];
			Main.armorLegTexture[21] = Main.goreTexture[Config.goreID["LavaMermanLegs"]];
		}
		if (player.whoAmi != Main.myPlayer)
		{
			return;
		}
	}
	player.statDefense += 3;
	player.lavaImmune = true;
	player.fireWalk = true;
}
public void ModifyPlayerDrawColors(Player P, bool overrideOnFire, float A, float R, float G, float B)
{
	if (ModPlayer.LavaMerman)
	{
		overrideOnFire = true;
		A = 0f;
		R = 255f;
		G = 50f;
		B = 50f;
	}
}