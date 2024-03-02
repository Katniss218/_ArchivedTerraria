//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
static Player customPlayer;
public static void StatusNPC(NPC npc){
customPlayer.inventory[customPlayer.selectedItem].damage = (customPlayer.statLife/8)+55;
}

public static void UseItem(Player player, int playerID){
customPlayer = player;
}