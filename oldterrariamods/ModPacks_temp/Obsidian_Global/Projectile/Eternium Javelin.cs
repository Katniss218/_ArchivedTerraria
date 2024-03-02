public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{

}


public void Kill(){

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;


 
Item.NewItem(x,y-3,32,32,Config.itemDefs.byName["Eternium Spear"].type,1,false);

this.projectile.active = false;
}