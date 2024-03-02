public void DamageNPC(Player myPlayer, NPC npc, ref int damage, ref float knockback){
    if(npc.name=="Wyvern Body") damage *= 8;
	else if(npc.name=="Wyvern Tail") damage *= 8;
    else if(npc.name=="Wyvern Head") damage *= 8;
    else if(npc.name=="Shadow Dragon Body") damage *= 8;
    else if(npc.name=="Shadow Dragon Head") damage *= 8;
    else if(npc.name=="Wyvern Mage Disciple") damage *= 8;
    else if(npc.name=="Jungle Wyvern Body") damage *= 8;
    else if(npc.name=="Jungle Wyvern Head") damage *= 8;
    else if(npc.name=="Ghost Dragon Head") damage *= 6;
    else if(npc.name=="Ghost Dragon Body") damage *= 6;
    else if(npc.name=="MechaDragon Head") damage *= 8;
    else if(npc.name=="MechaDragon Body") damage *= 8;
	else if(npc.name=="Hellkite Dragon Tail") damage *= 6;
	else if(npc.name=="Hellkite Dragon Head") damage *= 6;
	else if(npc.name=="Hellkite Dragon Body") damage *= 6;
	else if(npc.name=="Seath the Scaleless Tail") damage *= 6;
	else if(npc.name=="Seath the Scaleless Head") damage *= 6;
	else if(npc.name=="Seath the Scaleless Body") damage *= 6;



}