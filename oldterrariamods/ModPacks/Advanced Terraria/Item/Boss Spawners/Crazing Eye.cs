public void UseItem(Player player, int playerID) { 
    Main.NewText("Crazer has awoken!");
	NPC.NewNPC((int)player.position.X,(int)player.position.Y,"Crazer",0);
}