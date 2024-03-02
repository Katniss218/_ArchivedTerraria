public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff(20, 300, false);
	}
}
public static void Effects(Player player) {
	player.meleeSpeed += 0.05f;
} 