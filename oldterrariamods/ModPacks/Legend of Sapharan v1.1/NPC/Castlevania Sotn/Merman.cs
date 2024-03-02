public const int caveSpawn = 150;

public static bool SpawnNPC(int x, int y, int playerID) {

      if (!Main.player[playerID].zoneDungeon //not in dungeon
          && !Main.player[playerID].zoneJungle  //not in jungle
          && ( Main.player[playerID].position.X < ((Main.worldSurface * 20.0)) //left edge of map
				|| Main.player[playerID].position.X > ((Main.worldSurface * 180.0)) )//right edge          
          && Main.player[playerID].position.Y < ((Main.rockLayer * 15.0))// surface-ish
          && Main.rand.Next(5)==1){ //spawn chance
                 return true;
      }else if(Main.player[playerID].position.Y < Main.rockLayer * 38.0 //caves
		&& Main.player[playerID].position.Y > Main.rockLayer * 16.0
		&& !Main.player[playerID].zoneHoly
		&& Main.rand.Next(caveSpawn) == 1){
			return true;
	}
	  return false;
}

/*
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Merman Head Gore",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Merman One Leg Gore",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Merman One Leg Gore",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Merman One Arm Gore",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Merman One Arm Gore",1.2f,-1);
}
*/