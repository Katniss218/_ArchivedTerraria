float customspawn1 = 0f;
//Spawns on the Surface in the Desert.

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
    if(!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Caravan Tent"].type)) return false;
    int c1 = (int)Main.tile[x, y -1].type;
    int c2 = (int)Main.tile[x, y].type;
    int c3 = (int)Main.tile[x, y +1].type;
    if ((c1 == 53 || c2 == 53 || c3 == 53) && oSurface)
    {
        if (!Main.hardMode) 
            if (Main.rand.Next(200)==1) 
                return true;
        else 
            if (Main.rand.Next(50)==1) 
                return true;
    }
    return false;
}
#endregion 

#region AI
public void AI() 
{
    if(Main.netMode == 1) return; //SHOULD ONLY SPAWN SERVER SIDE
    if (customspawn1 < 1) 
    {
        if (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Caravan Merchant"].type))
        {
            int Spawned = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Omnirs Caravan Merchant", 0);
            customspawn1 += 1f;
            Main.NewText("A merchant has set up camp.", 175, 75, 255);
        }
    }
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