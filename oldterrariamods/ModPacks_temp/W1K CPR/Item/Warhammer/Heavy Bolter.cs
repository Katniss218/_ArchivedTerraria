public void UseItem(Player p, int playerID)
{
	int firingsound = 36;
	int spread = 20;
	
	if (playerID == Main.myPlayer)
	{

	int num = p.inventory[p.selectedItem].damage;
	if (num > 0) // Controls if the player have a selected weapon.
	{
		if (p.inventory[p.selectedItem].melee)
		{
			num = (int)((float)num * p.meleeDamage);
		}
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
	for (int num23 = 44; num23 < 48; num23++)
	{
	if (p.inventory[num23].ammo == p.inventory[p.selectedItem].useAmmo && p.inventory[num23].stack > 0)
	{
		item = p.inventory[num23];
		break;
	}
	}
	if (item.ranged)
	{
		if (item.damage > 0)
		{
			num += (int)((float)item.damage * p.rangedDamage);
		}
	}
	else
	{
		num += item.damage;
	}
	if (p.inventory[p.selectedItem].useAmmo == 1 && p.archery)
	{
		num = (int)((double)((float)num) * 1.2);
	}


    float num48 = 14f;

    float speedX = ((Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f))+Main.rand.Next(-spread, spread);
    float speedY = ((Main.mouseY + Main.screenPosition.Y) - (p.position.Y + p.height * 0.5f))+Main.rand.Next(-spread, spread);

    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51; 
	
	if ((p.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > (p.position.X + p.width * 0.5f)))
	{
		p.direction = 1;
	}
	if ((p.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < (p.position.X + p.width * 0.5f)))
	{
		p.direction = -1;
	}

	if (p.direction == 1) p.itemRotation = (float) Math.Atan2((Main.mouseY + Main.screenPosition.Y)-(p.position.Y + p.height * 0.5f),(Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f));
	else p.itemRotation = (float) Math.Atan2((p.position.Y + p.height * 0.5f)-(Main.mouseY + Main.screenPosition.Y),(p.position.X + p.width * 0.5f)-(Main.mouseX + Main.screenPosition.X));

	NetMessage.SendData(13, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);
	NetMessage.SendData(41, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);

	Projectile.NewProjectile(p.position.X + (p.width * 0.5f),p.position.Y + (p.height * 0.5f), (float) speedX, (float) speedY, item.shoot, num, p.inventory[p.selectedItem].knockBack, playerID);
	
	Main.PlaySound(2,(int) p.position.X,(int) p.position.Y, firingsound);
	
	bool flag4 = false;

	if (Main.rand.Next(2) == 0) flag4 = true;
	
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
	}
}