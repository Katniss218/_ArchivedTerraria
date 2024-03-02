void DealtPlayer(Player player, double damage, NPC npc)
{
	player.AddBuff(30, 36000, false); //slow down!
    return;
}

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) {

	if(Main.worldName == "Nightmare"){
      if (!Main.player[playerID].zoneDungeon 
          && !Main.player[playerID].zoneJungle  
          && !Main.player[playerID].zoneMeteor 
          && (Main.player[playerID].position.X < (Main.worldSurface * 10.0)
          || Main.player[playerID].position.X > (Main.worldSurface * 190.0))
          && Main.player[playerID].position.Y < (Main.rockLayer * 35.0)
          && Main.rand.Next(8)==1)
    { 
    return true;
}
return false;
}
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion