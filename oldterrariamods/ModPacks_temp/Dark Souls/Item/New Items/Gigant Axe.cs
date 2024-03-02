public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Hero of Lumelia") damage *= 2;
    else if (npc.name=="Warlock") damage *= 2;
    else if (npc.name=="Black Knight") damage *= 2;
    else if (npc.name=="Tibian Amazon") damage *= 2;
    else if (npc.name=="Tibian Valkyrie") damage *= 2;
    else if (npc.name=="Man Hunter") damage *= 2;
    else if (npc.name=="Red Cloud Hunter") damage *= 2;
    else if (npc.name=="Red Cloud Assassin") damage *= 2;
    else if (npc.name=="Dunlending") damage *= 2;
}