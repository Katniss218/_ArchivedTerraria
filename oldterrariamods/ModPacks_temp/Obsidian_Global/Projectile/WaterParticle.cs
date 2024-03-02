public void Kill(){


int x = (int)this.projectile.position.X/16;
int y = (int)this.projectile.position.Y/16;
 


   Main.PlaySound(19, x,y, 1);
										Main.tile[x, y].lava = false;
										Main.tile[x, y].liquid = 100;
										WorldGen.SquareTileFrame(x, y, true);


this.projectile.active = false;

}