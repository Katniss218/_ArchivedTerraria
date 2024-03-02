public static void Effects(Player player) {
	player.moveSpeed-=0.1f;
}
public static void SetBonus(Player player) {

	player.setBonus = "Increased defense by 10";
	player.statDefense += 10;
}