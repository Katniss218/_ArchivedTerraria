

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(3)==0){
myPlayer.HealEffect(damage); 
myPlayer.statLife+=damage;
}
}