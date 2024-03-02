public void MouseOverTile(int x,int y,Player P)
{
	P.noThrow = 2;
	P.showItemIcon = true;
	P.showItemIcon2 = Config.itemDefs.byName["Illegal Weapon Instructions"].type;
}


/* int tx = 1;
int ty = 1;
public void Initialize(int x, int y)
{
	tx = x;
	ty = y;
}
public void MouseOverTile(int x, int y, Player P)
{
	P.noThrow = 2;
	P.showItemIcon = true;
	P.showItemIcon2 = Config.itemDefs.byName["Illegal Weapon Instructions"].type;
}
public void Update()
{
	if (!Main.tile[tx, ty - 1].active || Main.tile[tx, ty - 1] == null || !Main.tileSolidTop[Main.tile[tx, ty - 1].type])
	{
		WorldGen.KillTile(tx, ty);
	}
} */