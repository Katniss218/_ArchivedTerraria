//This is an original contribution to the Dark Souls mod, coded by Yoraizor

public void Initialize()
{
    if(ModWorld.Slayed.ContainsKey(npc.displayName)) npc.value = 0;
}


public void NPCLoot() 
{
    if(ModWorld.Slayed.ContainsKey(npc.displayName)) npc.value = 0;
    if(!(ModWorld.Slayed.ContainsKey(npc.displayName) || !npc.boss))
    {
        Main.NewText("The souls of "+npc.displayName+ " have been released");
        ModWorld.Slayed.Add(npc.displayName,0);
    }

    
    int Amt = (int)npc.value/10;
    int ItemID = Config.itemDefs.byName["Dark Soul"].type;
    if(Amt <= 0) return; //don't drop souls if you need to drop 0 souls feel free to remove this

    foreach(Player P in Main.player)
    {
        foreach(Item I in P.armor)
        {
            if(I.type == Config.itemDefs.byName["Covetous Silver Serpent Ring"].type)
            {
                Amt = (int)(npc.value*1.25f)/10;
    
                break;
            }
			if(I.type == Config.itemDefs.byName["Covetous Soul Serpent Ring"].type)
            {
                Amt = (int)(npc.value*1.25f)/10;
    
                break;
            }
        }
    }
 
  if (Main.netMode != 1)
  {
    int Index = Item.NewItem((int)npc.position.X,(int)npc.position.Y,20,20,ItemID,Amt);
    //Main.item[Index].SetDefaults("Dark Soul");
    Main.item[Index].stack = Amt;
    Main.item[Index].damage = -1;
    NetMessage.SendData(21, -1, -1, "", Index, 0f,0f,0f, 0);
  }

}