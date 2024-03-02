public int xc = 0;
public int yc = 0;
public void Initialize(int x, int y)
{
	xc = x;
	yc = y;
}

public void AddLight(int x, int y, ref float r, ref float g, ref float b)
{
	if (Main.netMode != 2)
	{
		if (Main.rand.Next(10) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f), 4, 4, 57, 1.6f, 1.6f, 30, new Color(), 1.8f);
			Main.dust[dust].noGravity = true;
		}
		if (Main.rand.Next(10) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f), 4, 4, 57, -1.6f, -1.6f, 30, new Color(), 1.8f);
			Main.dust[dust].noGravity = true;
		}
		if (Main.rand.Next(10) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f), 4, 4, 57, 1.6f, -1.6f, 30, new Color(), 1.8f);
			Main.dust[dust].noGravity = true;
		}
		if (Main.rand.Next(10) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f), 4, 4, 57, -1.6f, 1.6f, 30, new Color(), 1.8f);
			Main.dust[dust].noGravity = true;
		}
	}
}

public void Update()
{
    /*if (Main.rand.Next(10) == 0)
    {
    int dust = Dust.NewDust(
    new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f),                        //position
    4,                                                          //box width
    4,                                                          //box height
    57,                                                         //type
    1.6f,                                                         //X velocity
    1.6f,                                                         //Y velocity
    30,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
    }

    if (Main.rand.Next(10) == 0)
    {
    int dust2 = Dust.NewDust(
    new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f),                        //position
    4,                                                          //box width
    4,                                                          //box height
    57,                                                         //type
    -1.6f,                                                         //X velocity
    -1.6f,                                                         //Y velocity
    30,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust2].noGravity = true;
    }

    if (Main.rand.Next(10) == 0)
    {
    int dust3 = Dust.NewDust(
    new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f),                        //position
    4,                                                          //box width
    4,                                                          //box height
    57,                                                         //type
    -1.6f,                                                         //X velocity
    1.6f,                                                         //Y velocity
    30,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust3].noGravity = true;
    }

    if (Main.rand.Next(10) == 0)
    {
    int dust4 = Dust.NewDust(
    new Vector2((float) (xc * 16) + 20f, (float) (yc * 16) + 12f),                        //position
    4,                                                          //box width
    4,                                                          //box height
    57,                                                         //type
    1.6f,                                                         //X velocity
    -1.6f,                                                         //Y velocity
    30,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust4].noGravity = true;
    }*/
}
public bool CanDestroyAround(int x, int y, string Dir)
{
	if(Dir == "Bottom") return false;
	else return true;
}
public bool CanDestroyTile(int x, int y)
{
	if (!ModWorld.superHardmode)
	{
		return false;
	}
	else if (ModWorld.superHardmode && Player.tileTargetY == y + 1)
	{
		return false;
	}
	else return true;
}

public void KillTile(int x, int y, Player P)
{
	ModWorld.SmashHallowAltar(x, y);
	if (Main.rand.Next(10) == 0) ModWorld.dropComet();
	if (Main.rand.Next(50) == 0)
	{
		Item.NewItem((xc * 16), (yc * 16), 22, 18, 369, 1, false);
	}
	if (Main.rand.Next(75) == 0) Item.NewItem((xc * 16), (yc * 16), 16, 16, Config.itemDefs.byName["Hallowed Ore"].type, Main.rand.Next(2)+1, false);
	if (Main.rand.Next(75) == 0) Item.NewItem((xc * 16), (yc * 16), 16, 16, Config.itemDefs.byName["Corrupted Ore"].type, Main.rand.Next(2)+1, false);
}