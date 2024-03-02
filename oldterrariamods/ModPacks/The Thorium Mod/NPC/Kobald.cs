public bool SpawnNPC(int x,int y,int pid)
{
      if(!Biome.Biomes["Overworld"].TileValid(x,y,pid)) return false;
     
      if(Biome.Biomes["Snow"].TileValid(x,y,pid)) return false;
      if(Biome.Biomes["Desert"].TileValid(x,y,pid)) return false;
 
      return true;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Kobald Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Kobald Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Kobald Spear",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Kobald Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Kobald Leg",1f,-1);
}