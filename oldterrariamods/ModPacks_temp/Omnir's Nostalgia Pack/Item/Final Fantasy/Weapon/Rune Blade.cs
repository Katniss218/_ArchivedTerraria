public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Tim") damage *= 4;
    else if (npc.name=="Dark Caster") damage *= 4;
    else if (npc.name=="Goblin Sorcerer") damage *= 4;
    else if (npc.name=="Omnirs Orc Shaman") damage *= 4;
    else if (npc.name=="Omnirs Minotaur Mage") damage *= 4;
    else if (npc.name=="Omnirs Mindflayer") damage *= 4;
    else if (npc.name=="Omnirs Piscodemon") damage *= 4;
    else if (npc.name=="Omnirs Witch") damage *= 4;
    else if (npc.name=="Omnirs Warlock") damage *= 4;
    else if (npc.name=="Omnirs Necromancer") damage *= 4;
    else if (npc.name=="Omnirs Evil Priestess") damage *= 4;
}