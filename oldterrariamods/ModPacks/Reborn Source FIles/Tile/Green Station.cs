public void PlaceTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
    ModWorld.stationExists[1] = true;
    ModWorld.stationPosX[1] = x;
    ModWorld.stationPosY[1] = y-2;
    ModWorld.stationScore[1] = 0;
if(Main.netMode == 1)
return;
}
public bool CanDestroyTile(int x, int y) 
{
	return true;
}
static bool CanPlace(int x, int y)
{
    return !ModWorld.stationExists[1];
}
public void DestroyTile(int x, int y) 
{
    ModWorld.stationExists[1] = false;
    ModWorld.stationPosX[1] = -1;
    ModWorld.stationPosY[1] = -1;
    ModWorld.stationScore[1] = 0;
}


public void Update(int x,int y)
{
if(Main.netMode == 1)
return;
                        bool something = false;
                        foreach (NPC P in Main.npc)
                        {
                            if (P.active && P.type == Config.npcDefs.byName["Green Flag"].type)
	                        {
		                        something = true;
                                break;
	                        }
                        }
                        if (!something)
	                    {
                            int a = NPC.NewNPC(ModWorld.stationPosX[1]*16+20,ModWorld.stationPosY[1]*16 -15,"Green Flag",0);
	                    }
}