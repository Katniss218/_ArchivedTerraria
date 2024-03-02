//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.magicCrit += 15;
}



public static void SetBonus(Player player) {
	player.setBonus = "+15% magic damage, +80 mana, Space Gun Skill";
    player.magicDamage += 0.15f;
	player.statManaMax2 += 60;
	player.spaceGun = true;
}




public void PlayerFrame(Player player){
	if (player.armor[0].name=="RTQ2 Helmet")
        {
			if (player.armor[2].name=="RTQ2 Leggings")
			{


 int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 60, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Red, 1.0f);
 Main.dust[dust].noGravity = true;
}}}
