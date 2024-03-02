//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.rangedDamage += 0.17f;
	player.magicDamage += 0.17f;
	player.manaCost -= 0.50f;
	player.statManaMax2 += 80;
}

public static void SetBonus(Player player) {
	player.setBonus = "+17 Crit, 1/5 chance of healing 1/4th the amount of melee damage dealt, +10 life regen/20 in water ";
	player.moveSpeed += 0.15f;
	player.meleeSpeed += 0.20f;
	player.rangedCrit += 17;
	player.magicCrit += 17;
	player.meleeCrit += 17;		
	player.lifeRegen += 10;

if (player.wet)  {
 		player.lifeRegen += 20;
		player.nightVision=true;
	}
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 39, (player.velocity.X) + (player.direction * 2), player.velocity.Y, 100, Color.SpringGreen, 1.0f);
 Main.dust[dust].noGravity = true;
Main.dust[dust].noLight = false;


}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(10)==0){
myPlayer.HealEffect(damage/4); 
myPlayer.statLife+=(damage/4);
}
}