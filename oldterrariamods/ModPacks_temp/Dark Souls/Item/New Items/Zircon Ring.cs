public static void Effects(Player player) 
{
      player.AddBuff("Firesoul", 60, false);   
      player.statDefense += 6;
      player.thorns = true;
}