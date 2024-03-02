public void PlaceTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
    ModWorld.stationExists[3] = true;
    ModWorld.stationPosX[3] = x;
    ModWorld.stationPosY[3] = y-2;
    ModWorld.stationScore[3] = 0;
if(Main.netMode == 1)
return;
}
public bool CanDestroyTile(int x, int y) 
{
	return true;
}
static bool CanPlace(int x, int y)
{
    return !ModWorld.stationExists[3];
}
public void DestroyTile(int x, int y) 
{
    ModWorld.stationExists[3] = false;
    ModWorld.stationPosX[3] = -1;
    ModWorld.stationPosY[3] = -1;
    ModWorld.stationScore[3] = 0;
}


public void Update(int x,int y)
{
if(Main.netMode == 1)
return;
                        bool something = false;
                        foreach (NPC P in Main.npc)
                        {
                            if (P.active && P.type == Config.npcDefs.byName["Yellow Flag"].type)
	                        {
		                        something = true;
                                break;
	                        }
                        }
                        if (!something)
	                    {
                            int a = NPC.NewNPC(ModWorld.stationPosX[3]*16+20,ModWorld.stationPosY[3]*16 - 15,"Yellow Flag",0);
	                    }
}