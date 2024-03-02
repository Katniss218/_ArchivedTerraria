#region Spawn
//Spawns in the Cavern and Magma Cavern, before 2/10ths and after 8/10ths (Width), or in the Corruption. Does not spawn in the Dungeons, Meteor, or if there are more than 2 Town NPCs (Except on Blood Moons).
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (y < (Main.maxTilesY * 0.1f));
    bool oSurface = (y >= (Main.maxTilesY * 0.1f) && y < (Main.maxTilesY * 0.2f));
    bool oUnderSurface = (y >= (Main.maxTilesY * 0.2f) && y < (Main.maxTilesY * 0.3f));
    bool oUnderground = (y >= (Main.maxTilesY * 0.3f) && y < (Main.maxTilesY * 0.4f));
    bool oCavern = (y >= (Main.maxTilesY * 0.4f) && y < (Main.maxTilesY * 0.6f));
    bool oMagmaCavern = (y >= (Main.maxTilesY * 0.6f) && y < (Main.maxTilesY * 0.8f));
    bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
    if (Main.player[playerID].zoneDungeon || Main.player[playerID].zoneMeteor) return false;
	if (Main.player[playerID].townNPCs < 3f && (oCavern || oMagmaCavern))
    {
        if ((oCavern && x < Main.maxTilesX*0.2f || oCavern && x > Main.maxTilesX*0.8f) && Main.rand.Next(400)==1) return true;
        else if (Main.rand.Next(300)==1) return true;
    	return false;
    }
    else if (Main.player[playerID].zoneEvil && Main.rand.Next(200)==1) return true;
    else if (Main.bloodMoon && Main.rand.Next(200)==1) return true;
    return false;
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	{
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 43, 0, 0, 100, color, 2f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion