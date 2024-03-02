public static int posX,posY;

public void PlaceTile(int x, int y, int p) 
{
	RealPos(ref x,ref y);
	
	Main.NewText("Dresser Placed");
}

public void MouseOverTile(int x,int y,Player P)
{
    //all this code does is make the chest icon appear when you put your mouse over it
    P.noThrow = 2;
    P.showItemIcon = true;
	
    P.showItemIcon2 = Config.itemDefs.byName["Dresser"].type;
}

public void UseTile(Player player, int x, int y) 
{
	RealPos(ref x, ref y);
	
	posX = x;
	posY = y;
	
	Main.playerInventory = true;
	
	DresserInterface.Create();
	
	Config.tileInterface.SetLocation(new Vector2((float)x,(float)y));
	
	ModWorld.Dresser.CreateDresser(x, y);
	DresserInterface.FillDresser(x, y);
	
	Main.NewText("Dresser UseTile");
}

public bool CanDestroyTile(int x, int y) 
{
	RealPos(ref x, ref y);
	
	return ModWorld.Dresser.DestroyDresser(x, y); //If there are no items in the chest, then let it be destroyed
}

public void RealPos(ref int x,ref int y)
{
    Vector2 pos = Codable.GetPos(new Vector2(x, y));
    x = (int)pos.X;
    y = (int)pos.Y;
}

public class DresserInterface : Interfaceable 
{
	public static void Create() 
    {
		Config.tileInterface = new InterfaceObj(new DresserInterface(), 18, 1); //Pass along this code instance, and the # of item slots you want to use

		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 6; x++)
			{
				Config.tileInterface.AddItemSlot(200+45*x,270+45*y);
			}
		}
		
		Config.tileInterface.AddText("Dresser", 200+45*0+10, 270+45*0-20, false, 0.9f,Color.White);
		
		Item[] itemSlots = Config.tileInterface.itemSlots;

		for (int i = 0; i < 18; i++) 
		{
			if (itemSlots[i] == null)
			{
				itemSlots[i] = new Item();
				itemSlots[i].maxStack = 1;
			}
		}
    }
	
	public static void FillDresser(int x, int y)
	{
		int id = ModWorld.Dresser.FindDresser(x, y);
		
		//if(id == -1)
		//	return;
	
		Item[] itemSlots = Config.tileInterface.itemSlots;

		for (int i = 0; i < 18; i++) 
		{
			if (itemSlots[i] == null)
				itemSlots[i] = new Item();
				
			itemSlots[i] = ModWorld.dresser[id].item[i];
		}
	}
	
	public void ButtonClicked(int button) 
    {
	}
	
	public bool CanPlaceSlot(int slot, Item mouseItem) 
	{
		if(	mouseItem.vanity || (mouseItem.legSlot > 0 || mouseItem.bodySlot > 0 || mouseItem.headSlot > 0) || 
			mouseItem.type < 1 || mouseItem.stack < 1) 
		{
			return true;
		}
		
		return false;
	}
	
	public void PlaceSlot(int slot)
	{
		int id = ModWorld.Dresser.FindDresser(posX, posY);
		
		Item[] itemSlots = Config.tileInterface.itemSlots;
		
        if(itemSlots[slot].stack > itemSlots[slot].maxStack)
			itemSlots[slot].stack = itemSlots[slot].maxStack;
			
		if(itemSlots[slot].stack==0)
            itemSlots[slot]=new Item();
			
		for(int i = 0; i < itemSlots.Length; i++)
		{
			ModWorld.dresser[id].item[i] = itemSlots[i];
		}
	}

	public bool DropSlot(int slot) 
    {
		int id = ModWorld.Dresser.FindDresser(posX, posY);
		
		Item[] itemSlots = Config.tileInterface.itemSlots;
			
		for(int i = 0; i < itemSlots.Length; i++)
		{
			ModWorld.dresser[id].item[i] = itemSlots[i];
		}
	
		return false;
	}
}