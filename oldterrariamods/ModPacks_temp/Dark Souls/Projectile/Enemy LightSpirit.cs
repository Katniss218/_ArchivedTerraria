public void DamageNPC(NPC npc, ref int damage, ref float knockback) {
if(this.projectile.damage > 6){
Projectile.NewProjectile(this.projectile.position.X-20, this.projectile.position.Y - 1000, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X-20, this.projectile.position.Y - 1000, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X+20, this.projectile.position.Y - 1000, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X-40, this.projectile.position.Y - 1200, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X+40, this.projectile.position.Y - 1200, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X-60, this.projectile.position.Y - 1400, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);
Projectile.NewProjectile(this.projectile.position.X+60, this.projectile.position.Y - 1400, 0, 12,  Config.projDefs.byName["Enemy LightSpirit"].type, this.projectile.damage/3, 0, 0);

}
}