public void DamageNPC(NPC npc, ref int damage, ref float knockback) {
		if(Main.rand.Next(2)==0){
npc.AddBuff(24, 360, false);
} 
int myID = Main.myPlayer;
if(this.projectile.damage > 2){

   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y-7, this.projectile.velocity.X, this.projectile.velocity.Y+1, Config.projDefs.byName["Bouncing Soul"].type, this.projectile.damage/2, 0, myID)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y-7, -this.projectile.velocity.X, -this.projectile.velocity.Y, Config.projDefs.byName["Bouncing Soul"].type, this.projectile.damage/2, 0, myID)   ;                          
}
    
}
