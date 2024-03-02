public void Kill(){

if(Main.rand.Next(2)==0){
NPC.NewNPC((int)this.projectile.position.X,(int) this.projectile.position.Y-30, Config.npcDefs.byName["Zombie Spitter"].type, 0);

}
this.projectile.active=false;
}