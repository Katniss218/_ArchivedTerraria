public void UseItem(Player player, int playerID){
	if (playerID == Main.myPlayer){
		ModPlayer.Hunger += ModPlayer.ValueThree;
		player.AddBuff("Sick", 1200, false);
	}
}