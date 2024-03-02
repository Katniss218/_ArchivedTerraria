public static void SetBonus(Player player) {
	    player.setBonus = "Mereman/Werewolf Effect, +20% Mana Crit, and Mana Regen Buff";
		player.accMerman=true;
	    player.wolfAcc=true;
	    player.starCloak=true;
        player.magicCrit +=20;
        player.manaRegenBuff=true;
        
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 59, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 3.0f);
	Main.dust[dust].noGravity = true;
	}
}