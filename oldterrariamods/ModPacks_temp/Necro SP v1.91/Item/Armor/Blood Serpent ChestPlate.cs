public static void SetBonus(Player player) {
	player.setBonus = "+10% Melee Damage";
    player.meleeDamage += 0.10f;
}

public void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/10;
	//player.HealEffect((int)damage/10);
}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)(damage*2)/10;
	//myPlayer.HealEffect((int)damage/10);
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 5, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}