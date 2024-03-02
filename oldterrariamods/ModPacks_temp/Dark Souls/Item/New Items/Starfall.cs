public void UseItem(Player player, int playerID) {

	// Set the variables
	int selectedType = Config.itemDefs.byName["Starfall"].type;
	float x = (float)(Main.mouseX + Main.screenPosition.X);
	float y = (float)(Main.mouseY + Main.screenPosition.Y) - (float)Main.rand.Next(500, 800);
	float speedX = 0; //(Main.rand.Next(80) - 40) / 10f;
	float speedY = 14.9f;
	int type = 12;
	int damage = (int)(item.damage * player.magicDamage);
	float knockback = 2.0f;
	int owner = playerID;

	
	// Adjust the position of the projectile
	//x += Main.rand.Next(200) - 100f;
	//y += -500f;
	
	//if (player.statMana == player.statManaMax2 && (player.statManaMax >= 200 || player.statManaMax2 >= 200))
	//{
	if (Main.netMode == 0)
	{
		//Main.NewText("The power of the stars consumes your mana...", 255, 255, 0);
	}
	else if (Main.netMode == 2)
	{
		//NetMessage.SendData(25, -1, -1, ("The power of the stars consumes " + player.name + "'s mana..."), 255, 255f, 255f, 0f, 0);
	}
	// Actually spawn the projectile	
	int projID = Projectile.NewProjectile(x, y, speedX, speedY, type, damage, knockback, owner);
	//player.statMana = 0;
	//}
	//else if (player.statMana == player.statManaMax2 && player.statManaMax2 < 200)
	//{
	//	if (player.inventory[player.selectedItem].type == selectedType)
	//	{
	//		player.noItems = true;
	//	}
	//}
}