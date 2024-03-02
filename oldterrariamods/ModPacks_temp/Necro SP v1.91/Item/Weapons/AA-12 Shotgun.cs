// This is my weapon's general .cs for firing weapons. For the most part, is copied from original .cs files. Edited for make the edited weapon a shotgun.
// Everything can be edited just in the .ini. The only thing you need to change here is the weapon's projectile and firing sound.

public static void UseItem(Player p, int playerID)
{
	int firingsound =36;
	int projectiletype = 14;
// Self explanatory. These are the only two values you can't edit in your .ini. Edit them here if you want.
	
	if (playerID == Main.myPlayer) 
// Controls if the character using the object is the player's character (without this, projectile's firing becomes bugged)
	{

	int num = p.inventory[p.selectedItem].damage;
//Defines a variable called "num". This will be our variable defining the projectile's damage. 'p.inventory[p.selectedItem].damage' is used for take the damage from currently equiped weapon.
	if (num > 0) // Controls if the player have a selected weapon.
	{
		if (p.inventory[p.selectedItem].melee)
		{
			num = (int)((float)num * p.meleeDamage);
		}
		// Controls if the player's weapon is melee. If the condition is satisfied, multiplies the weapon's damage with player's damage multiplier.
		else
		{
			if (p.inventory[p.selectedItem].ranged)
			{
				num = (int)((float)num * p.rangedDamage);
			}
			// Same as above but for ranged damages.
			else
			{
				if (p.inventory[p.selectedItem].magic)
				{
					num = (int)((float)num * p.magicDamage);
				}
				// Same as above but for magic damages.
			}
		}
	}
	Item item = new Item();
// Defines the variable Item for the item.class. With this, you can apply item class functions to this item.
	for (int num23 = 44; num23 < 48; num23++)
// Don't really sure about this. Probably, repeats the function for the ammo slot's ids.
	{
	if (p.inventory[num23].ammo == p.inventory[p.selectedItem].useAmmo && p.inventory[num23].stack > 0)
// Probably controlls if you have the right ammo in the ammo slots.
	{
		item = p.inventory[num23];
// Defines the item that can be edited with item.class functions
		break;
	}
	}
	if (item.ranged)
// Controls if the item used (ammo in this case) is a ranged weapon. (ammos have ranged weapon damage by default)
	{
		if (item.damage > 0)
// Controls if the item damage is higher than 0
		{
			num += (int)((float)item.damage * p.rangedDamage);
// Multiplies the ammo damage with character's ranged damage multiplier and adds it to the current projectile's damage.
		}
	}
	else
	{
		num += item.damage;
// If selected ammo is not influenced by ranged damage multiplier, just adds its damage to the projectile's damage.
	}
	if (p.inventory[p.selectedItem].useAmmo == 1 && p.archery)
// Controls if the ammo used by the weapon's are arrows (not really sure about this) and if player have Archery Buff.
	{
		num = (int)((double)((float)num) * 1.2);
// Multiplies the current damage with the Archery Buff damage multiplier.
	}


    for (int num36 = 0; num36 < 4; num36++)
    {
    float num48 = Main.rand.Next(12, 15);
//Defines a float variable for the projectile's speed. I randomized the value for make a better "shotgun spread" effect.

    float speedX = ((Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f))+Main.rand.Next(-40, 40);
    float speedY = ((Main.mouseY + Main.screenPosition.Y) - (p.position.Y + p.height * 0.5f))+Main.rand.Next(-40, 40);
//Defines two floats that defines the speed as a "boost" for the X and Y coordinates. It calculates the mouse position on the screen and subtracts the player's position for take the speeds needed for making a route from the player to the mouse position. The random values makes the spread.

    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51; 
// Don't really know what these does, makes some calculation. The speedX and speedY variables are generated giving a more fast speed if the mouse is more distant from the p. With this calculation, probably sets the speed to the value defined in the num48 variable.
	
if ((p.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > (p.position.X + p.width * 0.5f)))
	{
		p.direction = 1;
	}
	if ((p.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < (p.position.X + p.width * 0.5f)))
	{
		p.direction = -1;
	}
//This condition controls the mouse position. If the X cordinate is larger then player's, inverts the player's direction.

	if (p.direction == 1) p.itemRotation = (float) Math.Atan2((Main.mouseY + Main.screenPosition.Y)-(p.position.Y + p.height * 0.5f),(Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f));
	else p.itemRotation = (float) Math.Atan2((p.position.Y + p.height * 0.5f)-(Main.mouseY + Main.screenPosition.Y),(p.position.X + p.width * 0.5f)-(Main.mouseX + Main.screenPosition.X));
// This, instead, rotates the sprite of the weapon for make it aim at the mouse button. Atan2 is necessary for find the rotation value from point-to-point. If the player direction is -1, inverts the two points for doesn't make the sprite buggy.

	NetMessage.SendData(13, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);
	NetMessage.SendData(41, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);
// Not really sure what this does. Probably sends packages to other clients for preventing animation sprite's desync. In fact without this, other players will not see the weapon's aiming.

	Projectile.NewProjectile(p.position.X + (p.width * 0.5f),p.position.Y + (p.height * 0.5f), (float) speedX, (float) speedY, projectiletype, num, p.inventory[p.selectedItem].knockBack, playerID);
// Creates the projectile with given values. "14" is the projectile type.
	
	Main.PlaySound(2,(int) p.position.X,(int) p.position.Y, firingsound);
// Plays the fire sount at any projectile fired. 36 is the firing sound.
	}
	
	bool flag4 = false;
// Defines a bool value. If set to true, the weapon will not consume ammos.

	if (Main.rand.Next(2) == 0) flag4 = true;
// Adds 50% chance of not consume ammo. You can remove the entire line if you don't want the reduced ammo consumption. Remember that this weapon will consume ammo at every shooted barrage. So, you can consume a max of 3 ammos with a single click.
	
	if (!flag4)
	{
	item.stack--;
	if (item.stack <= 0)
	{
		item.active = false;
		item.name = "";
		item.type = 0;
	}
	}
// Controls if the bool "flag4" is set to false. If the condition is satisfied, ammos will be reduced by one. If ammo's ammount value is 0 or smaller, removes the ammo from the ammo slots.
	}
}
