public void W1K_Food(Player player, int food)
{
	if (player.whoAmi == Main.myPlayer) ModPlayer.Hunger += food;
}
public void W1K_ReductionMultiplierSet(Player player, int value) {if (player.whoAmi == Main.myPlayer) ModPlayer.ReductionMultiplier = value;}
public void W1K_ReductionMultiplierAdd(Player player, int value) {if (player.whoAmi == Main.myPlayer) ModPlayer.ReductionMultiplier += value;}
public void W1K_ReductionMultiplierMultiply(Player player, int value) {if (player.whoAmi == Main.myPlayer) ModPlayer.ReductionMultiplier *= value;}