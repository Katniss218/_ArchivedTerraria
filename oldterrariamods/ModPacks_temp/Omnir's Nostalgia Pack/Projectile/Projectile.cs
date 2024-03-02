int tempDef;
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
    if(!projectile.magic) return; //don't do anything if the projectile isn't magical
    tempDef = npc.defense;
    if(npc.RunMethod("MagicDefenseValue")) npc.defense = (int)Codable.customMethodReturn;
}

public void DealtNPC(NPC npc, double damage,Player owner) 
{
    if(!projectile.magic) return; //don't do anything if the projectile isn't magical
    npc.defense = tempDef;
}

public static void SHIELD_FX(Player P,int Defense)
{
    int ME = P.whoAmi;
    ModPlayer.Defense_Bonus[ME]+=Defense;
}