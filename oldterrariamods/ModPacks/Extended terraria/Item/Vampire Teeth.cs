//public void DealtNPC(Player P, double DMG, NPC N)
public void DamageNPC(Player P, NPC N, ref int DMG, ref float KB)
{
    bool
        me = P.inventory[P.selectedItem].melee,
        r = P.inventory[P.selectedItem].ranged,
        ma = P.inventory[P.selectedItem].magic;
    int amt = 0;
    if (me)
        amt = (int)((DMG / 100d) * 6d);
    else if (r || ma)
        amt = (int)((DMG / 100d) * 3d);
    if (amt < 1)
        amt  = 1;
    if (amt > 8)
        amt = 8;
    P.statLife += amt;
    N.life -= amt;
    if (N.life < 1)
    {
	N.life = 0;
	N.active = false;
	N.NPCLoot();
    }
    P.HealEffect(amt);
    if (ma)
    {
        amt /= 2;
        P.statMana += amt;
        P.ManaEffect(amt);
        N.life -= amt;
	if (N.life < 1)
	{
	    N.life = 0;
	    N.active = false;
	    N.NPCLoot();
	}
    }
}