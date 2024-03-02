public void HoldStyle(Player P)
{
    Main.chain3Texture = Main.goreTexture[Config.goreID["Old Morning Star Chain"]];
}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
    	if (npc.name=="Tim") damage *= 2;
    	else if (npc.name=="Dark Caster") damage *= 2;
    	else if (npc.name=="Goblin Sorcerer") damage *= 2;
    	else if (npc.name=="Undead Caster") damage *= 2;
    	else if (npc.name=="Mindflayer Servant") damage *= 2;
        else if (npc.name=="Dungeon Mage") damage *= 2;
	else if (npc.name=="Demon Spirit") damage *= 2;
	else if (npc.name=="Crazed Demon Spirit") damage *= 2;
	else if (npc.name=="Shadow Mage") damage *= 2;
	else if (npc.name=="Attraidies Illusion") damage *= 2;
	else if (npc.name=="Attraidies Manifestation") damage *= 2;
    	else if (npc.name=="Mindflayer King") damage *= 2;
    	else if (npc.name=="Dark Shogun Mask") damage *= 2;
	else if (npc.name=="Dark Dragon Mask") damage *= 2;
	else if (npc.name=="Broken Okiku") damage *= 2;
	else if (npc.name=="Okiku") damage *= 2;
	else if (npc.name=="Wyvern Mage") damage *= 2;
	else if (npc.name=="Ghost of the Forgotten Knight") damage *= 2;
	else if (npc.name=="Ghost of the Forgotten Warrior") damage *= 2;
        else if (npc.name=="Barrow Wight") damage *= 2;

}