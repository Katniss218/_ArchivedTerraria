// Cycles the player's hair through all available choices

public static void UseItem(Player player, int playerID) {

	/*
	How many hair styles are there? Well, if we look through the ripped images,
	we see that there are several named "Player_Hair_nn", where nn is a number
	from 1 to 36. So, we'll make a variable to keep track of that here. We want
	a variable because if we set it in one place, it will change across the whole
	script, so it potentially saves time and makes the script more flexible.
	*/

	int maxHairStyles;
	maxHairStyles = 36;

	/*
	If we go past the number of hairstyles, the game will crash (index out of bounds).
	So, what we want is to see if we're at the last hair style, and if we are, rather
	than increment it and crash, we'll just reset it to the first one. Even though they
	are labelled from 1-36, in programming it will convert to 0-35 since arrays start at
	0. We'll adjust our script to compensate for this.
	*/

	if ( player.hair < (maxHairStyles - 1) ) { // If player's current hair is less than index 35

		player.hair++; // We'll increment it!
		if (player.hair == 15) player.hair++;

	} else {

		player.hair = 0; // Otherwise, it will crash, so we'll just reset it to 0 and cycle through it again.

	}

}