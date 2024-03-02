public void PlaceTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
    ModWorld.stationExists[0] = true;
    ModWorld.stationPosX[0] = x;
    ModWorld.stationPosY[0] = y-2;
    ModWorld.stationScore[0] = 0;
if(Main.netMode == 1)
return;
}
public bool CanDestroyTile(int x, int y) 
{
	return true;
}
static bool CanPlace(int x, int y)
{
    return !ModWorld.stationExists[0];
}
public void DestroyTile(int x, int y) 
{
    ModWorld.stationExists[0] = false;
    ModWorld.stationPosX[0] = -1;
    ModWorld.stationPosY[0] = -1;
    ModWorld.stationScore[0] = 0;
}


public void Update(int x,int y)
{
if(Main.netMode == 1)
return;
                        bool something = false;
                        foreach (NPC P in Main.npc)
                        {
                            if (P.active && P.type == Config.npcDefs.byName["Red Flag"].type)
	                        {
		                        something = true;
                                break;
	                        }
                        }
                        if (!something)
	                    {
                            int a = NPC.NewNPC(ModWorld.stationPosX[0]*16+20,ModWorld.stationPosY[0]*16 -15,"Red Flag",0);
	                    }
}