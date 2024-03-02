float customspawn1;
int oTStage=0;
//Spawns on the Surface, between 7/10th and 8.5/10th (Width). Spawns more in Hardmode.

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (y < (Main.maxTilesY * 0.1f));
    bool oSurface = (y >= (Main.maxTilesY * 0.1f) && y < (Main.maxTilesY * 0.2f));
    bool oUnderSurface = (y >= (Main.maxTilesY * 0.2f) && y < (Main.maxTilesY * 0.3f));
    bool oUnderground = (y >= (Main.maxTilesY * 0.3f) && y < (Main.maxTilesY * 0.4f));
    bool oCavern = (y >= (Main.maxTilesY * 0.4f) && y < (Main.maxTilesY * 0.6f));
    bool oMagmaCavern = (y >= (Main.maxTilesY * 0.6f) && y < (Main.maxTilesY * 0.8f));
    bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
    if (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Orshabaal's Tunnel"].type) || !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Orshabaal"].type) || !Main.hardMode || Main.player[playerID].zoneDungeon ) return false;
	if ((oSurface || oUnderSurface) && (x > Main.maxTilesX*0.70f && x < Main.maxTilesX*0.85f))
    {
        if (Main.player[playerID].townNPCs <= 0f && Main.rand.Next(500)==1) return true;
        else if (Main.hardMode && Main.player[playerID].townNPCs <= 0f && Main.rand.Next(200)==1) return true;
        return false;
    }
    return false;
}
#endregion

#region AI
public void AI() 
{
    if (customspawn1 < 1) 
    {
        if ((Main.rand.Next(50)==1) && (oTStage == 0))
        {
            Main.NewText("A tunnel appeared, and begins to widen.", 175, 75, 255);
            oTStage += 1;
        }
        if ((Main.rand.Next(500)==1) && (oTStage == 1))
        {
            Main.NewText("The demon lord Orshabaal begins to tear through the tunnel.", 175, 75, 255);
            oTStage +=1;
        }
        if ((Main.rand.Next(2000)==1) && (oTStage == 2) && (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Orshabaal"].type)))
	    {
		    int Spawned = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Omnirs Orshabaal", 0);
		    npc.ai[0] = 20-Main.rand.Next(80);
            customspawn1 += 1f;
            Main.NewText("The demon lord Orshabaal has come.", 175, 75, 255);
        }
    }
    return;
}
#endregion

#region Frames
public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (npc.velocity.X < 0)
	{
	    npc.spriteDirection = -1;
	}
	else
	{
	    npc.spriteDirection = 1;
	}
	npc.rotation = npc.velocity.X * 0.08f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 4.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
}
#endregion