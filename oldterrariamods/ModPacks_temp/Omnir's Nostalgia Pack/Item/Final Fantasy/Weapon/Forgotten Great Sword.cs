public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Gigas") damage *= 2;
    else if (npc.name=="Fire Gigas") damage *= 4;
    else if (npc.name=="Ice Gigas") damage *= 4;
    else if (npc.name=="Iron Giant") damage *= 4;
    else if (npc.name=="Rock Golem") damage *= 4;
    else if (npc.name=="Clay Golem") damage *= 4;
    else if (npc.name=="Iron Golem") damage *= 4;
}