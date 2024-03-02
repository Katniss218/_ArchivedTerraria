public bool CanUse(Player P, int PID)
{
	foreach (Item I in P.inventory)
	{
		if (I.type == 8 || I.type == 427 || I.type == 428 || I.type == 429 || I.type == 430 || I.type == 431 || I.type == 432 || I.type == 433 || I.type == 523)
		{
			if (I.stack != 0)
			{
				return true;
			}
		}
	}
	return false;
}

public void UseItem(Player P, int PID)
{
	if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Torch Launcher"].type)
	{
	for (int thing = 0; thing < 40; thing++)
	{
		if (P.inventory[thing].type == 8)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 427)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Blue Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 428)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Red Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 429)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Green Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 430)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Purple Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 431)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "White Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 432)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Yellow Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 433)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Demon Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
		else if (P.inventory[thing].type == 523)
		{
			float num48 = 8f;
			float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
			float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
			float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			num51 = num48 / num51;
			speedX *= num51;
			speedY *= num51;
			Projectile.NewProjectile(P.position.X + (P.width * 0.5f),P.position.Y + (P.height * 0.5f), (float)speedX, (float)speedY, "Cursed Torch", 0, 0, PID);
			P.inventory[thing].stack--;
			if (P.inventory[thing].stack <= 0) P.inventory[thing].SetDefaults(0);
			break;
		}
	}
	}
}