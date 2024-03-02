static int slowdown = 0;
public static void UseItem(Player player, int playerID) {

if (player.controlUseItem && player.itemAnimation > player.itemAnimationMax-5) {

slowdown++;

if (slowdown >= 8) {
player.velocity.X = 0;
player.velocity.Y = 1;
}

player.inventory[player.selectedItem].noMelee = true;
player.itemAnimation = player.itemAnimationMax;
if (Main.time % 3 <1) {
int num54 = Projectile.NewProjectile(player.itemLocation.X+player.width/2+(player.direction*(50+Main.rand.Next(64))),player.itemLocation.Y-Main.rand.Next(128),Main.rand.Next(-5,5),0,"Enchanted Sickles",1,2.5f,playerID);
int damage = 80;
Main.projectile[num54].timeLeft = 30;
Main.projectile[num54].ai[0] = Main.rand.Next(0, 1);
}
}
else {
player.inventory[player.selectedItem].noMelee = false;
slowdown = 0;
}
}