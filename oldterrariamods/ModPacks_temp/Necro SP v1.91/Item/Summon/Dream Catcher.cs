public static void UseItem(Player player, int playerID)
{
		if(Main.dayTime == false)
		{
			Main.NewText("The guardian of the dream is comming", 255, 127, 127);
		}
			if(!NPC.AnyNPCs(Config.npcDefs.byName["Nightmare Dragon"].type))
		{
			NPC.NewNPC((int)player.position.X-725,(int)player.position.Y-134,"Nightmare Dragon",0);
		}
}