#region Debuff
public void StatusPlayer(Player player)
{
    player.AddBuff(22, 3000, false);
    player.AddBuff(23, 200, false);
    player.AddBuff(33, 3000, false);
    player.AddBuff(36, 3000, false);
}
#endregion

#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff(22, 3000, false);
    npc.AddBuff(23, 200, false);
    npc.AddBuff(33, 3000, false);
    npc.AddBuff(36, 3000, false);
    return;
}
#endregion