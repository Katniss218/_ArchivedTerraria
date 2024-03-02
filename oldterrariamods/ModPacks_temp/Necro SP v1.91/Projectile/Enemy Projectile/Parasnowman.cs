public void Kill()
{
    int a = NPC.NewNPC((int)this.projectile.position.X,(int) this.projectile.position.Y-30, Config.npcDefs.byName["Winged Snowman"].type, 0);
    this.projectile.active=false;
}