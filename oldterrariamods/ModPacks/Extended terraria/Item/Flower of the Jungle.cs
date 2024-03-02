public void UseItem(Player player, int playerID)
{
	float num48 = 8f;
	float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
	float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f));
	float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51;
	Projectile.NewProjectile(player.position.X + (player.width * 0.5f),player.position.Y + (player.height * 0.5f), (float)speedX, (float)speedY, "Jungle Fire", (int)(player.inventory[player.selectedItem].damage * player.magicDamage), 3, playerID);
}