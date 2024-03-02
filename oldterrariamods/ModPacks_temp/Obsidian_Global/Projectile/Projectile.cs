public void DamageNPC(NPC npc, ref int damage, ref float knockback) {

for (int m = 0; m < 1000; m++)
	{
		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer)
		{
			ModPlayer.target = npc;

		}
	}
}



