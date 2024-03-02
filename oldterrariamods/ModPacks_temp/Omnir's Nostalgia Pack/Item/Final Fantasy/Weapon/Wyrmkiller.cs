public void DamageNPC(Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
    if(npc.name=="Omnirs Ancient Dragon") damage *= 12;
    else if(npc.name=="Omnirs Ancient Great Dragon") damage *= 12;
    else if(npc.name=="Wyvern") damage *= 12;
    else if(npc.name=="Omnirs Hydra") damage *= 12;
    else if(npc.name=="Omnirs The Wind Fiend Tiamat") damage *= 20;
    else if(npc.name=="Omnirs Tibian Dragon") damage *= 12;
    else if(npc.name=="Omnirs Tibian Dragon Lord") damage *= 12;
    else if(npc.name=="Omnirs Fabled Wyvern") damage *= 12;    
}