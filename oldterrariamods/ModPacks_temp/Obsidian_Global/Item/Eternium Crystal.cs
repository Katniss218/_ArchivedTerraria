
public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){

}

public void Initialize(){

}


public void UseItem(Player player, int playerID) {

}



public void Effects(Player player){
//player.ammoCost = 75;
player.archery = true;
float rangecrit = player.rangedCrit * 1.1f;
player.rangedCrit = (int) rangecrit;
}
