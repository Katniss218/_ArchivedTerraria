public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
    	if (npc.name=="Tim") damage *= 4;
    	else if (npc.name=="Dark Caster") damage *= 8;
    	else if (npc.name=="Goblin Sorcerer") damage *= 8;
    	else if (npc.name=="Undead Caster") damage *= 8;
    	else if (npc.name=="Mindflayer Servant") damage *= 8;
        else if (npc.name=="Dungeon Mage") damage *= 4;
	else if (npc.name=="Demon Spirit") damage *= 4;
	else if (npc.name=="Crazed Demon Spirit") damage *= 5;
	else if (npc.name=="Shadow Mage") damage *= 4;
	else if (npc.name=="Attraidies Illusion") damage *= 4;
	else if (npc.name=="Attraidies Manifestation") damage *= 4;
    	else if (npc.name=="Mindflayer King") damage *= 5;
    	else if (npc.name=="Dark Shogun Mask") damage *= 5;
	else if (npc.name=="Dark Dragon Mask") damage *= 5;
	else if (npc.name=="Broken Okiku") damage *= 4;
	else if (npc.name=="Okiku") damage *= 5;
	else if (npc.name=="Wyvern Mage") damage *= 4;
	else if (npc.name=="Lich King Disciple") damage *= 5;
	else if (npc.name=="Attraidies") damage *= 5;
}