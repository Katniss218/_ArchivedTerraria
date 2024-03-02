public void UseItem(Player player, int playerID)
{
if (playerID == Main.myPlayer) ModPlayer.Hunger += ModPlayer.ValueTwelve;
player.AddBuff("Tipsy II", 7200, false);
}