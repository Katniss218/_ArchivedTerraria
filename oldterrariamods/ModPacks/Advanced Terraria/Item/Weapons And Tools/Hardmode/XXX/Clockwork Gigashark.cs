
//Globals
private bool secondBarrel = false;

//Methods

public void UseStyle(Player p) {
	if(p.whoAmi == Main.myPlayer) {
		//Change direction to match mouse
		if ((Main.mouseX + Main.screenPosition.X) > (p.position.X + p.width * 0.5f)) {
			p.direction = 1;
		} else {
			p.direction = -1;
		}
		//Point at the cursor
		float speedX = (float)((Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f));
		float speedY = (float)((Main.mouseY + Main.screenPosition.Y) - (p.position.Y + p.height * 0.5f));
		p.itemRotation = (float) Math.Atan2((double)(speedY * (float)p.direction), (double)(speedX * (float)p.direction));
		//Update Controls and Position Data
		NetMessage.SendData(13, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);
		//Update Item Rotation
		NetMessage.SendData(41, -1, -1, "", p.whoAmi, 0f, 0f, 0f, 0);
	}
}

public void UseItem(Player p, int playerID) {
	int firingsound = 36;
	int spread = 12;
	
	if (playerID == Main.myPlayer) {
		int dmg = p.inventory[p.selectedItem].damage;
		dmg = (int)((float)dmg * p.rangedDamage);
		//Find ammunition
		Item ammo = new Item();
		for (int l=44;l<48;l++) {
			if (p.inventory[l].ammo == p.inventory[p.selectedItem].useAmmo && p.inventory[l].stack > 0) {
				ammo = p.inventory[l];
				break;
			}
		}
		//Apply rangedDamage bonus if applies
		if (ammo.ranged) {
			if (ammo.damage > 0) {
				dmg += (int)((float)ammo.damage * p.rangedDamage);
			}
		} else {
			dmg += ammo.damage;
		}
		//Find Projectile Speed
		float scale = 14f;
		float mouseX = ((Main.mouseX + Main.screenPosition.X) - (p.position.X + p.width * 0.5f));
		float mouseY = ((Main.mouseY + Main.screenPosition.Y) - (p.position.Y + p.height * 0.5f));
		float speedX = mouseX+Main.rand.Next(-spread, spread);
		float speedY = mouseY+Main.rand.Next(-spread, spread);
		float speedProjectile = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
		speedProjectile = scale / speedProjectile;
		speedX *= speedProjectile;
		speedY *= speedProjectile; 
		//Barrel Offset
		Vector2 offset = new Vector2(mouseX,mouseY);
		offset.Normalize();
		offset *= 20;
		Vector2 normal = new Vector2(-speedY,speedX);
		normal.Normalize();
		normal *= 12;
		//Fire Gun (Finally)
		if(secondBarrel) {
			Projectile.NewProjectile(p.position.X + (p.width * 0.5f) - normal.X + offset.X,
			                         p.position.Y + (p.height * 0.5f) - normal.Y + offset.Y,
									 (float) speedX, (float) speedY, ammo.shoot, dmg,
									 p.inventory[p.selectedItem].knockBack, playerID);
		} else {
			Projectile.NewProjectile(p.position.X + (p.width * 0.5f) + normal.X + offset.X,
			                         p.position.Y + (p.height * 0.5f) + normal.Y + offset.Y,
									 (float) speedX, (float) speedY, ammo.shoot, dmg,
									 p.inventory[p.selectedItem].knockBack, playerID);
		}
		secondBarrel = !secondBarrel;
		Main.PlaySound(2,(int) p.position.X/16,(int) p.position.Y/16, firingsound);
		//Chance to not use ammo
		bool noAmmo = false;
		if (p.ammoCost80 && Main.rand.Next(5) == 0) {
			noAmmo = true;
		}
		if (p.ammoCost75 && Main.rand.Next(4) == 0) {
			noAmmo = true;
		}
		if (Main.rand.Next(2) == 0) {
			noAmmo = true;
		}
		if (!noAmmo) {
			ammo.stack--;
			if (ammo.stack <= 0) {
				ammo.active = false;
				ammo.name = "";
				ammo.type = 0;
			}
		}
	}
}