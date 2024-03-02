public void Effects(Player player) {
	player.lavaImmune=true;
	player.meleeDamage += 0.07f;
	player.rangedDamage += 0.07f;
	player.magicDamage += 0.07f;
	player.meleeSpeed += 0.1f;
	player.accMerman = true;
	player.accFlipper = true;
	player.blockRange += 4;
	player.canRocket = true;
	player.rocketTime = 1200;
	player.rocketBoots = 1;
	player.rocketTimeMax = 1200;
	player.noKnockback = true;
	player.wings = 2;
	player.noFallDmg = true;
	player.jumpBoost = true;
	player.fireWalk = true;
	if (player.controlLeft)
	{
		if (player.velocity.X > -4) player.velocity.X -= 0.25f;
		if (player.velocity.X < -4 && player.velocity.X > -8)
		{
			player.velocity.X -= 0.25f;
		}
	}
	if (player.controlRight)
	{
		if (player.velocity.X < 4) player.velocity.X += 0.25f;
		if (player.velocity.X > 4 && player.velocity.X < 8)
		{
			player.velocity.X += 0.25f;
		}
	}
	if (player.velocity.X > 4 || player.velocity.X < -4)
	{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 16, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 2.0f);
		Main.dust[dust].noGravity = true;
		//Main.dust[dust].noLight = true;
	}
	/*bool isLavaMerman = Collision.LavaCollision(player.position, player.width, player.height);
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
	}*/
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Kinetic Boots"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Kinetic Boots D"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Kinetic Boots DS"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Kinetic Boots Gold"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Kinetic Boots"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Kinetic Boots D"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Kinetic Boots DS"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Kinetic Boots Gold"].type))
	{
		return false;
	}
	return true;
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