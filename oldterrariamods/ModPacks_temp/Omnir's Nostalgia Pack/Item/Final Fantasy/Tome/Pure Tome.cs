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
}