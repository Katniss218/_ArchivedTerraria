public void Effects(Player player) {
	player.thorns = true;
	player.detectCreature = true;
	player.magicCrit += 10;
	player.meleeCrit += 10;
	player.rangedCrit += 10;
}

public void SetBonus(Player player) {
	player.setBonus = "Hades' Cross Effect";
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
		if (Main.netMode == 0)
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
	//player.statDefense += 3;
}