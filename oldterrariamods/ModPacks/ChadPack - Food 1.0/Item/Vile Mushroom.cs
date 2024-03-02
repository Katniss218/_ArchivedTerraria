public void UseItem(Player player, int playerID)
{
if (playerID == Main.myPlayer)
{
ModPlayer.Hunger += ModPlayer.ValueThree;
player.AddBuff(20, 600, false);
}
}