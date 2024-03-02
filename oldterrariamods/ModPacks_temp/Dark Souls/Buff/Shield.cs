public static void Effects(Player player, int playerID)
{
    player.statDefense +=62;
    for(int num47 = 0; num47 < 10; num47++)
    {
        if (player.buffType[num47] == Config.buffID["Fog"])
        {
            player.buffType[num47] = 0;
            player.buffTime[num47] = 0;

            break;
        }
    }
    for(int num48 = 0; num48 < 10; num48++)
    {
        if (player.buffType[num48] == Config.buffID["Barrier"])
        {
            player.buffType[num48] = 0;
            player.buffTime[num48] = 0;

            break;
        }
    }
    for(int num49 = 0; num49 < 10; num49++)
    {
        if (player.buffType[num49] == Config.buffID["Wall"])
        {
            player.buffType[num49] = 0;
            player.buffTime[num49] = 0;

            break;
        }
    }
}

