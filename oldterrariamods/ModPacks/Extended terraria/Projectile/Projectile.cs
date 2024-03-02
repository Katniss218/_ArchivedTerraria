public void DamageNPC(NPC N, ref int dmg, ref float kb)
{
	Player P = Main.player[N.target];
	if (P.HasBuff("Wealth") != -1)
	{
		N.AddBuff("Wealth", 25000);
	}
}

/*public void DealtNPC(NPC N, double D, Player P)
{
	if (P.inventory[P.selectedItem].name == "Ultrashark" && ModWorld.burned)
	{
		N.life += (int)(D / 2);
	}
}*/