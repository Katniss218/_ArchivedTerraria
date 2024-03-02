int ticksRequired=1000;
int ticks=0;
public void Initialize() {
	ticks=0;
}
public void Update(int x, int y) {
	//Main.NewText("Update called");
	string name=Main.tileName[(int)Main.tile[x,y].type];
	if(name=="Plant") {
		if(ticks==ticksRequired) {
			//Upgrade to plant level 2
			Main.tile[x,y].type = (byte)Config.tileDefs.ID["Plant2"];
			ticks=0;
		}
		else {
			ticks++;
			//Main.NewText("Ticks: "+ticks);
		}
	}
	else if(name=="Plant2") {
		if(ticks==ticksRequired) {
			//Upgrade to plant level 2
			Main.tile[x,y].type = (byte)Config.tileDefs.ID["Plant3"];
			ticks=0;
		}
		else ticks++;
	}
}