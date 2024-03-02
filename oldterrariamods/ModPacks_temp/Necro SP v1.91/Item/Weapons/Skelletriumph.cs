public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
    if (npc.name=="Skeleton") damage *= 44;    
    else if (npc.name=="Skeletron") damage *= 44;
    else if (npc.name=="Skeletron Prime") damage *= 64;
    else if (npc.name=="Armored Skeleton") damage *= 44;
    else if (npc.name=="Heavy Skeleton") damage *= 44;
    else if (npc.name=="Big Boned") damage *= 44;
    else if (npc.name=="Angry Boned") damage *= 44;
    else if (npc.name=="Short Boned") damage *= 44;
    else if (npc.name=="Bone Serpent") damage *= 44;
    else if (npc.name=="Big Boned") damage *= 44;
    else if (npc.name=="Cursed Skull") damage *= 44;
    else if (npc.name=="Dark Caster") damage *= 44;
    else if (npc.name=="Dungeon Guardian") damage *= 44;
    else if (npc.name=="Undead Miner") damage *= 44;
    else if (npc.name=="Doctor Bones") damage *= 44;
    else if (npc.name=="Skeleton Archer") damage *= 44;
    else if (npc.name=="Tim") damage *= 44;    
}