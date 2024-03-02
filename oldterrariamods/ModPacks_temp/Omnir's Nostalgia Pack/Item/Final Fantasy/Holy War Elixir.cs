//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.AddBuff("Invincible", 300, false);
}

public static void UseItem(Player player, int playerID)
{
    player.AddBuff("Invincible", 300, false);
}