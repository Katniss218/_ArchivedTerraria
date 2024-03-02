public bool CanUse(Player player, int pID) {
	int use=this.item.stack;
	bool canuse=true;
	for (int m = 0; m < 1000; m++)
	{
		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.item.shoot)
			use-=1;
	}
	if(use<=0)
	canuse=false;
	return canuse;
}
