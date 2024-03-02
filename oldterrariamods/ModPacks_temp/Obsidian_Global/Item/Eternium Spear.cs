public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner){

int x = (int)((Main.mouseX + Main.screenPosition.X));
int y = (int)((Main.mouseY + Main.screenPosition.Y));
Player player = P;

if((player.inventory[player.selectedItem].stack > 1) && Main.mouseRightRelease == false){
//player.inventory[player.selectedItem].noUseGraphic=true;
//player.inventory[player.selectedItem].useStyle = 0;
player.inventory[player.selectedItem].stack --;

float speedX = (x-player.position.X)/15;

if(speedX > 10){
speedX = 10;
}
if(speedX < -10){
speedX = -10;
}


float speedY = (y-player.position.Y)/15;

if(speedY > 10){
speedY = 10;
}

if(speedY < -10){
speedY = -10;
}



Projectile.NewProjectile(player.position.X-5, player.position.Y+8, speedX, speedY, Config.projDefs.byName["Eternium Javelin"].type, 35, 3, Main.myPlayer)   ; 
return false;
}
return true;
//player.inventory[player.selectedItem].noUseGraphic=false;

}
