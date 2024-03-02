public void UseTile(Player player, int x, int y){
	Color newColor;
	newColor = new Color(Main.rand.Next(255), Main.rand.Next(255), Main.rand.Next(255));
	player.shoeColor = newColor;
}