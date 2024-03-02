public void UseTile(Player player, int x, int y) 
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	InfinityChest.Create();
	Config.tileInterface.SetLocation(new Vector2((float)x,(float)y));
	Main.playerInventory = true;
}
public class BagOfHolding : Interfaceable
{
	public static int offset = 1;

	public static void Create(Player player){
		Config.tileInterface = new InterfaceObj(new BagOfHolding(), 20, 5); //20 is number of slots, 5 is number of buttons
		for (int y = 0; y < 5; y++){
			for (int x = 0; x < 4; x++){
				Config.tileInterface.AddItemSlot(200+45*x,270+45*y);
			}
		}
		Config.tileInterface.AddText("Page 1", 200+45*5+10, 270+45*0, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 2", 200+45*5+10, 270+45*1, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 3", 200+45*5+10, 270+45*2, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 4", 200+45*5+10, 270+45*3, true, 0.9f, Color.White);
		Config.tileInterface.AddText("Page 5", 200+45*5+10, 270+45*4, true, 0.9f, Color.White);
		Item[] itemSlots = Config.tileInterface.itemSlots;
		for (int i = 0; i < 20; i++){
			if (itemSlots[i] == null){
				itemSlots[i] = new Item();
			}
			if (i+offset < player.bank6.length && i+offset > 0){
				if (player.bank6[i+offset].stack > 0){
					itemSlots[i] = player.bank6[i+offset];
				}
			}
		}
	}
	public void ButtonClicked(int button){
		if(button == 0){
			offset = 0;
		{
		if(button == 1){
			offset = 20;
		}
		if(button == 2){
			offset = 40;
		}
		if(button == 3){
			offset = 60;
		}
		if(button == 4){
			offset = 80;
		}
	}
	public bool CanPlaceSlot(int slot, Item mouseItem) {
		return true;
	}
	public void PlaceSlot(int slot) {
		Item[] itemSlots = Config.tileInterface.itemSlots;
	}

	public bool DropSlot(int slot){
		return false;
	}
}