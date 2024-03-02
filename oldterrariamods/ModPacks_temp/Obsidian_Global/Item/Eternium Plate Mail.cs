
public static int boneCount = 20;


public void Effects(Player player) {
	int def = (int) (player.statDefense *1.15f) ;
    player.statDefense = def;
}

public void SetBonus(Player player) {
    player.setBonus = "20% increased critical strikes \n Cannot bleed";
    player.magicCrit += 20;
    player.meleeCrit += 20;
    player.rangedCrit += 20;
    player.bleed = false;
}
