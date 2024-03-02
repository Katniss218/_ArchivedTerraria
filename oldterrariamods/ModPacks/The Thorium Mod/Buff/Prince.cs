public void EffectsStart(Player player,int buffIndex,int buffType,int buffTime) 
{
	int LMetroid = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Princess Bee", 0);
    Main.npc[LMetroid].ai[0] = player.whoAmi;
	Main.npc[LMetroid].ai[1] = buffIndex;
	Main.npc[LMetroid].netUpdate = true;
	if (Main.netMode == 2 && LMetroid < 200)
	{
	NetMessage.SendData(23, -1, -1, "", LMetroid, 0f, 0f, 0f, 0);
	}
}

public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(20, 300, false);
	}
}