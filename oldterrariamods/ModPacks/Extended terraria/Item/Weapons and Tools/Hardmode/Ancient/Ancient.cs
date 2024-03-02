public void UseItem(Player player, int playerID) {

	int spread = 10;

	float num48 = 14f;
	float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f))+Main.rand.Next(-spread, spread);
	float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f))+Main.rand.Next(-spread, spread);
	float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51;

	if ((player.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > (player.position.X + player.width * 0.5f)))
	{
		player.direction = 1;
	}
	if ((player.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < (player.position.X + player.width * 0.5f)))
	{
		player.direction = -1;
	}

	if (player.direction == 1) player.itemRotation = (float) Math.Atan2((Main.mouseY + Main.screenPosition.Y)-(player.position.Y + player.height * 0.5f),(Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
	else player.itemRotation = (float) Math.Atan2((player.position.Y + player.height * 0.5f)-(Main.mouseY + Main.screenPosition.Y),(player.position.X + player.width * 0.5f)-(Main.mouseX + Main.screenPosition.X));
	

	Projectile.NewProjectile(
	(float) player.position.X + (player.width * 0.5f),
	(float) player.position.Y + (player.height * 0.5f), 
	(float) speedX, 
	(float) speedY, 
	"Sandstorm", 
	(int) (item.damage*player.magicDamage), 
	player.inventory[player.selectedItem].knockBack, 
	playerID
	);
}


public void HoldStyle(Player P)
{
	//Item ancient = Config.itemDefs.byName["Ancient"];
	Item I = new Item();
	//I.SetDefaults(ancient.type);
	I = Config.itemDefs.byName["Ancient"];
	int original = (int)(14 * P.manaCost);
	// || (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Headpiece"].type) && ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Bodyarmor"].type) && ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Cuisses"].type)))
	if (P.head == Config.itemDefs.byName["Ancient Headpiece"].headSlot && P.body == Config.itemDefs.byName["Ancient Bodyplate"].bodySlot && P.legs == Config.itemDefs.byName["Ancient Leggings"].legSlot)
	{
		foreach (Item thing in P.inventory)
		{
			if (thing.type == I.type)
			{
				thing.mana = 0;
				break;
			}
		}
	}
	else 
	{
		foreach (Item thing2 in P.inventory)
		{
			if (thing2.type == I.type)
			{
				thing2.mana = original;
				break;
			}
		}
	}
}