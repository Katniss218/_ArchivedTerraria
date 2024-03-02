public void DamageNPC(Player P,NPC N, ref int DMG, ref float KB)
{
    if(N.name == "Omnirs Witchking" || N.name == "Omnirs Nazgul" || N.name == "Omnirs Sauron" )
    {
        N.defense = 0; //0 is probably better here
        N.AddBuff("Dispel Shadow", 10000, false);
    }
}

public static void StatusNPC(Player P,NPC N, ref int DMG, ref float KB) 
{
        N.AddBuff("Dispel Shadow", 10000, false);
}
