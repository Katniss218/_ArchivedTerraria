

public void Kill(){

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;


    if(Main.rand.Next(4)==0){
Item.NewItem(x,y-3,32,32,Config.itemDefs.byName["Gold Javelin"].type,1,false);
}
this.projectile.active = false;
}