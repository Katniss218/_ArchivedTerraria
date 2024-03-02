public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    if (npc.name=="Muck") damage *= 20;
    if (npc.name=="Scum") damage *= 20;
    if (npc.name=="Ooze") damage *= 20;
    if (npc.name=="Black Flan") damage *= 20;
}