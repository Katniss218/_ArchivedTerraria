public static void UseItem(Player player, int playerID)
{
    for(int num36 = 0; num36 < 10; num36++)
    {
        if (player.buffType[num36] == 20)//Poisoned
        {
        player.buffType[num36] = 0;
        player.buffTime[num36] = 0;

        break;
        }
    }
    for(int num37 = 0; num37 < 10; num37++)
    {
        if (player.buffType[num37] == 22)//Darkness
        {
        player.buffType[num37] = 0;
        player.buffTime[num37] = 0;

        break;
        }
    }
    for(int num38 = 0; num38 < 10; num38++)
    {
        if (player.buffType[num38] == 23)//Cursed
        {
        player.buffType[num38] = 0;
        player.buffTime[num38] = 0;

        break;
        }
    }
    for(int num39 = 0; num39 < 10; num39++)
    {
        if (player.buffType[num39] == 24)//On Fire
        {
        player.buffType[num39] = 0;
        player.buffTime[num39] = 0;

        break;
        }
    }
    for(int num40 = 0; num40 < 10; num40++)
    {
        if (player.buffType[num40] == 25)//Tipsy
        {
        player.buffType[num40] = 0;
        player.buffTime[num40] = 0;

        break;
        }
    }
    for(int num41 = 0; num41 < 10; num41++)
    {
        if (player.buffType[num41] == 30)//Bleeding
        {
        player.buffType[num41] = 0;
        player.buffTime[num41] = 0;

        break;
        }
    }
    for(int num42 = 0; num42 < 10; num42++)
    {
        if (player.buffType[num42] == 31)//Confused
        {
        player.buffType[num42] = 0;
        player.buffTime[num42] = 0;

        break;
        }
    }
    for(int num43 = 0; num43 < 10; num43++)
    {
        if (player.buffType[num43] == 32)//Slow
        {
        player.buffType[num43] = 0;
        player.buffTime[num43] = 0;

        break;
        }
    }
    for(int num44 = 0; num44 < 10; num44++)
    {
        if (player.buffType[num44] == 33)//Weak
        {
        player.buffType[num44] = 0;
        player.buffTime[num44] = 0;

        break;
        }
    }
    for(int num45 = 0; num45 < 10; num45++)
    {
        if (player.buffType[num45] == 35)//Silenced
        {
        player.buffType[num45] = 0;
        player.buffTime[num45] = 0;

        break;
        }
    }
    for(int num46 = 0; num46 < 10; num46++)
    {
        if (player.buffType[num46] == 36)//Broken Armor
        {
        player.buffType[num46] = 0;
        player.buffTime[num46] = 0;

        break;
        }
    }
    for(int num47 = 0; num47 < 10; num47++)
    {
        if (player.buffType[num47] == 39)// Cursed Infero
        {
        player.buffType[num47] = 0;
        player.buffTime[num47] = 0;

        break;
        }
    }
}