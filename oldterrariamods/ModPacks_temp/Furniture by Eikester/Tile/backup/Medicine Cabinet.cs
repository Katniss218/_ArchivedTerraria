public static int posX,posY;

public void PlaceTile(int x, int y, int p) 
{
	RealPos(ref x,ref y);
}

public void UseTile(Player player, int x, int y) 
{
	RealPos(ref x,ref y);
	
	posX = x;
	posY = y;
	
	Main.playerInventory = true;
	
	Refrigerator.Create();
	
	Config.tileInterface.SetLocation(new Vector2((float)x,(float)y));
	
	ModWorld.Fridge.CreateFridge(x, y);
	Refrigerator.FillFridge(x, y);
}

public bool CanDestroyTile(int x, int y) 
{
	RealPos(ref x,ref y);
	
	return ModWorld.Fridge.DestroyFridge(x, y); //If there are no items in the chest, then let it be destroyed
}

public void RealPos(ref int x,ref int y)
{
    Vector2 pos = Codable.GetPos(new Vector2(x, y));
    x = (int)pos.X;
    y = (int)pos.Y;
}

public class Refrigerator : Interfaceable 
{
	public static void Create() 
    {
		Config.tileInterface = new InterfaceObj(new Refrigerator(), 20, 1); //Pass along this code instance, and the # of item slots you want to use

		for (int y = 0; y < 4; y++)
		{
			for (int x = 0; x < 5; x++)
			{
				Config.tileInterface.AddItemSlot(200+45*x,270+45*y);
			}
		}
		
		Config.tileInterface.AddText("Medicine Cabinet", 200+45*0+10, 270+45*0-20, false, 0.9f,Color.White);
		
		Item[] itemSlots = Config.tileInterface.itemSlots;

		for (int i = 0; i < 20; i++) 
		{
			if (itemSlots[i] == null)
				itemSlots[i] = new Item();
		}
    }
	
	public static void FillFridge(int x, int y)
	{
		int id = ModWorld.Fridge.FindFridge(x, y);
		
		//if(id == -1)
		//	return;
	
		Item[] itemSlots = Config.tileInterface.itemSlots;

		for (int i = 0; i < 20; i++) 
		{
			if (itemSlots[i] == null)
				itemSlots[i] = new Item();
				
			itemSlots[i] = ModWorld.fridge[id].item[i];
		}
	}
	
	public void ButtonClicked(int button) 
    {
	}
	
	public bool CanPlaceSlot(int slot, Item mouseItem) 
	{
		if(mouseItem.potion || (mouseItem.consumable && mouseItem.buffType > 0) || mouseItem.healMana > 0 
			|| mouseItem.type < 1 || mouseItem.stack < 1)
		{
			return true;
		}
		
		return false;
	}
	
	public void PlaceSlot(int slot) 
	{
		int id = ModWorld.Fridge.FindFridge(posX, posY);
		
		if(id == -1)
			return;
	
		Item[] itemSlots = Config.tileInterface.itemSlots;
		
        if(itemSlots[slot].stack > itemSlots[slot].maxStack)
			itemSlots[slot].stack = itemSlots[slot].maxStack;
			
		if(itemSlots[slot].stack==0)
            itemSlots[slot]=new Item();
			
		ModWorld.fridge[id].item[slot] = new Item();
		ModWorld.fridge[id].item[slot] = itemSlots[slot];
	}

	public bool DropSlot(int slot) 
    {
		int id = ModWorld.Fridge.FindFridge(posX, posY);
		
		Item[] itemSlots = Config.tileInterface.itemSlots;
			
		for(int i = 0; i < itemSlots.Length; i++)
		{
			ModWorld.fridge[id].item[i] = itemSlots[i];
		}
	
		return false;
	}
}