

public static void UseItem(Player player, int playerID) {



if (Main.mouseX + Main.screenPosition.X-player.position.X > 0) player.direction = 1;
else player.direction = -1;


float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y),((Main.mouseX + Main.screenPosition.X)-player.position.X));
player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y)*player.direction,((Main.mouseX + Main.screenPosition.X)-player.position.X)*player.direction);

int num54 = Projectile.NewProjectile(player.itemLocation.X+(float)Math.Cos(targetrotation)*60+25,player.itemLocation.Y+(float)Math.Sin(targetrotation)*60+18,0,0,"Mega Drill",500,1f,playerID);
Main.projectile[num54].timeLeft = 100;
Main.projectile[num54].scale = 5f;
Main.projectile[num54].position.X += Main.rand.Next(-16,16);
Main.projectile[num54].position.Y += Main.rand.Next(-16,16);
Main.projectile[num54].rotation = targetrotation;


}
