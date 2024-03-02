
public void Kill(){

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;


Main.player[Main.myPlayer].position.X = x;
Main.player[Main.myPlayer].position.Y = y-15;

this.projectile.active = false;


}
