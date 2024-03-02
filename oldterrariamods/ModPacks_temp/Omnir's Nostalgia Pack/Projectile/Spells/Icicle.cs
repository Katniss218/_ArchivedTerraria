#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff(Config.buffID["Frozen"], 360, false); //slows them down!
}
#endregion