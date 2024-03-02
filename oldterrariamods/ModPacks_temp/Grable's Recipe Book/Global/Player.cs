
public void Save(BinaryWriter bw) {
	if (Main.creatingChar) {
		WriteItem( bw, null);
	} else {
		WriteItem( bw, ModWorld.GetSlotItem());
	}
	ModWorld.WriteSettings(bw);
}

public void Load(BinaryReader br, int version) {
	switch(version) {
		case 1:
			ModWorld.SetLoadedFilterItem( ReadItem(br));
			ModWorld.ReadSettings(br);
			break;
	}
}


public static void WriteItem( BinaryWriter bw, Item item) {
	if (item == null) item = new Item();
	bw.Write(item.type != 0);
	if (item.type != 0) {
		bw.Write(item.name);
		bw.Write((byte)item.stack);
		bw.Write((byte)item.prefix);
		Prefix.SavePrefix(bw,item);
		Codable.SaveCustomData(item,bw);
	}
}

public static Item ReadItem( BinaryReader br) {
	Item item = new Item();
	try {
		if (!br.ReadBoolean()) return item;
		item.SetDefaults(br.ReadString());
		item.stack = (int)br.ReadByte();
		item.Prefix((int)br.ReadByte());
		Prefix.LoadPrefix(br,item,"player");
		Codable.LoadCustomData(item,br,5,true);
		return item;
	} catch (Exception) {
		return new Item();
	}
}

