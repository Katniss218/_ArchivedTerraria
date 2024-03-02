public void UseItem(Player player, int playerID)
{
	// Set the variables
	float x = (float)(Main.mouseX + Main.screenPosition.X);
	float y = (float)(Main.mouseY + Main.screenPosition.Y);
	float speedX = (Main.rand.Next(80) - 40) / 10f;
	float speedY = 14.9f;
	int type = 9; // type of the projectile (you can change this)
	int damage = (int)(item.damage * player.magicDamage /* magicDamage! */);
	float knockback = 3.0f;
	int owner = playerID;

	// Adjust the position of the projectile
	//x += Main.rand.Next(200) - 100f;
	y += -500f;
	
	// Actually spawn the projectile	
	int projID = Projectile.NewProjectile(x, y, speedX, speedY, type, damage, knockback, owner);
	int projID2 = Projectile.NewProjectile(x + 40, y, speedX, speedY, type, damage, knockback, owner);
	int projID3 = Projectile.NewProjectile(x + 80, y, speedX, speedY, type, damage, knockback, owner);
	int projID4 = Projectile.NewProjectile(x - 40, y, speedX, speedY, type, damage, knockback, owner);
	int projID5 = Projectile.NewProjectile(x - 80, y, speedX, speedY, type, damage, knockback, owner);
}
