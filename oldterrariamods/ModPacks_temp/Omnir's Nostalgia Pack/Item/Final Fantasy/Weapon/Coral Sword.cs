public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Shark") damage *= 4;
    else if (npc.name=="Goldfish") damage *= 4;
    else if (npc.name=="Corrupt Goldfish") damage *= 4;
    else if (npc.name=="Jelly Fish") damage *= 4;
    else if (npc.name=="Piranha") damage *= 4;
    else if (npc.name=="Angler Fish") damage *= 4;
    else if (npc.name=="Omnirs Sahagin") damage *= 4;
    else if (npc.name=="Omnirs Sahagin Chief") damage *= 4;
    else if (npc.name=="Omnirs Sahagin Prince") damage *= 4;
    else if (npc.name=="Omnirs Quara Constrictor") damage *= 4;
    else if (npc.name=="Omnirs Quara Hydromancer") damage *= 4;
    else if (npc.name=="Omnirs Quara Mantassin") damage *= 4;
    else if (npc.name=="Omnirs Quara Pincher") damage *= 4;
    else if (npc.name=="Omnirs Quara Predator") damage *= 4;
    else if (npc.name=="Omnirs Water Fiend Kraken") damage *= 4;
}