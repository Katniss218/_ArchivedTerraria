/*public void DealtNPC(Player P, double DMG, NPC N)
{
    if (Main.rand.Next(100) < 12)
        N.AddBuff(31, 600);
}*/

public void DamageNPC(Player P, NPC N, ref int DMG, ref float KB)
{
	if (Main.rand.Next(100) < 12) N.AddBuff(31, 600);
}