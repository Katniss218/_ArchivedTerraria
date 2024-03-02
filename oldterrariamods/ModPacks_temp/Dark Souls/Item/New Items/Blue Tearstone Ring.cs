//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
				
				if(player.statLife <= 80) 
				
				{
					player.statDefense += 50;
                                	player.meleeCrit -= 50;
					player.meleeDamage -= 2f;
				}
				
				else 

				{ 
					player.statDefense += 6;
				}   
   
}