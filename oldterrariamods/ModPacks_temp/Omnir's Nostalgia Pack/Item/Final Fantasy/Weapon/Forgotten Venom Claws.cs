public void HoldStyle(Player P)
{
    Main.chain3Texture = Main.goreTexture[Config.goreID["Forgotten Scorpion Tail Chain"]];
}


public static void StatusNPC(NPC npc) 
{
	if (Main.rand.Next(30) == 0) 
    { //50% chance to occur
		npc.AddBuff(20, 360, false); //poisons the enemy
	}
}