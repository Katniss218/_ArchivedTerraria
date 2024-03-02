

//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.meleeCrit += 30;


}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(10)==0){
myPlayer.HealEffect(damage/10); 
myPlayer.statLife+=(damage/10);
}
}

public static void SetBonus(Player player) {
	player.setBonus = "Grants waterwalk, no knockback, plus 30% boost to Melee Speed, Melee Damage and Move Speed";
    
    player.waterWalk=true;
    player.noKnockback = true;
    player.meleeDamage += 0.30f;
    player.meleeSpeed += 0.30f;
    player.moveSpeed += 0.30f;



    
}


public void PlayerFrame(Player player){
	if (player.armor[0].name=="Dark Knight Helmet")
        {
			if (player.armor[2].name=="Dark Knight Greaves")
			{


 int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 27, (player.velocity.X) + (player.direction * 3), player.velocity.Y, 100, Color.BlueViolet, 1.0f);
 Main.dust[dust].noGravity = true;
}}}
