public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
    if (npc.name=="Wall of Flesh Eye") damage *= 34;    
    else if (npc.name=="The Hungry") damage *= 34;
    else if (npc.name=="The Hungry II") damage *= 34;
    else if (npc.name=="Leech") damage *= 44;
    else if (npc.name=="The Hungry II") damage *= 44;
}