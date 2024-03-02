
public void UseTile(Player player, int x, int y) 
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	InfinityChest.Create();
	Config.tileInterface.SetLocation(new Vector2((float)x,(float)y));
	Main.playerInventory = true;
}
public class InfinityChest : Interfaceable 
{
    public static int offset = 1;

	public static void Create() 
    {
    Config.tileInterface = new InterfaceObj(new InfinityChest(), 30, 6); //Pass along this code instance, and the # of item slots you want to use

    for (int y = 0; y < 6; y++)
    {
        for (int x = 0; x < 5; x++)
        {
            Config.tileInterface.AddItemSlot(200+45*x,270+45*y);
        }
    }
    Config.tileInterface.AddText("Go to start", 200+45*5+10, 270+45*0, true, 0.9f,Color.White);
    Config.tileInterface.AddText("Go up 20", 200+45*5+10, 270+45*1, true, 0.9f,Color.White);
    Config.tileInterface.AddText("Go up 5", 200+45*5+10, 270+45*2, true, 0.9f,Color.White);
    Config.tileInterface.AddText("Go down 5", 200+45*5+10, 270+45*3, true, 0.9f,Color.White);
    Config.tileInterface.AddText("Go down 20", 200+45*5+10, 270+45*4, true, 0.9f,Color.White);
    Config.tileInterface.AddText("Go to end", 200+45*5+10, 270+45*5, true, 0.9f,Color.White);
    Item[] itemSlots = Config.tileInterface.itemSlots;

    for (int i = 0; i < 30; i++) 
    {
        if (itemSlots[i] == null)
            itemSlots[i] = new Item();
        if (i+offset < Main.maxItemTypes + Config.customItemsAmt && i+offset > 0)
        {
            itemSlots[i].SetDefaults(i+offset);
            itemSlots[i].stack = itemSlots[i].maxStack;
        }
        else
        {
            itemSlots[i].SetDefaults("Angel Statue");
        }
    }
    }
	public void ButtonClicked(int button) 
    {
    Main.player[Main.myPlayer].mouseInterface = true;
    if(button == 1)
        offset-=20;
    if(button == 2)
        offset-=5;
    if(button == 3)
        offset+=5;
    if(button == 4)
        offset+=20;
    if(offset < 1 || button == 0)
        offset = 1;
    if(offset > Main.maxItemTypes + Config.customItemsAmt -29 ||button == 5)
        offset = ((Main.maxItemTypes + Config.customItemsAmt - 29)/5)*5;

    Item[] itemSlots = Config.tileInterface.itemSlots;
    for (int i = 0; i < 30; i++) 
    {
        if (itemSlots[i] == null)
            itemSlots[i] = new Item();
        if (i+offset < Main.maxItemTypes + Config.customItemsAmt && i+offset > 0)
        {
            itemSlots[i].SetDefaults(i+offset);
            itemSlots[i].stack = itemSlots[i].maxStack;
        }
        else
        {
            itemSlots[i].SetDefaults("Angel Statue");
        }
    }
	}
	public bool CanPlaceSlot(int slot, Item mouseItem) {
		return true;
	}
	public void PlaceSlot(int slot) {
		Item[] itemSlots = Config.tileInterface.itemSlots;
        if (itemSlots[slot].stack > itemSlots[slot].maxStack)
            itemSlots[slot].stack = itemSlots[slot].maxStack;
		if(itemSlots[slot].stack==0)
            itemSlots[slot]=new Item();
	}

	public bool DropSlot(int slot) 
    {
		return false;
	}
}

/*
public int[] NPCNumsToTypes()
{
    int[] arr = new int[100]; // assuming there are a possible 100 town npcs.
    int index = 0;
    for (int i = 0; i < 10000; i++) // assume there are 10000 npc types.
    {
	    if( NPC.TypeToNum(i) >= 0) // it returns -1 if there's nothing
        {
            arr[index]=i;
            index++;
        }  
    }
    index--; // done for further calculations.
    int index2 = 0;
    int[] arrprocessed = new int[index]; // we make a new , shorter , more organized array here
    for (int i = 0; i < index; i++)
    {
	    arrprocessed[i]=arr[i];
    }
    return arrprocessed;
}
*/