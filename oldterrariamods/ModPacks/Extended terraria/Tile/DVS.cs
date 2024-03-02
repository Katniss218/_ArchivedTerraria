public void MouseOverTile(int x,int y,Player P)
{
	P.noThrow = 2;
	P.showItemIcon = true;
	P.showItemIcon2 = Config.itemDefs.byName["Devil's Scythe"].type;
} 