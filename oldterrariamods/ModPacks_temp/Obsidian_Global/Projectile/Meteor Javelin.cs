public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(10) == 0)
	{
		npc.AddBuff(24, 360, false);

	}
}

public void Kill(){

int x = (int)this.projectile.position.X;
int y = (int) this.projectile.position.Y;


    if(Main.rand.Next(4)==0){
Item.NewItem(x,y-3,32,32,Config.itemDefs.byName["Meteor Javelin"].type,1,false);
}
this.projectile.active = false;
}