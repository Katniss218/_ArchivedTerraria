#region Spawn
public bool SpawnNPC(int x,int y,int PID)
{
      Player P = Main.player[PID]; //this shortens our code up from writing this line over and over.
      
      bool Sky = P.position.Y <= (Main.rockLayer * 4);
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

        if(Meteor && !Main.dayTime && AboveEarth && Main.rand.Next(25)==1) return true;

	if(Meteor && !Main.dayTime && InBrownLayer && Main.rand.Next(30)==1) return true;

	if(Meteor && !Main.dayTime && InGrayLayer && Main.rand.Next(25)==1) return true;


      return false;
}
#endregion





public void DamagePlayer(Player player, ref int damage) //hook works!	
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(36, 10800, false);
	}
}