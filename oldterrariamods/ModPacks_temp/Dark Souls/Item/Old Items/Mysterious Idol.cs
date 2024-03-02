//spawns archeologist, for dev purposes, ini should prevent this from happenning
public void UseItem(Player player, int playerID) { 
		NPC.NewNPC((int)player.position.X,(int)player.position.Y,"Archeologist",0);
}