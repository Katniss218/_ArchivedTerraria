public static void Effects(Player player) 
{
    for(int num36 = 0; num36 < 10; num36++)
	{
		if (player.buffType[num36] == 30) //30 is bleeding
		{
		player.buffType[num36] = 0;
		player.buffTime[num36] = 0;
		
		break;
		}
	}
}

