public void UseItem(Player P, int PID) {
	if (!ModWorld.PoGoblinInvasion) {
        ModWorld.StartPoGoblinInvasion();
		// Main.PlaySound(15, -1, -1, 0); // play the summoning sound (optional)
    }
}