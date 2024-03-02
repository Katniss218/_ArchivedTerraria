
public void DestroyTile(int x, int y)
{
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["Plutar Throne"].type,1,false);
 
}
