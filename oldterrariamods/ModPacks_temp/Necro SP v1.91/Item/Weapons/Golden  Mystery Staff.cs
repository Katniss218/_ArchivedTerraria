
public static int animationframe = 0;
public static bool goingup = true;

public static int lastime = -1;
public static void UseItem(Player player, int playerID) {

if (lastime == -1 || lastime < (int)Main.time-1) {
animationframe = 0;
} // If you have more patience than I do and wanna try and tweak the timing, this block could be rendered unnecessary.
lastime = (int)Main.time;

if (Main.mouseX + Main.screenPosition.X-player.position.X > 0) player.direction = 1;
else player.direction = -1;




player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y)*player.direction,((Main.mouseX + Main.screenPosition.X)-player.position.X)*player.direction);


float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y),((Main.mouseX + Main.screenPosition.X)-player.position.X));

player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y)*player.direction,((Main.mouseX + Main.screenPosition.X)-player.position.X)*player.direction);
player.itemLocation.X += (float)Math.Cos(targetrotation)*(animationframe-50);
player.itemLocation.Y += (float)Math.Sin(targetrotation)*(animationframe-50);

if (goingup) animationframe += 5;
else animationframe -= 5;

if (animationframe > 50) goingup = false;
if (animationframe < 1) goingup = true;

}

public void UseStyleHitBox(Player player, ref Rectangle rectangle) {

float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y),((Main.mouseX + Main.screenPosition.X)-player.position.X));

rectangle.X = (int)player.position.X+(player.width/2);
rectangle.Y = (int)player.position.Y+(player.height/2);
rectangle.X += (int)(Math.Cos(targetrotation)*(animationframe+50));
rectangle.Y += (int)(Math.Sin(targetrotation)*(animationframe+50));
rectangle.X -= 5;
rectangle.Y -= 5;
rectangle.Width = 10;
rectangle.Height = 10;
}


public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
{

    npc.AddBuff (31, 320);

}