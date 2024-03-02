public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Omnirs Black Knight") damage *= 2;
    else if (npc.name=="Omnirs Hero of Lumelia") damage *= 2;
    else if (npc.name=="Omnirs Wild Warrior") damage *= 2;
    else if (npc.name=="Omnirs Easterling") damage *= 2;
    else if (npc.name=="Omnirs Warlock") damage *= 2;
    else if (npc.name=="Omnirs Dunlending") damage *= 2;
    else if (npc.name=="Omnirs Corsair") damage *= 2;
    else if (npc.name=="Omnirs Witch") damage *= 2;
    else if (npc.name=="Omnirs Necromancer") damage *= 2;
    else if (npc.name=="Omnirs Evil Priestess") damage *= 2;
    else if (npc.name=="Omnirs Man Hunter") damage *= 2;
    else if (npc.name=="Omnirs Old Monk") damage *= 2;
    else if (npc.name=="Omnirs Easterling") damage *= 2;
    else if (npc.name=="Omnirs Tibian Amazon") damage *= 4;
    else if (npc.name=="Omnirs Tibian Valkyrie") damage *= 4;
}