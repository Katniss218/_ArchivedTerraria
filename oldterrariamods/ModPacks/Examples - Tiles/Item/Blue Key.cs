int keyX=0;
int keyY=0; //The x,y coordinates are the values checked to open the chest
public void SetKey(int x, int y) {
	keyX=x;
	keyY=y;
	this.item.toolTip2="Matches chest at "+(keyX*16)+","+(keyY*16);
}
public Vector2 GetKey() {
	return new Vector2((float)keyX, (float)keyY);
}
public void Save(BinaryWriter writer) {
	writer.Write(keyX);
	writer.Write(keyY);
}
public void Load(BinaryReader reader) {
	keyX=reader.ReadInt32();
	keyY=reader.ReadInt32();
	this.item.toolTip2="Matches chest at "+(keyX*16)+","+(keyY*16);
}