	
/*
 * recipe crafting
 */

public static bool IsNearTiles( Player p, int[] tiles) {
	int count = 0;
	for( int i=0; i<tiles.Length; i++) {
		int t = tiles[i];
		if(t == -1 || p.adjTile[t]) count++;
	}
	return count == tiles.Length;
}

public static bool IsNearTile( Player p, int t) {
	if(t == -1) return false;
	return p.adjTile[t];
}

public static int FindItemSlot( Player p, Item item, bool checkstack = false) {
	for( int i=0; i<p.inventory.Length; i++) {
		if(item.IsTheSameAs(p.inventory[i])) {
			if(checkstack && p.inventory[i].stack < item.stack) continue;
			return i;
		}
	}
	return -1;
}

private static Recipe FindItemRecipe( Item item) {
	foreach( Recipe r in allrecipes) {
		if( r.createItem.IsTheSameAs(item)) return r;
	}
	return null;
}

public static bool CanCraftRecipe( Player p, Recipe r) {
	for( int i=0; i<r.requiredItem.Length; i++) {
		int need = r.requiredItem[i].stack;
		int have = 0;
		for( int j=0; j<p.inventory.Length; j++) {
			if(r.requiredItem[i].IsTheSameAs(p.inventory[j])) {
				if( p.inventory[j].stack <= need) {
					have += p.inventory[j].stack;
					need -=  p.inventory[j].stack;
				} else {
					need = 0;
					have = r.requiredItem[i].stack;
				}
				if(need <= 0) break;
			}
		}
		if(have != r.requiredItem[i].stack) return false;
	}
	return true;
}

public static Item CraftRecipe( Player p, Recipe r, bool eatsitems = false) {
	if(eatsitems) {
		for( int i=0; i<r.requiredItem.Length; i++) {
			int need = r.requiredItem[i].stack;
			int have = 0;
			for( int j=0; j<p.inventory.Length; j++) {
				if(r.requiredItem[i].IsTheSameAs(p.inventory[j])) {
					if( p.inventory[j].stack <= need) {
						// eat the whole slot
						have += p.inventory[j].stack;
						need -=  p.inventory[j].stack;
						p.inventory[j] = new Item();
					} else {
						// just eat a what we need
						p.inventory[j].stack -= need;
						need = 0;
						have = r.requiredItem[i].stack;
					}
					if(need <= 0) break;
				}
			}
			if(have != r.requiredItem[i].stack) return null;
		}
	}
	return (Item)r.createItem.Clone();
}
		
public static int FillItemStack( Item stack, Item item) {
	if(stack.maxStack == 1) {
		if(stack.stack == 0 && item.stack == 1) {
			stack.stack = 1;
			item.stack = 0;
			return 0;
		}
	}
	if( stack.stack >= stack.maxStack) return item.stack;
	int sz = stack.stack + item.stack;
	if( sz <= stack.maxStack) {
		stack.stack = sz;
		item.stack -= sz;
		return 0;
	}
	
	stack.stack = stack.maxStack;
	item.stack = sz - stack.maxStack;
	return item.stack;
}
	
public static void DropItem( Player p, Item item, int x, int y) {
	int id = Item.NewItem( x, y, p.width, p.height, item, false);
	Main.item[id].velocity.Y = -2f;
	Main.item[id].velocity.X = 4f * (float)p.direction + p.velocity.X;	
	if(Main.netMode == 0) {
		Main.item[id].noGrabDelay = 100;
	}
	if(Main.netMode == 1) {
		NetMessage.SendData( 21, -1, -1, "", id, 0f, 0f, 0f, 0);
	}
}
	
private static bool ShouleDropHeldItem( Item replace) {
	if( !Main.mouseItem.IsBlankItem()) {
		if( Main.mouseItem.IsTheSameAs(replace)) {
			if( Main.mouseItem.maxStack == 1 && Main.mouseItem.stack == 1) {
				return cfg_drop_items_before_spawning;
			} else if( Main.mouseItem.stack == Main.mouseItem.maxStack) {
				return cfg_drop_maxed_stacks;
			}
		} else {
			return cfg_drop_items_before_spawning;
		}
	}
	return false;
}
	
public static void HandleRecipeCrafting( Player p, Recipe r) {
	if(!cfg_can_spawn_items) return;
	
	if(r == null) return;
	
	if(cfg_needs_crafting_stations &&  r.requiredTile.Length > 0 ) {
		UpdateAdjTiles( p, false);
		if(!IsNearTiles( p, r.requiredTile)) {
			if(cfg_show_spawn_messages) Main.NewText( "The Recipe Book isnt close enough to the required crafting stations", 6);
			return;
		}
	}
	
	Item item = null;
	

	if( ShouleDropHeldItem( r.createItem)) {
		DropItem( p, Main.mouseItem, (int)p.position.X, (int)p.position.Y);
		Main.mouseItem = new Item();
	} else if( Main.mouseItem.IsTheSameAs(r.createItem) && Main.mouseItem.stack == Main.mouseItem.maxStack) {
		// maxed out, or holding something else. do nothing
		return;
	}
	
	if(cfg_free_item_crafting) {
		item = CraftRecipe( p, r);
	} else if(CanCraftRecipe( p, r)) {
		item = CraftRecipe( p, r, true);
	}
	
	if(item != null) {
		if(cfg_show_spawn_messages) Main.NewText( "The Recipe Book crafted the " + item.name, 1);
		HandleSpawnedItem( p, item);
	} else {
		if(cfg_show_spawn_messages) Main.NewText( "The Recipe Book doesnt have enough materials to craft the " + r.createItem.name, 6);
	}
}
	
public static void HandleItemCrafting( Player p, Item item) {
	if(!cfg_can_spawn_items) return;
	if(!cfg_can_spawn_any_item) return;
		
	if(item == null) return;
	
	Recipe r = FindItemRecipe(item);
	if(r != null) {
		HandleRecipeCrafting( p, r);
		return;
	} 
	
	if( ShouleDropHeldItem(item)) {
		DropItem( p, Main.mouseItem, (int)p.position.X, (int)p.position.Y);
		Main.mouseItem = new Item();
	} else if( Main.mouseItem.IsTheSameAs(item) && Main.mouseItem.stack == Main.mouseItem.maxStack) {
		// maxed out, or holding something else. do nothing
		return;
	}
	
	// no recipe, just clone it
	Item newitem = (Item)item.Clone();
	if(cfg_show_spawn_messages) Main.NewText( "The Recipe Book spawned the " + item.name, 1);
	HandleSpawnedItem( p, item);
}

public static void HandleSpawnedItem( Player p, Item item) {
	if(item == null) return;
	if( Main.mouseItem != null && !Main.mouseItem.IsBlankItem()) {
		if( Main.mouseItem.IsTheSameAs(item) && Main.mouseItem.maxStack > 1 && Main.mouseItem.stack < Main.mouseItem.maxStack) {
			// fill the stack in hand
			int leftover = FillItemStack( Main.mouseItem, item);
			if(cfg_drop_maxed_stacks) {
				while( leftover > 0) {
					DropItem( p, Main.mouseItem, (int)p.position.X, (int)p.position.Y);
					Main.mouseItem = new Item();
					Main.mouseItem.SetDefaults( item.name);
					leftover = FillItemStack( Main.mouseItem, item);
				}
			}
		} else if(cfg_drop_items_before_spawning) {
			// drop the item and hold the new item
			DropItem( p, Main.mouseItem, (int)p.position.X, (int)p.position.Y);
			Main.mouseItem = item;
		}
	} else {
		// hold the crafted item
		Main.mouseItem = item;
	}
	Main.PlaySound( 7, -1, -1, -1);
}