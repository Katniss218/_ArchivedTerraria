#region Spawn
public bool SpawnNPC(int x,int y,int PID)
{
      Player P = Main.player[PID]; //this shortens our code up from writing this line over and over.
      bool Meteor = P.zoneMeteor;
      bool Jungle = P.zoneJungle;
      bool Dungeon = P.zoneDungeon;
      bool Corruption = P.zoneEvil;
      bool Hallow = P.zoneHoly;
      bool AboveEarth  = P.position.Y < Main.worldSurface;
      bool InBrownLayer = P.position.Y >= Main.worldSurface && P.position.Y < Main.rockLayer;
      bool InGrayLayer = P.position.Y >= Main.rockLayer && P.position.Y < (Main.maxTilesY - 200)*16;
      bool InHell = P.position.Y >= (Main.maxTilesY - 200)*16;
      bool Ocean = P.position.X < 3600 || P.position.X > (Main.maxTilesX-100)*16;

      // these are all the regular stuff you get , now lets see......

      if(Dungeon && ModWorld.superHardmode && Main.rand.Next(10)==1) return true;

	if(Corruption && ModWorld.superHardmode && !AboveEarth && Main.rand.Next(100)==1) return true;

	if(InHell && ModWorld.superHardmode && Main.rand.Next(30)==1) return true;


      return false;
}
#endregion

public void AI()
{
npc.AI(true);

float red  = 1.0f;
float green  = 0.0f;
float blue  = 1.0f;

Lighting.addLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), red, green, blue);

}

