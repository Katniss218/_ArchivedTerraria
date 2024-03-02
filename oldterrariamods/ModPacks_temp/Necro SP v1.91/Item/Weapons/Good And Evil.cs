



public bool CanUse(Player player, int playerID) {

	int use=0;
	//This code is used by boomerangs to limit the amount of boomerang projectiles that can be thrown.
	for (int m = 0; m < 1000; m++)
	{
		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.item.shoot)
		{
			use++;
		}
	}
	if (use < player.inventory[player.selectedItem].stack) return true;

	return false;

}

