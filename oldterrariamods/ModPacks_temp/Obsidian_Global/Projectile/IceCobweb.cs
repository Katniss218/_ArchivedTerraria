bool set = false;
float f = 0f;
int timer = 640;

public void Kill(){
if(!set){
 f = (float)projectile.rotation;
set = true;
}

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;

this.projectile.rotation = (float) f;
projectile.velocity.X = 0;
projectile.velocity.Y = 0;
projectile.position.X = x;
projectile.position.Y = y;

timer--;
if(timer<0){
this.projectile.active = false;
}
}


public void DealtPVP(double damage, Player enemyPlayer) {

enemyPlayer.AddBuff(32, 60, false);

this.projectile.active = false;
}

