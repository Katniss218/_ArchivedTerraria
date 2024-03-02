
bool set = false;
bool stay = false;
float f = 0;

public void Kill(){

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;


if(Main.rand.Next(4)==0 && stay==false){
Item.NewItem(x,y-3,32,32,Config.itemDefs.byName["Fossil Javelin"].type,1,false);

this.projectile.active = false;
}else{
stay = true;
    if(!set){
     f = (float)projectile.rotation;
    set = true;
    }

    this.projectile.rotation = (float) f;
    projectile.velocity.X = 0;
    projectile.velocity.Y = 0;
    projectile.position.X = x;
    projectile.position.Y = y;

}

}

public void DealtNPC(NPC npc, double damage, Player player) 
{
this.projectile.active = false;
}