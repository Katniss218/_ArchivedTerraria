
/*
 * mod settings api
 */
 
public static int GetSettingCount()
{
	return 27;
}

public static string GetSettingName(int setting)
{
	switch (setting)
	{
		case 0:			return "Enabled";
		case 1:			return "Pause Game";
		case 2:			return "Close Player Inventory";
		case 3:			return "Allow Spawning Items";
		case 4:			return "Show Item Amounts";
		case 5:			return "Horizontal Seperator";
		case 6:			return "Vertical Seperator";
		case 7:			return "Shift Spawns Items";
		case 8:			return "Max History Count";
		case 9:			return "Show Book Icon";
		case 10:			return "Show Item Slot";
		case 11:			return "Large Gui Mode";
		case 12:			return "Needs Craftion Stations";
		case 13:			return "Live Avaible Recipes";
		case 14:			return "Color Missing Items";
		case 15:			return "Free Item Crafting";
		case 16:			return "Can Spawn Any item";
		case 17:			return "Close With Inventory";
		case 18:			return "Sync With Inventory";
		case 19:			return "Show Spawn Messages";
		case 20:			return "Hide Original Recipes";
		case 21:			return "Need Book To Open";
		case 22:			return "Live Search Refresh";
		case 23:			return "Deselect Search On Enter";
		case 24:			return "Drop Before Spawning";
		case 25:			return "Drop Maxed Stacks";
		case 26:			return "Show Crafting Stations";
		default:
			return null;
	}
}

public static object GetSettingValue(int setting)
{
	switch (setting)
	{
		case 0:			return cfg_enabled;
		case 1:			return cfg_pause_game;
		case 2:			return cfg_close_player_inv;
		case 3:			return cfg_can_spawn_items;
		case 4:			return cfg_show_stack_sizes;
		case 5:			return cfg_draw_hline;
		case 6:			return cfg_draw_vline;
		case 7:			return cfg_shift_to_spawn_items;
		case 8:			return cfg_max_history_count;
		case 9:			return cfg_show_book_icon;
		case 10:			return cfg_show_item_slot;
		case 11:			return cfg_large_gui_mode;
		case 12:			return cfg_needs_crafting_stations;
		case 13:			return cfg_live_avail_refresh;
		case 14:			return cfg_show_missing_colors;
		case 15:			return cfg_free_item_crafting;
		case 16:			return cfg_can_spawn_any_item;
		case 17:			return cfg_close_book_on_inv_close;
		case 18:			return cfg_sync_with_inv;
		case 19:			return cfg_show_spawn_messages;
		case 20:			return cfg_hide_orig_recipes;
		case 21:			return cfg_need_book_to_open;
		case 22:			return cfg_live_search_refresh;
		case 23:			return cfg_deselect_search_on_enter;
		case 24:			return cfg_drop_items_before_spawning;
		case 25:			return cfg_drop_maxed_stacks;
		case 26:			return cfg_show_crafting_stations;
		default:			return null;
	}
}

public static object SetSettingValue(int setting, object value)
{
	switch (setting)
	{
		case 0:			return cfg_enabled = (bool)value;
		case 1:			return cfg_pause_game = (bool)value;
		case 2:			return cfg_close_player_inv = (bool)value;
		case 3:			return cfg_can_spawn_items = (bool)value;
		case 4:			return cfg_show_stack_sizes = (bool)value;
		case 5:			return cfg_draw_hline = (bool)value;
		case 6:			return cfg_draw_vline = (bool)value;
		case 7:			return cfg_shift_to_spawn_items = (bool)value;
		case 8:
			int i = (int)value;
			if(i <= 0) {
				i = 1;
			} else if( i > 128) {
				i = 128;
			}
			return cfg_max_history_count = i;
		case 9:			return cfg_show_book_icon = (bool)value;
		case 10:			return cfg_show_item_slot = (bool)value;
		case 11:			return cfg_large_gui_mode = (bool)value;
		case 12:			return cfg_needs_crafting_stations = (bool)value;
		case 13:			return cfg_live_avail_refresh = (bool)value;
		case 14:			return cfg_show_missing_colors = (bool)value;
		case 15:			return cfg_free_item_crafting = (bool)value;
		case 16:			return cfg_can_spawn_any_item = (bool)value;
		case 17:			return cfg_close_book_on_inv_close = (bool)value;
		case 18:			return cfg_sync_with_inv = (bool)value;
		case 19:			return cfg_show_spawn_messages = (bool)value;
		case 20:			return cfg_hide_orig_recipes = (bool)value;
		case 21:			return cfg_need_book_to_open = (bool)value;
		case 22:			return cfg_live_search_refresh = (bool)value;
		case 23:			return cfg_deselect_search_on_enter = (bool)value;
		case 24:			return cfg_drop_items_before_spawning = (bool)value;
		case 25:			return cfg_drop_maxed_stacks = (bool)value;
		case 26:			return cfg_show_crafting_stations = (bool)value;
		default:			return null;
	}
}



/*
 * mod settings saving & loading
 */
enum SettingType {
	BoolFalse, BoolTrue, Int, Enum
};

private static object get_setting_byname( string name) {
	int sz = ModWorld.GetSettingCount();	
	for( int i=0; i<sz; i++) {
		if( ModWorld.GetSettingName(i) == name) {
			return ModWorld.GetSettingValue(i);
		}
	}
	return null;
}
		
private static void set_setting_byname( string name, object value) {
	int sz = ModWorld.GetSettingCount();	
	for( int i=0; i<sz; i++) {
		if( ModWorld.GetSettingName(i) == name) {
			ModWorld.SetSettingValue( i, value);
			return;
		}
	}
}
		
public static void WriteSettings( BinaryWriter bw) {
	int sz = ModWorld.GetSettingCount();
	bw.Write(sz);
	for( int i=0; i<sz; i++) {		
		object value = ModWorld.GetSettingValue(i);
		if( value is bool) {
			bw.Write( ModWorld.GetSettingName(i));
			if((bool)value) {
				bw.Write( (byte)SettingType.BoolTrue);
			} else {
				bw.Write( (byte)SettingType.BoolFalse);
			}
		} else if( value is int) {
			bw.Write( ModWorld.GetSettingName(i));
			bw.Write( (byte)SettingType.Int);
			bw.Write( (int)value);
		} else if( value != null && value.GetType().IsEnum) {
			bw.Write( ModWorld.GetSettingName(i));
			bw.Write( (byte)SettingType.Enum);			
			bw.Write( Enum.Format( value.GetType(), value, "G"));
		}
	}
}
		
public static void ReadSettings( BinaryReader br) {
	int sz = br.ReadInt32();
	for( int i=0; i<sz; i++) {
		string name = br.ReadString();
		switch((SettingType)br.ReadByte()) {
			case SettingType.BoolFalse:	set_setting_byname( name, false); break;
			case SettingType.BoolTrue:		set_setting_byname( name, true); break;
			case SettingType.Int:				set_setting_byname( name, br.ReadInt32()); break;
			case SettingType.Enum:
				object val = get_setting_byname(name);
				string nval = br.ReadString();
				if( val != null && val.GetType().IsEnum) {
					set_setting_byname( name, Enum.Parse( val.GetType(), nval));
				}
				 break;
		}
	}
}


