
 // hackish way of stopping endless loops with OnRecipeRefresh() and RebuildFilterRecipes() calling FindRecipes() .....
public static bool inside_findrecipes = false;

private static void ListAddQ( List<Recipe> l, Recipe r) {
	if(!l.Contains(r)) l.Add(r);
}

public static void EnumRecipes() {
	Dictionary<string, string> items = Config.itemDefs.modName;	
	
	List<string> list = new List<string>();	
	list.Add("Vanilla");
	
	filterrecipes = new Dictionary<string, List<Recipe>>();
	filterrecipes.Add( "Vanilla", new List<Recipe>());
	foreach( string name in Config.mods) {
		// include only mods that have items
		if(items.ContainsValue(name)) {
			list.Add(name);
			filterrecipes.Add( name, new List<Recipe>());
		}
	}
	
	// populate the filter menu
	filternames = new string[list.Count];
	filterinclude = new bool[list.Count];
	for( int i=0; i<filterinclude.Length; i++) {
		filternames[i] = list[i];
		filterinclude[i] = true;
	}

	// initialize type filter list
	typerecipes = new Dictionary<string, List<Recipe>>();
	for( int i=0; i<typeinclude.Length; i++) {
		typerecipes.Add( typenames[i], new List<Recipe>());
	}
	
	// get recipes for mod items
	for( int i=0; i<Main.recipe.Length; i++) {
		Recipe res = Main.recipe[i];
		Item item = res.createItem;		
		string mod = GetItemModpack(item);
		if(mod == "") {
			ListAddQ( filterrecipes["Vanilla"], res);
		} else if(filterrecipes.ContainsKey(mod)) {
			ListAddQ( filterrecipes[mod], res);
		}
		
		// add the recipe to the various type categories

		bool added = false;
		
		if(item.accessory) { added = true; ListAddQ( typerecipes["Accessory"], res); }
		if(item.ammo > 0) { added = true; ListAddQ( typerecipes["Ammo"], res); }
		if(item.potion || (item.consumable && item.buffType > 0) || item.healMana > 0 || item.healLife > 0) { added = true; ListAddQ( typerecipes["Consumable"], res); }
		if(item.headSlot > 0) { added = true; ListAddQ( typerecipes["Head"], res); }
		if(item.legSlot > 0) { added = true; ListAddQ( typerecipes["Legs"], res);  }
		if(item.magic || item.mana > 0) { added = true; ListAddQ( typerecipes["Magic"], res);  }
		if(item.material) { added = true; ListAddQ( typerecipes["Material"], res);  }
		if(item.melee) { added = true; ListAddQ( typerecipes["Melee"], res);  }
		if(item.ranged && item.ammo <= 0) { added = true; ListAddQ( typerecipes["Ranged"], res);  }
		if(item.createTile >= 0) { added = true; ListAddQ( typerecipes["Tile"], res);  }
		if(item.bodySlot > 0) { added = true; ListAddQ( typerecipes["Torso"], res);  }
		if(item.vanity) { added = true; ListAddQ( typerecipes["Vanity"], res);  }
		if(item.createWall > 0) { added = true; ListAddQ( typerecipes["Wall"], res);  }
			
		if(!added) {
			ListAddQ( typerecipes["Other"], res);
		}
	}

	RebuildFilterRecipes();
}

public static void UpdateAdjTiles( Player p, bool dorecipes = false) {
	if(inside_initialize) return;
	bool oldinv = Main.playerInventory;
	inside_findrecipes = true;
	Main.playerInventory = dorecipes;

	p.AdjTiles();

	inside_findrecipes = false;
	Main.playerInventory = oldinv;
}	

public static bool IsRecipeAvail( Recipe r) {
	for( int i=0; i<Main.numAvailableRecipes; i++) {
		int rid = Main.availableRecipe[i];
		if( rid < 0 || rid >= Main.recipe.Length) continue;
		if( r == Main.recipe[rid]) return true;
	}
	return false;
}

public static void RebuildFilterRecipes( bool norefresh = false) {
	allrecipes = new List<Recipe>();
		
	CheckCheatMode();
		
	// add all recipes from selected mod filters
	for( int i=0; i<filterinclude.Length; i++) {
		if(!filterinclude[i]) continue;
		if(availmode) {
			if(!cfg_needs_crafting_stations) {
				foreach( Recipe r in filterrecipes[filternames[i]]) {
					if( CanCraftRecipe( Main.player[Main.myPlayer], r)) {
						ListAddQ( allrecipes, r);
					}
				}				
			} else {
				// refresh the available list if needed
				if(!norefresh) {
					UpdateAdjTiles( Main.player[Main.myPlayer], true);
				}
				if( Main.numAvailableRecipes == 0) {
					//TODO: figure out if this is correct
					// cant find any recipes... list those not requing any crafting stations
					foreach( Recipe r in filterrecipes[filternames[i]]) {
						int count = 0;
						for( int k=0; k<r.requiredTile.Length; k++) {						
							if( r.requiredTile[k] == -1) count++;
						}
						if( count == r.requiredTile.Length) {
							ListAddQ( allrecipes, r);
						}
					}
				} else {
					// only add available recipes
					foreach( Recipe r in filterrecipes[filternames[i]]) {
						if( IsRecipeAvail(r)) {
							ListAddQ( allrecipes, r);
						}
					}
				}	
			}
		} else {
			// normal mod filter
			foreach( Recipe r in filterrecipes[filternames[i]]) {
				ListAddQ( allrecipes, r);
			}
		}
	}
		
	// get a list of recipes from selected type filters
	List<Recipe> list = new List<Recipe>();
	for( int i=0; i<typeinclude.Length; i++) {
		if(!typeinclude[i]) continue;
		foreach( Recipe r in typerecipes[typenames[i]]) {
			// only add them to the list if already selected by mods
			if(allrecipes.Contains(r)) {
				ListAddQ( list, r);
			}
		}
	}
		
	// filter out  recipes not requiring selected filter item	
	if(filteritem != null) {
		List<Recipe> list2 = new List<Recipe>();
		foreach( Recipe r  in list) {
			for( int i = 0; i < r.requiredItem.Length; i++) {
				if( r.requiredItem[i].IsTheSameAs(filteritem)) {
					ListAddQ( list2, r);
				}
			}
		}
		list = list2;
	}
	
	// filter out recipes not matching search filter
	if(oldsearchtext != null) {
		string s = oldsearchtext.Trim().ToLower();		
		if(s != null && s != string.Empty) {
			List<Recipe> list2 = new List<Recipe>();
			foreach( Recipe r  in list) {
				if( r.createItem.name == null || r.createItem.name == string.Empty) continue;
				string n = r.createItem.AffixName().ToLower();
				if( n.IndexOf(s) >= 0) {
					ListAddQ( list2, r);
				}
			}
			list = list2;
		}
	}
	
	// our final list of recipes
	allrecipes = list;
}

public static string GetItemModpack(Item item) {
	if(item == null || item.name == null || item.name == string.Empty) return "";
	if (Config.itemDefs.modName.ContainsKey(item.name)) return Config.itemDefs.modName[item.name];
	return "";
}
