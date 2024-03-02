public static void NPCEffects(NPC npc)
{
    if(npc.name == "Omnirs Witchking" || npc.name == "Omnirs Nazgul" || npc.name == "Omnirs Sauron")
    {
        npc.defense -= 3000;
        if (npc.defense < 0)
        {
            npc.defense =0;
        }
    }
}

