int tempDef;
public void DamageNPC(Player P,NPC npc, ref int damage, ref float knockback)
{
    if(!item.magic) return; //don't do anything if the item isn't magical
    tempDef = npc.defense;
    if(npc.RunMethod("MagicDefenseValue")) npc.defense = (int)Codable.customMethodReturn;
}

public void DealtNPC(Player player,NPC npc, double damage) 
{
    if(!item.magic) return; //don't do anything if the item isn't magical
    npc.defense = tempDef;
    if(npc.RunMethod("MagicDefenseValue")) npc.defense = (int)Codable.customMethodReturn;
}