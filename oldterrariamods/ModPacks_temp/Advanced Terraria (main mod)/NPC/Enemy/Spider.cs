public static bool SpawnNPC(int x, int y, int playerID) {

      if (!Main.player[playerID].zoneDungeon //not in dungeon. Note that the ! means "Not"
          && !Main.player[playerID].zoneJungle  //not in jungle
          && !Main.player[playerID].zoneMeteor //not in meteor
          && (Main.player[playerID].position.X > (Main.worldSurface * 10.0)//Spawns on the left edge of the map
          || Main.player[playerID].position.X < (Main.worldSurface * 190.0))
			&& Main.player[playerID].position.Y > ((Main.rockLayer * 20.0))
          && Main.player[playerID].position.Y < (Main.rockLayer * 35.0)// just above the underworld. The underworld ends at *42~
          && Main.rand.Next(6)==1){ //1 out of 8 chance of spawning
                 return true;
      }
   return false;
}