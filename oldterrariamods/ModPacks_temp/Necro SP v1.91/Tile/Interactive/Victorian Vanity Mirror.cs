public void UseTile(Player player, int x, int y){

	//update when new hairstyles. 0 is also a hairstyle.
	int maxHairStyles;
	maxHairStyles = 36;

	if ( player.hair < (maxHairStyles - 1) ) { // If player's current hair is less than index 35

		player.hair += 1; // We'll increment it!

	} else {

		player.hair = 0; // Otherwise, it will crash, so we'll just reset it to 0 and cycle through it again.

	}

}