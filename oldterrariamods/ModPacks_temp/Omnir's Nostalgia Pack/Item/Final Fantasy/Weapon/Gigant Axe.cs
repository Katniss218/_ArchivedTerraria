public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Omnirs Gigas") damage *= 2;
    else if (npc.name=="Omnirs Fire Gigas") damage *= 4;
    else if (npc.name=="Omnirs Ice Gigas") damage *= 4;
    else if (npc.name=="Omnirs Iron Giant") damage *= 4;
    else if (npc.name=="Omnirs Rock Golem") damage *= 4;
    else if (npc.name=="Omnirs Clay Golem") damage *= 4;
    else if (npc.name=="Omnirs Iron Golem") damage *= 4;
}