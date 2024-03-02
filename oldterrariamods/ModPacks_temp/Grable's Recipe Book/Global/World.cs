#INCLUDE "Settings.cs"
#INCLUDE "ModSettings.cs"
#INCLUDE "History.cs"
#INCLUDE "Textures.cs"
#INCLUDE "Skinning.cs"
#INCLUDE "Search.cs"
#INCLUDE "Recipes.cs"
#INCLUDE "Crafting.cs"
#INCLUDE "Util.cs"
#INCLUDE "ItemFilterSlot.cs"

public static bool guidisplay;

// used for drawing things
public static Vector2 origin;

// activation key timer
public const int KEY_INTERVAL= 15;
public static int keydelay;

// available mode update timer
public const int AVAILMODE_INTERVAL = 35;
public static int availdelay;
private static bool availmode = false;

// recipe page props
private static int toppage = 0;
private static int pagesize = 0;
private static int lastpagesize = 0;

// hover tooltip and spawning
private const int ITEM_SPAWN_INTERVAL = 5;
private static Item hoveritem = null;
private static int hoverrecipe = -1;
private static int spawndelay;


// currently visible recipes
private static List<Recipe> allrecipes;

// item filters by mod
private static bool guifilters;
private static string[] filternames;
private static bool[] filterinclude;
private static Dictionary<string, List<Recipe>> filterrecipes;

// item filters by type
private static bool guitypes;
private static string[] typenames = {"Melee","Ranged","Magic","Head","Torso","Legs","Vanity","Ammo","Accessory","Consumable","Tile","Wall","Material","Other"};
private static bool[] typeinclude = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
private static Dictionary<string, List<Recipe>> typerecipes;

// filter by required item
private static Item filteritem;
public static Item loaded_filteritem; // for the slot
public static InterfaceObj itemslot;

// filter by name
private const int SEARCH_INTERVAL = 30;
private const int SEARCH_FIELD_CAP = 28;
private static bool guisearch = true;
private static bool searchactive;
private static string searchtext;
private static string oldsearchtext;
private static int searchdelay;


private static string simpleMouseText;
private static bool mb1;
private static Microsoft.Xna.Framework.Input.MouseState mstate, oldmstate;

private static bool last_player_inv;
private static bool delayed_inv_show;

private static bool inside_initialize = true;

public static void Initialize( int modid) {
	inside_initialize = true;
	CheckCheatMode();
	LoadTextures();
	EnumRecipes();
	UpdateScreenChange();	
	toppage = 0;
	pagesize = FindPageSize( toppage);
	itemslot = ItemFilterSlot.Create();
	if(loaded_filteritem != null) {
		itemslot.itemSlots[0] = loaded_filteritem;
		SetFilterItem(loaded_filteritem);
	}
	inside_initialize = false;	
}

private static void CheckCheatMode() {
	if(!ModGeneric.can_cheat) {
		cfg_needs_crafting_stations = true;
		cfg_free_item_crafting = false;
		cfg_can_spawn_any_item = false;
	}
}

	
/*
 * available recipes button
 */
public static void ToggleAvailableMode() {
	PushHistory();
	availmode = !availmode;
	
	RebuildFilterRecipes();
	FirstPage();
}
	
public static void RefreshAvailableMode() {
	if(availmode) {
		// ignores history
		//PushHistory();
		RebuildFilterRecipes(inside_findrecipes);
		FirstPage();
	}
}
	

/*
 * recipe book gui
 */
	
public static void ShowGui() {
	if(!cfg_enabled) return;
	guidisplay = true;
	if(cfg_close_player_inv && !cfg_sync_with_inv) {
		Main.playerInventory = false;
	} else if(cfg_sync_with_inv) {
		//Main.playerInventory = true;
		delayed_inv_show = true;
	}
	if(cfg_pause_game && Main.autoPause) {
		Main.modPause = true;
		Main.gamePaused = true;
	}
	last_player_inv = Main.playerInventory;
	UpdateScreenChange();
}

public static void HideGui() {
	if(!cfg_enabled) return;
	guidisplay = false;
	if(cfg_pause_game && Main.autoPause) {
		Main.modPause = false;
		Main.gamePaused = false;
	}
	HideFilterMenu();
	HideTypeFilterMenu();
	//ResetClick();
	if(cfg_sync_with_inv) {
		Main.playerInventory = false;
	}
	if(searchactive) {
		DeSelectSearchFilter();
	}
}

public static void ToggleGui() {
	if(!cfg_enabled) return;
	if(guidisplay) {
		HideGui();
	} else {
		ShowGui();
	}
}

	
/*
 * filter menu gui
 */
public static void HideFilterMenu() {
	guifilters = false;
}
	
public static void ToggleFilterMenu() {
	if(!guidisplay) return;
	guifilters = !guifilters;
}
	
public static void ToggleFilterIndex( int index) {
	PushHistory();
	ModWorld.filterinclude[index] = !ModWorld.filterinclude[index];	
	RebuildFilterRecipes();
	FirstPage();
}
	
public static void SelectModsAll() {
	PushHistory();
	for( int i=0; i<filterinclude.Length; i++) {
		filterinclude[i] = true;
	}	
	RebuildFilterRecipes();
	FirstPage();	
}
	
public static void SelectModsNone() {
	PushHistory();
	for( int i=0; i<filterinclude.Length; i++) {
		filterinclude[i] = false;
	}	
	RebuildFilterRecipes();
	FirstPage();	
}
	
/*
 * type filter menu gui
 */
public static void HideTypeFilterMenu() {
	guitypes = false;
}
	
public static void ToggleTypeFilterMenu() {
	if(!guidisplay) return;
	guitypes = !guitypes;
}

public static void ToggleTypeFilterIndex( int index) {
	PushHistory();
	ModWorld.typeinclude[index] = !ModWorld.typeinclude[index];	
	RebuildFilterRecipes();
	FirstPage();
}
	
public static void SelectTypesAll() {
	PushHistory();
	for( int i=0; i<typeinclude.Length; i++) {
		typeinclude[i] = true;
	}	
	RebuildFilterRecipes();
	FirstPage();
}
	
public static void SelectTypesNone() {
	PushHistory();
	for( int i=0; i<typeinclude.Length; i++) {
		typeinclude[i] = false;
	}	
	RebuildFilterRecipes();
	FirstPage();	
}

	
/*
 * required item filter
 */
public static void SetFilterItem( Item item) {
	if(item == null || item.IsBlankItem()) {
		ResetFilterItem();
		return;
	}
	PushHistory();
	filteritem = item;
	RecalcFilterSocket();	
	RebuildFilterRecipes();
	FirstPage();
}

public static void ResetFilterItem() {
	PushHistory();
	filteritem = null;	
	RebuildFilterRecipes();
	FirstPage();	
}
	
public static void SetLoadedFilterItem( Item item) {
	if(item == null || item.IsBlankItem()) {
		loaded_filteritem = null;
	} else {
		loaded_filteritem = item;
	}
}
	
public static Item GetSlotItem() {
	if(itemslot == null) return null;
	return itemslot.itemSlots[0];
}


/*
 * recipe book page handling
 */
private static int FindMaxItemHeight( int index) {
	if(allrecipes.Count == 0) return 0;
	if( index < 0 || index >= allrecipes.Count) return 0;
	
	Texture2D tex = Main.itemTexture[ allrecipes[index].createItem.type];
	if(tex == null) return 0;
		
	int height = tex.Height;	
	for( int i = 0; i < allrecipes[index].requiredItem.Length; i++) {
		int h = Main.itemTexture[ allrecipes[index].requiredItem[i].type].Height;
		if( h > height) height = h;
	}
	return height;
}
		
private static int FindPageSize( int start) {
	if(allrecipes.Count == 0) return 0;
	
	int height = 0;
	int count = 0;
	for( int i = start; i < allrecipes.Count; i++) {
		int h = FindMaxItemHeight(i);
		int h2 = height + h + ITEM_SEP_Y;
		if(cfg_show_stack_sizes) {
			h2 += ITEM_SEP_STACKSIZES_Y * 2;
		}
		if( h2 >= areaheight) break;
		height = h2;
		count += 1;
	}
	return count;
}
		
private static void PageRedisplay() {
		pagesize = FindPageSize(toppage);
}

public static void FirstPage() {
	toppage = 0;
	pagesize = FindPageSize( toppage);
	lastpagesize = 0;
}

public static void PrevPage() {
	if(toppage == 0) return;
	int tempsize = pagesize;
	toppage -= lastpagesize;
	if(toppage < 0) toppage = 0;	
	pagesize = FindPageSize( toppage);
	lastpagesize = tempsize;
}
		
public static void NextPage() {
	int temptop = toppage;
	int tempsize = pagesize;
	
	toppage += pagesize;
	if( toppage >= allrecipes.Count) {
		toppage = temptop;
		return;
	}
	
	pagesize = FindPageSize( toppage);	
	if( pagesize == 0 || toppage + pagesize > allrecipes.Count) {
		toppage = temptop;
		pagesize = tempsize;
		return;
	}
	
	lastpagesize = tempsize;
}
	
public static void PreDrawBackground( SpriteBatch batch) {
// clear mouse tooltip, for when the inventory isnt up
	simpleMouseText = null;	
}

public static bool PreDrawAvailableRecipes( SpriteBatch batch) {
	if(cfg_need_book_to_open) return true;
	if(cfg_hide_orig_recipes) return false;
	return true;
}	


public static void PreDrawInterface(SpriteBatch batch)
{
	if(!cfg_enabled) return;
	
	// check that the player has the recipe book
	if(cfg_need_book_to_open) {		
		Player p = Main.player[Main.myPlayer];
		bool gotit = false;
		for( int i=0; i<p.inventory.Length; i++) {
			if( p.inventory[i] == null) continue;
			if( p.inventory[i].name == "Recipe Book") {
				gotit = true;
				break;
			}
		}
		if(!gotit) {
			// havent got the book, do nothing!
			return;
		}
	}
	
	UpdateScreenChange();
	
	Rectangle? src;
	Vector2 pos;
	Vector2 sz;	
	
	if( keydelay > 0) keydelay--;	
	
	if(guidisplay) {
// availmode live refreshing
		if( cfg_live_avail_refresh && availmode) {
			if( availdelay > 0) availdelay --;
			if(availdelay == 0) {
				RebuildFilterRecipes();
				availdelay = AVAILMODE_INTERVAL;
			}
		}
			
// search live update timer
		if(cfg_live_search_refresh && searchactive) {
			if(searchdelay > 0) searchdelay--;
		}
			
// item spawn timer			
		if( spawndelay > 0) spawndelay--;
	}
	
// clear mouse tooltip	
	simpleMouseText = null;

// activation by key	
	if( keydelay == 0 && Main.keyState.IsKeyDown(ModGeneric.DisplayKey)) {
		ToggleGui();
		keydelay = KEY_INTERVAL;
	}
	
// draw recipe book icon
	if(cfg_show_book_icon && !Main.playerInventory) {
		pos = bookpos;
		src = new Rectangle?(new Rectangle(0, 0, bookTexture.Width, bookTexture.Height));
		batch.Draw( bookTexture, pos, src, bookcolor, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for highlight
		if(MouseInsideRect( pos, bookTexture.Width, bookTexture.Height)) {
			BeginClick();
			simpleMouseText = "Toggle The Recipe Book";
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				ToggleGui();
				ResetClick();
				return;
			}
		}
	}

// sync with player inventory	
	if(cfg_sync_with_inv) {
		if(delayed_inv_show) {
			delayed_inv_show = false;
			Main.playerInventory = true;
		}
		guidisplay = Main.playerInventory;		
	} else {
		if(cfg_close_book_on_inv_close) {
			if(!Main.playerInventory && last_player_inv) {
				guidisplay = false;
				//last_player_inv = Main.playerInventory;
				//return;
			}
			last_player_inv = Main.playerInventory;
		}
	}
		
	if(guidisplay) {
		string wtf = string.Empty;
		string str;
	
		// handle clicks properly
		if( MouseInsideRect( guipos, formTexture.Width,formTexture.Height) || MouseInsideRect(menurect) || MouseInsideRect(typerect)) {
			BeginClick();
		}
		
		if(delayedfilteritem != null) {
			SetFilterItem(delayedfilteritem);
			delayedfilteritem = null;
		}
		
	// reset hover first
		hoveritem = null;
		hoverrecipe = -1;
	
	// check that mouse isnt inside one of the menus
		bool canclick = true;
		if(guifilters && MouseInsideRect(menurect)) canclick = false;
		if(guitypes && MouseInsideRect(typerect)) canclick = false;
			
	// change pages with mouse wheel
		oldmstate = mstate;
		mstate = Microsoft.Xna.Framework.Input.Mouse.GetState();
		int val = (mstate.ScrollWheelValue - oldmstate.ScrollWheelValue) / 120;
		if(val != 0) {
			int sel = Main.player[Main.myPlayer].selectedItem;
			if( val > 0) {
				PrevPage();
				sel++;
				if(sel >= 10) sel = 0;
			} else if( val < 0) {		
				NextPage();
				sel--;
				if(sel < 0) sel = 9;
			}
			 Main.player[Main.myPlayer].selectedItem = sel;
		}

	// draw background				
		src = new Rectangle?(new Rectangle(0, 0, formTexture.Width, formTexture.Height));
		batch.Draw( formTexture, guipos, src, color, 0f, origin, 1f, SpriteEffects.None, 0f);
	
	// draw title
		src = new Rectangle?(new Rectangle(0, 0, titleTexture.Width, titleTexture.Height));
		batch.Draw( titleTexture, titlepos, src, titlecolor, 0f, origin, 1f, SpriteEffects.None, 0f);
		pos = titlepos + GetCenteredTextPos( Main.fontMouseText, "Recipe Book", titleTexture);
		pos.Y += 3;
		DrawString2( batch, Main.fontMouseText, "Recipe Book", pos, Color.Black);	
				
	// draw recipe area
		src = new Rectangle?(new Rectangle(0, 0, areaTexture.Width, areaTexture.Height));
		batch.Draw( areaTexture, areapos, src, areacolor, 0f, origin, 1f, SpriteEffects.None, 0f);				
	
	// draw and handle filter item socket
		if(filteritem != null) {
			// draw socket background
			src = new Rectangle?(new Rectangle(0, 0, socketTexture.Width, socketTexture.Height));
			batch.Draw( socketTexture, socketpos, src, color, 0f, origin, 1f, SpriteEffects.None, 0f);
		
			// draw filter item
			if(filteritem.type != 0) {
				Texture2D t = Main.itemTexture[ filteritem.type];
				pos = socketpos;
				pos.X += (socketTexture.Width / 2) - (t.Width / 2);
				pos.Y += (socketTexture.Height / 2) - (t.Height / 2);
		
				DrawItem( batch, filteritem, pos);
			}
			
			// check for click or set item hover
			if(canclick && MouseInsideRect(socketrect)) {				
				if(Main.mouseLeft && Main.mouseLeftRelease) {
					ResetFilterItem();
					ResetClick();					
				} else {
					hoveritem = filteritem;
				}
			}
		}

	// draw close button
		src = new Rectangle?(new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height));
		batch.Draw( buttonTexture, closepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
		// check for highlight
		if(canclick && MouseInsideRect( closepos, buttonTexture.Width, buttonTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, buttonTextureHL.Width, buttonTextureHL.Height));
			batch.Draw( buttonTextureHL, closepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				ToggleGui();
				ResetClick();				
			}
		}
		pos = closepos + GetCenteredTextPos( Main.fontMouseText, "Close", buttonTexture);
		pos.Y += 3;
		DrawString2( batch, Main.fontMouseText, "Close", pos, Color.White);

	// draw prev button
		src = new Rectangle?(new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height));
		batch.Draw( buttonTexture, prevpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for highlight
		if(canclick && MouseInsideRect( prevpos, buttonTexture.Width, buttonTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, buttonTextureHL.Width, buttonTextureHL.Height));
			batch.Draw( buttonTextureHL, prevpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				PrevPage();
				ResetClick();				
			}
		}
		pos = prevpos + GetCenteredTextPos( Main.fontMouseText, "Prev Page", buttonTexture);
		pos.Y += 2;
		DrawString2( batch, Main.fontMouseText, "Prev Page", pos, Color.White);			
	
	// draw next button
		src = new Rectangle?(new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height));
		batch.Draw( buttonTexture, nextpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for highlight
		if(canclick && MouseInsideRect( nextpos, buttonTexture.Width, buttonTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, buttonTextureHL.Width, buttonTextureHL.Height));
			batch.Draw( buttonTextureHL, nextpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				NextPage();
				ResetClick();				
			}
		}
		pos = nextpos + GetCenteredTextPos( Main.fontMouseText, "Next Page", buttonTexture);
		pos.Y += 3;
		DrawString2( batch, Main.fontMouseText, "Next Page", pos, Color.White);
			
	// draw mod filter button
		src = new Rectangle?(new Rectangle(0, 0, smallbtnTexture.Width, smallbtnTexture.Height));
		batch.Draw( smallbtnTexture, filterpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for highlight
		if(MouseInsideRect( filterpos, smallbtnTexture.Width, smallbtnTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, smallbtnTextureHL.Width, smallbtnTextureHL.Height));
			batch.Draw( smallbtnTextureHL, filterpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				ToggleFilterMenu();
				ResetClick();				
			}
		}
		pos = filterpos + GetCenteredTextPos( Main.fontMouseText, "Mods", smallbtnTexture);
		pos.Y += 3;
		DrawString2( batch, Main.fontMouseText, "Mods", pos, Color.White);
		
	// draw mod filter all/none buttons
		pos = filterpos;
		pos.X +=  smallbtnTexture.Width + 4;
		pos.Y +=  smallbtnTexture.Height - 4;		
		src = new Rectangle?(new Rectangle(0, 0, allbtnTexture.Width, allbtnTexture.Height));
		batch.Draw( allbtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for click
		if(MouseInsideRect( pos, allbtnTexture.Width, allbtnTexture.Height) && Main.mouseLeft && Main.mouseLeftRelease) {
			SelectModsAll();
			ResetClick();			
		}
		
		pos.Y += allbtnTexture.Height + 2;		
		src = new Rectangle?(new Rectangle(0, 0, nonebtnTexture.Width, nonebtnTexture.Height));
		batch.Draw( nonebtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);		
		// check for click
		if(MouseInsideRect( pos, nonebtnTexture.Width, nonebtnTexture.Height) && Main.mouseLeft && Main.mouseLeftRelease) {
			SelectModsNone();
			ResetClick();			
		}
		
	// draw type filter button
		src = new Rectangle?(new Rectangle(0, 0, smallbtnTexture.Width, smallbtnTexture.Height));
		batch.Draw( smallbtnTexture, typepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for highlight
		if(MouseInsideRect( typepos, smallbtnTexture.Width, smallbtnTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, smallbtnTextureHL.Width, smallbtnTextureHL.Height));
			batch.Draw( smallbtnTextureHL, typepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				ToggleTypeFilterMenu();
				ResetClick();
			}
		}
		pos = typepos + GetCenteredTextPos( Main.fontMouseText, "Types", smallbtnTexture);
		pos.Y += 3;
		DrawString2( batch, Main.fontMouseText, "Types", pos, Color.White);
		
	// draw type filter all/none buttons
		pos = typepos;
		pos.X -=  allbtnTexture.Width + 4;
		pos.Y +=  smallbtnTexture.Height - 4;
		src = new Rectangle?(new Rectangle(0, 0, allbtnTexture.Width, allbtnTexture.Height));
		batch.Draw( allbtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for click
		if(MouseInsideRect( pos, allbtnTexture.Width, allbtnTexture.Height) && Main.mouseLeft && Main.mouseLeftRelease) {
			SelectTypesAll();
			ResetClick();			
		}
		
		pos.Y += allbtnTexture.Height + 2;
		src = new Rectangle?(new Rectangle(0, 0, nonebtnTexture.Width, nonebtnTexture.Height));
		batch.Draw( nonebtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		// check for click
		if(MouseInsideRect( pos, nonebtnTexture.Width, nonebtnTexture.Height) && Main.mouseLeft && Main.mouseLeftRelease) {
			SelectTypesNone();
			ResetClick();			
		}
		
	// draw available button
		src = new Rectangle?(new Rectangle(0, 0, availbtnTexture.Width, availbtnTexture.Height));
		if(availmode) {
			batch.Draw( availbtnTextureON, availpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		} else {
			batch.Draw( availbtnTexture, availpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		}
		// check for highlight
		if(MouseInsideRect( availpos, availbtnTexture.Width, availbtnTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, availbtnTextureHL.Width, availbtnTextureHL.Height));
			batch.Draw( availbtnTextureHL, availpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				ToggleAvailableMode();
				ResetClick();
			}
		}
		//pos = availpos + GetCenteredTextPos( Main.fontMouseText, "Available", availbtnTexture);
		//pos.Y += 3;
		//DrawString2( batch, Main.fontMouseText, "Available", pos, Color.White);		
		pos = availpos + GetCenteredTextPos( Main.fontItemStack, "Available", availbtnTexture);
		pos.X += 5;
		pos.Y += 3;
		DrawString2( batch, Main.fontItemStack, "Available", pos, Color.White);		

		
	// draw home history button
		pos = arrowpos;
		pos.X -= homeTexture.Width + 10;
		
		src = new Rectangle?(new Rectangle(0, 0, homeTexture.Width, homeTexture.Height));
		if( history.Count > 0) {
			batch.Draw( homeTextureON, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		} else {
			batch.Draw( homeTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		}
		// check for highlight
		if(MouseInsideRect( pos, homeTexture.Width, homeTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, homeTextureHL.Width, homeTextureHL.Height));
			batch.Draw( homeTextureHL, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				HomeHistory();
				ResetClick();				
			}
		}
		
	// draw prev history button
		pos = arrowpos;		
		
		src = new Rectangle?(new Rectangle(0, 0, prevTexture.Width, prevTexture.Height));
		if( history.Count > 0) {
			if(/*history.Count == 1 || */ historyindex > 0) {
				batch.Draw( prevTextureON, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			} else {
				batch.Draw( prevTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			}
		} else {
			batch.Draw( prevTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
		}
		// check for highlight
		if(MouseInsideRect( pos, prevTexture.Width, prevTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, prevTextureHL.Width, prevTextureHL.Height));
			batch.Draw( prevTextureHL, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				PrevHistory();
				ResetClick();				
			}
		}
		
	// draw next history button
		pos.X += prevTexture.Width + 4;
		
		src = new Rectangle?(new Rectangle(0, 0, nextTexture.Width, nextTexture.Height));
		if( history.Count > 0 && historyindex < history.Count - 1) {
			batch.Draw( nextTextureON, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);				
		} else {
			batch.Draw( nextTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);				
		}
		// check for highlight
		if(MouseInsideRect( pos, nextTexture.Width, nextTexture.Height)) {
			src = new Rectangle?(new Rectangle(0, 0, nextTextureHL.Width, nextTextureHL.Height));
			batch.Draw( nextTextureHL, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for click
			if(Main.mouseLeft && Main.mouseLeftRelease) {
				NextHistory();
				ResetClick();				
			}
		}
	
/*		disabled, as it doesnt display correctly.
		
		// draw history index / count
		if( historyindex < 0) {
			str = "0 / 0";
		} else {
			str = historyindex + " / " + history.Count;
		}
		Vector2 sz2 = Main.fontItemStack.MeasureString(str);
		pos.X = (arrowpos.X + prevTexture.Width + 2) -  (sz2.X / 2);
		pos.Y = arrowpos.Y - ((sz2.Y / 2f) + 4);
		DrawString( batch, Main.fontItemStack, str, pos, solid);
*/

	// draw vertical seperator
		if(cfg_draw_vline) {
			Vector2 vlinepos = guipos;
			vlinepos.X += ITEM_SEP_REQ;
			vlinepos.Y += 66;
		
			src = new Rectangle?(new Rectangle(0, 0, vlineTexture.Width, vlineTexture.Height));
			batch.Draw( vlineTexture, vlinepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
		}
		
	// draw page counter
		if( toppage + pagesize >= allrecipes.Count) {
			str = allrecipes.Count + " / " + allrecipes.Count;			
		} else if( allrecipes.Count == 0) {
			str = "0 / 0";
		} else {
			str = (1+toppage) + " / " + allrecipes.Count;
		}
		if( allrecipes.Count != Main.recipe.Length) str += " (" + Main.recipe.Length + ")";
		//sz = Main.fontCombatText[0].MeasureString(str);
		sz = Main.fontItemStack.MeasureString(str);
		pos = pagespos;
		pos.X -= sz.X / 2f;
		//DrawString( batch, Main.fontCombatText[0], str, pos, solid);
		DrawString( batch, Main.fontItemStack, str, pos, solid);

	// draw recipies
		pos = areapos2;
		
		if( allrecipes.Count > 0) {			
			if(delayedfilteritem != null) {
				SetFilterItem(delayedfilteritem);
				delayedfilteritem = null;
			}
			
			for( int i = toppage; i < toppage + pagesize; i++) {
				if( i >= allrecipes.Count) break;
				if( allrecipes[i].createItem.type == 0) continue;
				
				// get max height of required items
				int hh = FindMaxItemHeight(i);
				if(cfg_show_stack_sizes) {
					hh += ITEM_SEP_STACKSIZES_Y;
				}					
			
			// draw the created item
				Vector2 rpos = pos;
				rpos.X += 2;
				Texture2D tex = Main.itemTexture[ allrecipes[i].createItem.type];
				DrawItem( batch, allrecipes[i].createItem, rpos);
			
			// draw stacksize of recipe item
				if(cfg_show_stack_sizes) {
					str = ""+allrecipes[i].createItem.stack;
					sz = Main.fontItemStack.MeasureString(str);
					Vector2 spos = pos;				
					spos.X += (tex.Width / 2) - (sz.X / 2);
					spos.Y += hh - ITEM_SEP_STACKSIZES_Y;
					Color c = solid;
					if(cfg_show_missing_colors) {
						// check if player has all items required
						for( int j = 0; j < allrecipes[i].requiredItem.Length; j++) {
							if( allrecipes[i].requiredItem[j].type == 0) continue;
							if( FindItemSlot( Main.player[Main.myPlayer], allrecipes[i].requiredItem[j]) == -1) {
								c = missingcolor;
								break;
							}
						}
					}
					DrawString( batch, Main.fontItemStack, str, spos, c);
				}
			
				// check if mouse is hovering
				if(canclick && MouseInsideRect( pos, tex.Width, tex.Height)) {
					//BeginClick();
					hoveritem = (Item)allrecipes[i].createItem.Clone();
					if(allrecipes[i].requiredTile.Length > 0) {
						hoverrecipe = i;
					}
					if( Main.mouseLeft && Main.mouseLeftRelease) {
						HandleItemClick(true);
					} else if( spawndelay == 0 && Main.mouseRight && !Main.mouseRightRelease) {
						HandleItemClick(false);
						spawndelay = ITEM_SPAWN_INTERVAL;
					}
				}
					
				pos.X = guipos.X + ITEM_SEP_REQ + 12;					
					
			// draw the required items
				for( int j = 0; j < allrecipes[i].requiredItem.Length; j++) {
					if( allrecipes[i].requiredItem[j].type == 0) continue;
				
				// draw the required item
					Texture2D t = Main.itemTexture[ allrecipes[i].requiredItem[j].type];
					DrawItem( batch, allrecipes[i].requiredItem[j], pos);
				
				// draw stacksize of required item
					if(cfg_show_stack_sizes) {
						str = ""+allrecipes[i].requiredItem[j].stack;
						Vector2 ssz = Main.fontItemStack.MeasureString(str);
						Vector2 sspos = pos;
						sspos.Y += hh - ITEM_SEP_STACKSIZES_Y;
						sspos.X += (t.Width / 2) - (ssz.X / 2);
						Color c = solid;
						if(cfg_show_missing_colors) {
							if( FindItemSlot( Main.player[Main.myPlayer], allrecipes[i].requiredItem[j]) == -1) {
								c = missingcolor;
							}
						}
						DrawString( batch, Main.fontItemStack, str, sspos, c);
					} 
					
				// draw horizontal seperator
					if(cfg_draw_hline) {
						Vector2 hlinepos = pos;
						hlinepos.X = guipos.X + 43;
						hlinepos.Y += hh;
					
						if(cfg_show_stack_sizes) {
							hlinepos.Y += ITEM_SEP_STACKSIZES_Y;
						} else {
							hlinepos.Y += 2;
						}
					
						src = new Rectangle?(new Rectangle(0, 0, hlineTexture.Width, hlineTexture.Height));
						batch.Draw( hlineTexture, hlinepos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
					}
					
					// check if mouse is hovering
					if( canclick && MouseInsideRect( pos, t.Width, t.Height)) {
						//BeginClick();
						str = allrecipes[i].requiredItem[j].name;
						if(str != null && str != string.Empty) {
							hoveritem = (Item)allrecipes[i].requiredItem[j].Clone();
							if( Main.mouseLeft && Main.mouseLeftRelease) {
								HandleItemClick(true);
							} else if( spawndelay == 0 && Main.mouseRight && !Main.mouseRightRelease) {
								HandleItemClick(false);
								spawndelay = ITEM_SPAWN_INTERVAL;
							}
						}
					}
					
					pos.X += t.Width + ITEM_SEP_X;
				}
				
				pos.Y += hh + ITEM_SEP_Y;
				if(cfg_show_stack_sizes) {
					pos.Y +=  ITEM_SEP_STACKSIZES_Y;
				}
				
				pos.X = guipos.X + 46;
			}
		}
				
	// draw search box
		if(guisearch) {
			src = new Rectangle?(new Rectangle(0, 0, searchTexture.Width, searchTexture.Height));
			batch.Draw( searchTexture, searchpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			// check for highlight
			if(canclick && MouseInsideRect( searchpos, searchTexture.Width, searchTexture.Height)) {
				src = new Rectangle?(new Rectangle(0, 0, searchTextureHL.Width, searchTextureHL.Height));
				batch.Draw( searchTextureHL, searchpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
				// check for click
				if(Main.mouseLeft && Main.mouseLeftRelease) {
					// activate search box
					ResetClick();
					SelectSearchFilter();
					Main.keyCount = 0;
				} else if(Main.mouseRight && Main.mouseRightRelease) {
					// clear search box
					ResetClick();
					ResetSearchFilter();
					DeSelectSearchFilter();
					Main.keyCount = 0;	
				}
			}
			if(searchactive) {
				src = new Rectangle?(new Rectangle(0, 0, searchTextureON.Width, searchTextureON.Height));
				batch.Draw( searchTextureON, searchpos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
			}
			pos = searchpos;
			pos.X += 7;
			pos.Y += 5;
			// handle text input when active
			if(searchactive) {
				Main.editSign = searchactive;
				bool oldfocus = Main.hasFocus;
				Main.hasFocus = true;
			
					searchtext = Main.GetInputText(searchtext);
					if( searchtext != null && searchtext.Length > SEARCH_FIELD_CAP) {
						searchtext = searchtext.Substring( 0,SEARCH_FIELD_CAP);
					}
					if( Main.inputTextEnter) {
						SetSearchFilter(searchtext);
						if(cfg_deselect_search_on_enter) {
							DeSelectSearchFilter();
							Main.keyCount = 0;
						}						
					} else if( cfg_live_search_refresh && searchdelay == 0) {
						SetSearchFilter(searchtext);
						searchdelay = SEARCH_INTERVAL;
					}
					
				Main.hasFocus = oldfocus;
			}
			if(searchtext != null) {
				DrawString2( batch, Main.fontItemStack, searchtext, pos, Color.White);
			}
		}


		
	// draw mod filters menu
		if(guifilters) {
			pos = menupos;
			src = new Rectangle?(new Rectangle(0, 0, filterbtnTexture.Width, filterbtnTexture.Height));
			for( int i=0; i<filterinclude.Length; i++) {				
				if(filterinclude[i]) {
					batch.Draw( filterbtnTextureON, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
				} else {
					batch.Draw( filterbtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
				}				
				// check for highlight
				if(MouseInsideRect( pos, filterbtnTexture.Width, filterbtnTexture.Height)) {
					src = new Rectangle?(new Rectangle(0, 0, filterbtnTextureHL.Width, filterbtnTextureHL.Height));
					batch.Draw( filterbtnTextureHL, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
					// check for click
					if(Main.mouseLeft && Main.mouseLeftRelease) {
						ToggleFilterIndex(i);
						ResetClick();
					}
				}
				
				Vector2 tmp = pos + GetCenteredTextPos( Main.fontMouseText, filternames[i], filterbtnTexture);
				tmp.X = pos.X + 32;
				tmp.Y += 3;
				string n = filternames[i];
				if( n.Length > MOD_NAME_CAP) {
					n = n.Substring( 0, MOD_NAME_CAP - 1);
				}
				DrawString2( batch, Main.fontMouseText, n, tmp, Color.White);
				
				pos.Y += filterbtnTexture.Height;
			}
		}
				
	// draw type filters menu
		if(guitypes) {
			pos = typemenupos;
			src = new Rectangle?(new Rectangle(0, 0, typesbtnTexture.Width, typesbtnTexture.Height));
			for( int i=0; i<typeinclude.Length; i++) {				
				if(typeinclude[i]) {
					batch.Draw( typesbtnTextureON, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
				} else {
					batch.Draw( typesbtnTexture, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);	
				}
				// check for highlight
				if(MouseInsideRect( pos, typesbtnTexture.Width, typesbtnTexture.Height)) {
					src = new Rectangle?(new Rectangle(0, 0, typesbtnTextureHL.Width, typesbtnTextureHL.Height));
					batch.Draw( typesbtnTextureHL, pos, src, solid, 0f, origin, 1f, SpriteEffects.None, 0f);
					// check for click
					if(Main.mouseLeft && Main.mouseLeftRelease) {
						ToggleTypeFilterIndex(i);
						ResetClick();
					}
				}
				
				Vector2 tmp = pos + GetCenteredTextPos( Main.fontMouseText, typenames[i], typesbtnTexture);
				tmp.X = pos.X + 32;
				tmp.Y += 3;
				DrawString2( batch, Main.fontMouseText, typenames[i], tmp, Color.White);
				
				pos.Y += typesbtnTexture.Height;
			}
		}
		
		// detect clicks on the main form
		if(!hasclicked && ((Main.mouseLeft && Main.mouseLeftRelease) || (Main.mouseRight && Main.mouseRightRelease))) {
			ResetClick();	
		}
	}
					
// draw recipe book slot
	if(cfg_show_item_slot && Main.playerInventory) {
		string wtf = string.Empty;
		itemslot.Draw(ref wtf);
	}
}

private static Item delayedfilteritem;
	
public static void HandleItemClick( bool reset) {	
	bool shift = Main.keyState.IsKeyDown(ModGeneric.FilterKey) || Main.keyState.IsKeyDown(ModGeneric.FilterKey2);
	bool spawn = cfg_shift_to_spawn_items ? shift : !shift;
	if(!spawn) {
		//SetFilterItem(hoveritem);
		delayedfilteritem = hoveritem;
	} else {
		CheckCheatMode();
		if( hoverrecipe != -1) {
			HandleRecipeCrafting( Main.player[Main.myPlayer], allrecipes[hoverrecipe]);
		} else if(hoveritem != null) {
			HandleItemCrafting( Main.player[Main.myPlayer], hoveritem);
		}
	}
	if(reset) ResetClick();
}
					
public static void PostDraw( SpriteBatch batch) {

// draw mouse tooltip
	if(simpleMouseText != null) {
		Config.mainInstance.MouseText(simpleMouseText);
	}
	
	if(!guidisplay) return;

	if((guifilters &&  MouseInsideRect(menurect))
		|| (guitypes &&  MouseInsideRect(typerect)) 
		) {
		return;
	}

	// draw item hover tooltip
	if(hoveritem != null) {
		Main.toolTip = (Item)hoveritem.Clone();
		Config.mainInstance.MouseText(Main.toolTip.name, Main.toolTip.rare, 0);
	
		// generate string of all required crafting stations if needed
		if(cfg_show_crafting_stations && hoverrecipe != -1) {			
			string str = string.Empty;
			for( int i = 0; i < allrecipes[hoverrecipe].requiredTile.Length; i++) {
				int j = allrecipes[hoverrecipe].requiredTile[i];
				if( j < 0 || j >= Main.tileName.GetSize()) continue;
				string n = Main.tileName[j];
				if(n == null || n == string.Empty) continue;
				if( i > 0) {
					if( i == allrecipes[hoverrecipe].requiredTile.Length - 1) {
						str += " and ";
					} else {
						str += ", ";
					}
				}
				str += n;
			}
			// draw the tooltip
			if(str != null && str != string.Empty) {
				Vector2 pos = GetMousePos();
				pos.X += 10;
				pos.Y -= 18;
				DrawString( batch, Main.fontCombatText[0], "Crafted at " + str, pos, solid);
			}
		}
	}
}

	