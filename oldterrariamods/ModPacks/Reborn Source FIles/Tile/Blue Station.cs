public void PlaceTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
    ModWorld.stationExists[2] = true;
    ModWorld.stationPosX[2] = x;
    ModWorld.stationPosY[2] = y-2;
    ModWorld.stationScore[2] = 0;
if(Main.netMode == 1)
return;
}
public bool CanDestroyTile(int x, int y) 
{
	return true;
}
static bool CanPlace(int x, int y)
{
    return !ModWorld.stationExists[2];
}
public void DestroyTile(int x, int y) 
{
    ModWorld.stationExists[2] = false;
    ModWorld.stationPosX[2] = -1;
    ModWorld.stationPosY[2] = -1;
    ModWorld.stationScore[2] = 0;
}


public void Update(int x,int y)
{
if(Main.netMode == 1)
return;
                        bool something = false;
                        foreach (NPC P in Main.npc)
                        {
                            if (P.active && P.type == Config.npcDefs.byName["Blue Flag"].type)
	                        {
		                        something = true;
                                break;
	                        }
                        }
                        if (!something)
	                    {
                            int a = NPC.NewNPC(ModWorld.stationPosX[2]*16+20,ModWorld.stationPosY[2]*16 -15,"Blue Flag",0);
	                    }
}