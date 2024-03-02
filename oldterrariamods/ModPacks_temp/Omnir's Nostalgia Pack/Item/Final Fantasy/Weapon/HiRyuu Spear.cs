public void DamageNPC(Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
    if(npc.name=="Omnirs Ancient Dragon") damage *= 3;
    else if(npc.name=="Omnirs Ancient Great Dragon") damage *= 3;
    else if(npc.name=="Wyvern") damage *= 3;
    else if(npc.name=="Omnirs Hydra") damage *= 3;
    else if(npc.name=="Omnirs The Wind Fiend Tiamat") damage *= 3;
    else if(npc.name=="Omnirs Tibian Dragon") damage *= 3;
    else if(npc.name=="Omnirs Tibian Dragon Lord") damage *= 3;
    else if(npc.name=="Omnirs Fabled Wyvern") damage *= 3;    
}