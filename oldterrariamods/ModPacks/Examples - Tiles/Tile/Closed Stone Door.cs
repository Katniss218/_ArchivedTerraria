int id;
public void Initialize() {
	id = Main.rand.Next(1000);
}
public void UseTile(Player player, int x, int y) {
	if(Main.tile[x,y].type == Config.tileDefs.ID["Closed Stone Door"])
		Config.OpenCustomDoor(Player.tileTargetX, Player.tileTargetY, player.direction, "Open Stone Door");
	else Config.CloseCustomDoor(Player.tileTargetX, Player.tileTargetY, "Closed Stone Door");
	
	Main.NewText("Door ID: "+id);
}