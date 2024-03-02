int count = 200;
public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){

count+=1;

}




public void UseItem(Player player, int playerID) {

int x = (int)((Main.mouseX + Main.screenPosition.X));
int y = (int)((Main.mouseY + Main.screenPosition.Y));

if(count>25){
count=25;
}

if(Main.mouseRightRelease == false){

if(count > 0){
Main.NewText("Remaining ammo : "+count);

float speedX = (x-player.position.X)/15;

if(speedX > 12){
speedX = 12;
}
if(speedX < -12){
speedX = -12;
}


float speedY = (y-player.position.Y)/15;

if(speedY > 12){
speedY = 12;
}

if(speedY < -12){
speedY = -12;
}



Projectile.NewProjectile(player.position.X-5, player.position.Y+8, speedX, speedY, Config.projDefs.byName["StarSword"].type, 15, 4, Main.myPlayer)   ; 
Main.NewText(""+(speedY));
count--;
}
}
}

public void Effects(Player player) {
Main.NewText("count :"+count);
}