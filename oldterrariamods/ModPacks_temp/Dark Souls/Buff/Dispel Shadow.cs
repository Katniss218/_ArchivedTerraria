public static void NPCEffects(NPC npc)
{
    if(npc.name == "Witchking" || npc.name == "Artorias")
    {
        npc.defense -= 3000;
        if (npc.defense < 0)
        {
            npc.defense =0;
        }
    }
}

