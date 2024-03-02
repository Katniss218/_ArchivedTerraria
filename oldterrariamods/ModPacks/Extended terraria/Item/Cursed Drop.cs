public void UseItem(Player P, int PID)
{
	int x = (int)(Main.mouseX + Main.screenPosition.X);
	int y = (int)(Main.mouseY + Main.screenPosition.Y);
	int a = Projectile.NewProjectile(x, y, 0f, 0f, "Curse", (int)(P.inventory[P.selectedItem].damage * P.magicDamage), 0f, PID);
}