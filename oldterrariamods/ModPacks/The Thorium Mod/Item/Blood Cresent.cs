public static void Effects(Player player) {int BuffTime = 60; if (BuffTime <= 1) { BuffTime = 60; }

player.AddBuff("Blood Cresent", (60), false); //set the 300 to buff time
player.statDefense += 1;
}