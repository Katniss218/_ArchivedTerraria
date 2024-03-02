public static int posX,posY;

public void PlaceTile(int x, int y) 
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
}

public void UseTile(Player player, int x, int y) 
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	
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
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	
	return ModWorld.Fridge.DestroyFridge(x, y); //If there are no items in the chest, then let it be destroyed
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
		
		Config.tileInterface.AddText("Fridge", 200+45*0+10, 270+45*0-20, false, 0.9f,Color.White);
		
		//Config.tileInterface.AddText("Loot All", 200+45*5+10, 286, true, 0.9f,Color.White);
		//Config.tileInterface.AddText("Deposit All", 200+45*5+10, 286+26, true, 0.9f,Color.White);
		//Config.tileInterface.AddText("Quick Stack", 200+45*5+10, 286+52, true, 0.9f,Color.White);
		
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
		return;
	
		int id = ModWorld.Fridge.FindFridge(posX, posY);
	
		switch(button)
		{
			case 1:
				for (int i = 0; i < 20; i++)
				{
					if (ModWorld.fridge[id].item[i].type > 0)
					{
						Main.player[Main.myPlayer].GetItem(Main.myPlayer, ModWorld.fridge[id].item[i]);
						ModWorld.fridge[id].item[i] = new Item();
					}
				}
			
				break;
				
			case 2:
				for (int i = 40; i >= 10; i--)
				{
					Item item = Main.player[Main.myPlayer].inventory[i];
				
					if (item.stack > 0 && 
						item.potion || (item.consumable && item.buffType > 0) || item.healMana > 0 || 
						item.type == Config.itemDefs.byName["Bottled Water"].type 
					|| item.type == Config.itemDefs.byName["Apple"].type
					|| item.type == Config.itemDefs.byName["Cacao Bean"].type
					|| item.type == Config.itemDefs.byName["Cacao"].type
					|| item.type == Config.itemDefs.byName["Goldfish"].type
					|| item.type == Config.itemDefs.byName["Mushroom"].type
					|| item.type == Config.itemDefs.byName["Glowing Mushroom"].type )
					{
						if (item.maxStack > 1 )
						{
							for (int j = 0; j < 20; j++)
							{
								if (ModWorld.fridge[id].item[j].stack < ModWorld.fridge[id].item[j].maxStack && 
									item.IsTheSameAs(ModWorld.fridge[id].item[j]))
								{
									int stack = item.stack;
									if (item.stack + ModWorld.fridge[id].item[j].stack > ModWorld.fridge[id].item[j].maxStack)
									{
										stack = ModWorld.fridge[id].item[j].maxStack - ModWorld.fridge[id].item[j].stack;
									}
									item.stack -= stack;
									ModWorld.fridge[id].item[j].stack += stack;
									
									if(item.stack <= 0)
									{
										item = new Item();
									}
								}
								else if(ModWorld.fridge[id].item[j].stack == 0)
								{
									ModWorld.fridge[id].item[j] = new Item();
									ModWorld.fridge[id].item[j] = item;
									item = new Item();
								}
							}
						}
					}
				}
				break;
				
			case 3:
				break;
		}
	}
	
	public bool CanPlaceSlot(int slot, Item mouseItem) 
	{
		if(mouseItem.potion || (mouseItem.consumable && mouseItem.buffType > 0) || mouseItem.healMana > 0 
			|| mouseItem.type == Config.itemDefs.byName["Bottled Water"].type 
			|| mouseItem.type == Config.itemDefs.byName["Apple"].type
			|| mouseItem.type == Config.itemDefs.byName["Cacao Bean"].type
			|| mouseItem.type == Config.itemDefs.byName["Cacao"].type
			|| mouseItem.type == Config.itemDefs.byName["Goldfish"].type
			|| mouseItem.type == Config.itemDefs.byName["Mushroom"].type
			|| mouseItem.type == Config.itemDefs.byName["Glowing Mushroom"].type
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