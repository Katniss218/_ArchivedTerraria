public void UseItem(Player player, int playerID)
{
if (playerID == Main.myPlayer) ModPlayer.Hunger += 8;
player.AddBuff(25, 7200, false);
}