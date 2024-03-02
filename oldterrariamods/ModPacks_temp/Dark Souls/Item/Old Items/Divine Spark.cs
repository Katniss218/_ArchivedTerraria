

public static void UseItem(Player player, int playerID) {
float n=0;
float m=0;


if (Main.mouseX + Main.screenPosition.X-player.position.X > 0) player.direction = 1;
else player.direction = -1;



float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y),((Main.mouseX + Main.screenPosition.X)-player.position.X));

player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y)*player.direction,((Main.mouseX + Main.screenPosition.X)-player.position.X)*player.direction);

int damage = 60;//(int) (14f * npc.scale);
for (int i = 1; i < 20; i++) {
n=(float)Math.Sin(targetrotation)*((float)i+0.1f)*56;
m=(float)Math.Cos(targetrotation)*((float)i+0.1f)*56;
int num54 = Projectile.NewProjectile(m+player.position.X+7,n+player.position.Y+21,0,0,"Master Buster",60,0f,playerID);
Main.projectile[num54].timeLeft = 2;
Main.projectile[num54].rotation = (float)Math.Atan2((double)n, (double)m);
}



player.velocity.X -= m/2000f;
player.velocity.Y -= n/2000f;

if (player.velocity.X > 32) player.velocity.X = 32;
if (player.velocity.X < -32) player.velocity.X = -32;
if (player.velocity.Y > 32) player.velocity.Y = 32;
if (player.velocity.Y < -32) player.velocity.Y = -32;



if (Main.time % 5 < 2) player.inventory[player.selectedItem].mana = 2;
else player.inventory[player.selectedItem].mana = 0;

Main.PlaySound(2,-1,-1,SoundHandler.soundID["Tardis"]);
}