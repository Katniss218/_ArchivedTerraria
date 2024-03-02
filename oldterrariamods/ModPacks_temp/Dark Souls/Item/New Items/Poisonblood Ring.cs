public static void Effects(Player player) 
{
    
	for(int num37 = 0; num37 < 10; num37++)
	{
		if (player.buffType[num37] == 20) //20 is poisoning
		{
		player.buffType[num37] = 0;
		player.buffTime[num37] = 0;
		
		break;
		}
	}

	for(int num36 = 0; num36 < 10; num36++)
	{
		if (player.buffType[num36] == 30) //30 is bleeding
		{
		player.buffType[num36] = 0;
		player.buffTime[num36] = 0;
		
		break;
		}
	}


    player.lifeRegen += 2;
}

