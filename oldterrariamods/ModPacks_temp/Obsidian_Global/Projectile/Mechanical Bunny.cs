public void DamageNPC(NPC npc, ref int damage, ref float knockback) {

      	if (Main.rand.Next(20) == 0  && npc.boss == false) { 
          npc.Transform(46);
	    }	  

}

public void Kill(){

    NPC.NewNPC((int)this.projectile.position.X, (int)this.projectile.position.Y, Config.npcDefs.byName["Bunny"].type, 0);
    this.projectile.active = false;
    return;

}


