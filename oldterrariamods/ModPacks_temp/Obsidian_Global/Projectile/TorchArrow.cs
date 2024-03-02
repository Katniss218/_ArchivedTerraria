bool set = false;
float f = 0f;

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


}

public void DamageNPC(NPC npc, ref int damage, ref float knockback) {
if(Main.rand.Next(2)==0){
npc.AddBuff(24, 60, false);
}
this.projectile.active = false;
}
