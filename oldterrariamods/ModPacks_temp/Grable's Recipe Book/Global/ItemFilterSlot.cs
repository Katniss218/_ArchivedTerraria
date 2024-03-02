
/*
 * item filter slot
 */
public class ItemFilterSlot : Interfaceable {
	const float SCALE = 0.85f;
	
	public Item item;
	public float oldscale;
	public Texture2D oldtex;
	public InterfaceObj gui;
	public Texture2D slottex;
	public bool toggle;
	
	public static InterfaceObj Create()
	{
		ItemFilterSlot intf = new ItemFilterSlot();
		InterfaceObj gui = new InterfaceObj( intf, 1, 0) { display = true };
		gui.AddItemSlot( (int)itemslotpos.X, (int)itemslotpos.Y);
		intf.gui = gui;
		return gui;
	}

	public void ButtonClicked(int btn)	{}
	
	public bool SlotHasItem( int slot) {
		if(slot > 0) return false;
		return gui.itemSlots[slot] != null && !gui.itemSlots[slot].IsBlankItem();
	}

	public bool PreDrawSlot(SpriteBatch batch, int slot) {
		oldscale = Main.inventoryScale;
		oldtex = Main.inventoryBack5Texture;
		slottex = Main.inventoryBack8Texture; //9 3 7
		Main.inventoryBack5Texture = slottex;		
		Main.inventoryScale = SCALE;
		return true;
	}
	
	public bool PostDrawSlot(SpriteBatch batch, int slot) {
		if(slot > 0) return false;
		Main.inventoryBack5Texture = oldtex;
		Main.inventoryScale = oldscale;
		Vector2 pos = gui.slotLocation[slot];
		if(!SlotHasItem(slot)) {
			Rectangle? src = new Rectangle?(new Rectangle(0, 0, bookTexture.Width, bookTexture.Height));	
			if((Main.mouseItem == null || Main.mouseItem.IsBlankItem()) && MouseInsideRect( pos, slottex.Width, slottex.Height)) {
				simpleMouseText	= "Toggle The Recipe Book\n(Drop an Item for quick filtering)";
			}
			pos.X += ((slottex.Width * SCALE) / 2) - (bookTexture.Width / 2);
			pos.Y += ((slottex.Height * SCALE) / 2) - (bookTexture.Height / 2);
			batch.Draw( bookTexture, pos, src, new Color(128,128,128,128), 0f, origin, 1f, SpriteEffects.None, 0f);	
		}
		return true;
	}
	
	public bool CanPlaceSlot(int slot, Item mouseItem) {
		if(slot > 0) return false;
		toggle = (mouseItem == null || mouseItem.IsBlankItem()) && !SlotHasItem(slot);
		return true;
	}
	
	public void PlaceSlot(int slot) {
		if(slot > 0) return;
		if(SlotHasItem(slot)) {
			SetFilterItem( gui.itemSlots[slot]);
			ShowGui();
		} else if(toggle) {
			ToggleGui();
		}
	}
	
	public bool DropSlot(int slot) {
		return false;
	}
}