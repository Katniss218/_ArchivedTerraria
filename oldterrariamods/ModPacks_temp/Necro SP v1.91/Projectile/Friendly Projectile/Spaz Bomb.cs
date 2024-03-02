public void DamageNPC(NPC npc, ref int damage, ref float knockback) {
		npc.AddBuff(24, 360, false); 
int myID = Main.myPlayer;
if(this.projectile.damage > 2){

   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, this.projectile.velocity.X, this.projectile.velocity.Y+1, Config.projDefs.byName["Retin Bomb"].type, this.projectile.damage/2, 0, myID)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -this.projectile.velocity.X, -this.projectile.velocity.Y, Config.projDefs.byName["Retin Bomb"].type, this.projectile.damage/2, 0, myID)   ;                          
}
}
public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light * 0.35f, projectile.light * 1f, projectile.light * 0f);
	}
	int num10 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num10].noGravity = true;
		Main.dust[num10].scale *= 2f;
	}
	projectile.AI(true);
}
