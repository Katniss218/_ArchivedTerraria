/*public void UseItem(Player player, int playerID)
{
	
	float num48 = .6f;
	float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
	float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f));
	float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51;
	Projectile.NewProjectile(player.position.X + (player.width * 0.5f),player.position.Y + (player.height * 0.5f), (float)speedX, (float)speedY, "Impulse Bolt", (int)(player.inventory[player.selectedItem].damage * player.magicDamage), 5, playerID);
}*/


/*public void HoldStyle(Player P)
{
	//Item ancient = Config.itemDefs.byName["Ancient"];
	Item I = new Item();
	//I.SetDefaults(ancient.type);
	I = Config.itemDefs.byName["Impulse Strike"];
	int original = (int)(14 * P.manaCost);
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Headpiece"].type) && ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Bodyarmor"].type) && ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Cuisses"].type)))
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
}*/