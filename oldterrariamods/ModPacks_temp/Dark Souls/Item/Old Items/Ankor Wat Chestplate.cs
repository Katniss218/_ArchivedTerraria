//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.magicCrit += 30;
	
}




public static void SetBonus(Player player) {
	player.setBonus = "+160 max mana + Rapid Mana Regen";

    	player.manaRegenBuff = true;
	player.statManaMax2 += 160;
	player.manaRegen += 8;
	player.ShadowTail = true;
	
    
	
}




public void PlayerFrame(Player player){
	if (player.armor[0].name=="Ankor Wat Helmet")
        {
			if (player.armor[2].name=="Ankor Wat Leggings")
			{


 int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 60, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Red, 1.0f);
 Main.dust[dust].noGravity = true;
}}}
