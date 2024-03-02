public void UseItem(Player player, int playerID){
	if (playerID == Main.myPlayer){
		ModPlayer.Hunger += ModPlayer.ValueFive;
		player.AddBuff("Sugar", 1800, false);
	}
}