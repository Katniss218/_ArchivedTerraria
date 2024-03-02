public static Item[] ArrayBlanker(int a){
	Item [] b = new Item[a];
	for (int i=0;i<a; i++) b[i] = new Item();
	return b;
}
public static Item[] bank3 = ArrayBlanker(40);
public static Item[] bank4 = ArrayBlanker(60);
public static Item[] bank5 = ArrayBlanker(80);
public static Item[] bank6 = ArrayBlanker(100);

public static void Initialize()
{
	//its a static variable , you want to reset it or otherwise it will pass between characters
	bank3 = ArrayBlanker(40);
	bank4 = ArrayBlanker(60);
	bank5 = ArrayBlanker(80);
	bank6 = ArrayBlanker(100);

}

public static void Save(BinaryWriter W)
{
	for(int i = 0; i < bank3.Length; i++){
		Item In = bank3[i];
		W.Write((int)In.netID);
		W.Write((byte)In.stack);
		W.Write((byte)In.prefix);
		Codable.SaveCustomData(In, W);
	}
	for(int i = 0; i < bank4.Length; i++){
		Item In = bank4[i];
		W.Write((int)In.netID);
		W.Write((byte)In.stack);
		W.Write((byte)In.prefix);
		Codable.SaveCustomData(In, W);
	}
	for(int i = 0; i < bank5.Length; i++){
		Item In = bank5[i];
		W.Write((int)In.netID);
		W.Write((byte)In.stack);
		W.Write((byte)In.prefix);
		Codable.SaveCustomData(In, W);
	}
	for(int i = 0; i < bank6.Length; i++){
		Item In = bank6[i];
		W.Write((int)In.netID);
		W.Write((byte)In.stack);
		W.Write((byte)In.prefix);
		Codable.SaveCustomData(In, W);
	}
}

public static void Load(BinaryReader R, int V)
{
	for(int i = 0; i < bank3.Length; i++){
		Item In = bank3[i];
		int netID = R.ReadInt32();
		In.netDefaults(netID);
		In.stack = R.ReadByte();
		In.Prefix((int)R.ReadByte());
		Codable.LoadCustomData(In, R, 5, true);
	}
	for(int i = 0; i < bank4.Length; i++){
		Item In = bank4[i];
		int netID = R.ReadInt32();
		In.netDefaults(netID);
		In.stack = R.ReadByte();
		In.Prefix((int)R.ReadByte());
		Codable.LoadCustomData(In, R, 5, true);
	}
	for(int i = 0; i < bank5.Length; i++){
		Item In = bank5[i];
		int netID = R.ReadInt32();
		In.netDefaults(netID);
		In.stack = R.ReadByte();
		In.Prefix((int)R.ReadByte());
		Codable.LoadCustomData(In, R, 5, true);
	}
	for(int i = 0; i < bank6.Length; i++){
		Item In = bank6[i];
		int netID = R.ReadInt32();
		In.netDefaults(netID);
		In.stack = R.ReadByte();
		In.Prefix((int)R.ReadByte());
		Codable.LoadCustomData(In, R, 5, true);
	}
}
