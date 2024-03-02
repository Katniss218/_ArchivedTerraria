
//Globals
private int count = 0;

//Methods

public void UseItemEffect(Player p, Rectangle r) {
	count++;
	if(count >= 6) {
		Main.PlaySound(2,(int)p.position.X,(int)p.position.Y,22);
		count = 0;
	}
}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback) {
	if(Main.rand.Next(3) == 0) {
		npc.AddBuff("Severe Wounds",900,false);
	}
}

public void DamagePVP(Player myPlayer, ref int damage, Player enemyPlayer) {
	if(Main.rand.Next(3) == 0) {
		enemyPlayer.AddBuff("Severe Wounds",900,false);
	}
}
