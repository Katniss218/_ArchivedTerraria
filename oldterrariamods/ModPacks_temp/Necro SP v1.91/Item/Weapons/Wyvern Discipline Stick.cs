public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
    if (npc.name=="Wyvern Head") damage *= 34;    
    else if (npc.name=="Wyvern Legs") damage *= 34;
    else if (npc.name=="Wyvern Body") damage *= 34;
    else if (npc.name=="Wyvern Body 2") damage *= 44;
    else if (npc.name=="Wyvern Body 3") damage *= 44;
    else if (npc.name=="Wyvern Tail") damage *= 44;
}