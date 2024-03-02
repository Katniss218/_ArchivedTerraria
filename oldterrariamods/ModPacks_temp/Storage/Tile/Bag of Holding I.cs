public void UseTile(Player player, int x, int y){
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	BagOfHolding.Create(player);
	Config.tileInterface.SetLocation(new Vector2((float)x,(float)y));
	Main.playerInventory = true;
}
public class BagOfHolding : Interfaceable{
	public static int offset = 0;
	public static void Create(Player player){
		if (player.statMana < 40){
			return;
		}
		player.statMana -= 40;
		Config.tileInterface = new InterfaceObj(new BagOfHolding(), 20, 5); //20 is number of slots, 5 is number of buttons
		for (int y = 0; y < 4; y++){ //Vertical boxes
			for (int x = 0; x < 5; x++){ //Horizontal boxes
				Config.tileInterface.AddItemSlot(200+45*x,270+45*y);
			}
		}
		Config.tileInterface.AddText("Page 1", 200+45*5+10, 270+35*0, true, 0.9f, Color.Blue);
		Config.tileInterface.AddText("Page 2", 200+45*5+10, 270+35*1, true, 0.9f, Color.White);
		/*
		Config.tileInterface.AddText("Page 3", 200+45*5+10, 270+35*2, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 4", 200+45*5+10, 270+35*3, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 5", 200+45*5+10, 270+35*4, true, 0.9f, Color.White);
		*/
		Item[] itemSlots = Config.tileInterface.itemSlots;
		UpdateWriter();
		UpdateSaver();
	}
	public void Update(int x, int y){
		
	}
	public void ButtonClicked(int button){
		UpdateSaver();
		Color[] buttonColors = Config.tileInterface.buttonColor;
		if(button == 0){
			offset = 0;
			buttonColors[0] = Color.Blue;
			buttonColors[1] = Color.White;
			buttonColors[2] = Color.White;
			buttonColors[3] = Color.White;
			buttonColors[4] = Color.White;
		}
		if(button == 1){
			offset = 20;
			buttonColors[0] = Color.White;
			buttonColors[1] = Color.Blue;
			buttonColors[2] = Color.White;
			buttonColors[3] = Color.White;
			buttonColors[4] = Color.White;
		}
		/*
		if(button == 2){
			offset = 40;
			buttonColors[0] = Color.White;
			buttonColors[1] = Color.White;
			buttonColors[2] = Color.Blue;
			buttonColors[3] = Color.White;
			buttonColors[4] = Color.White;
		}
		if(button == 3){
			offset = 60;
			buttonColors[0] = Color.White;
			buttonColors[1] = Color.White;
			buttonColors[2] = Color.White;
			buttonColors[3] = Color.Blue;
			buttonColors[4] = Color.White;
		}
		if(button == 4){
			offset = 80;
			buttonColors[0] = Color.White;
			buttonColors[1] = Color.White;
			buttonColors[2] = Color.White;
			buttonColors[3] = Color.White;
			buttonColors[4] = Color.Blue;
		}
		*/
		UpdateWriter();
		//UpdateSaver();
	}
	public bool CanPlaceSlot(int slot, Item mouseItem) {
		UpdateSaver();
		return true;
	}
	public void PlaceSlot(int slot){
		UpdateSaver();
	}
	public bool DropSlot(int slot){
		//Player player = Main.player[Main.myPlayer];
		Item[] itemSlots = Config.tileInterface.itemSlots;
		ModPlayer.bank3[slot+offset] = itemSlots[slot];
		UpdateSaver();
		offset = 0;
		UpdateWriter();
		return false;
	}
	
	public static void UpdateWriter(){
		//Player player = Main.player[Main.myPlayer];
		Item[] itemSlots = Config.tileInterface.itemSlots;
		for (int i = 0; i < 20; i++){
			itemSlots[i] = new Item();
			/*if (itemSlots[i] == null){
			}*/
			if (i+offset < ModPlayer.bank3.Length && i+offset >= 0){
				if (ModPlayer.bank3[i+offset].stack > 0){
					itemSlots[i] = ModPlayer.bank3[i+offset];
				}
			}
		}
	}
	public static void UpdateSaver(){
		Player player = Main.player[Main.myPlayer];
		Item[] itemSlots = Config.tileInterface.itemSlots;
		for (int i = 0; i < 20; i++){
			ModPlayer.bank3[i+offset] = itemSlots[i];
		}
	}
}
	