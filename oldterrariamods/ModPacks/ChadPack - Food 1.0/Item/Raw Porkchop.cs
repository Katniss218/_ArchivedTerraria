public void UseItem(Player player, int playerID){
	if (playerID == Main.myPlayer){
		ModPlayer.Hunger += ModPlayer.ValueTwo;
		player.AddBuff("Sick", 1000, false);
	}
}