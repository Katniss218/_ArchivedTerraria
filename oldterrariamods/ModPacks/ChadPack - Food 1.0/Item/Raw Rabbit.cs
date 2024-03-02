public void UseItem(Player player, int playerID){
	if (playerID == Main.myPlayer){
		ModPlayer.Hunger += ModPlayer.ValueOne;
		player.AddBuff("Sick", 800, false);
	}
}