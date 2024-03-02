
//Methods

public static void AddLight(float R, float G, float B) {
	//Add light to entire screen
	if(!Lighting.RGB) {
		float c = (R + G + B) / 3f;
		R = c;
		G = c;
		B = c;
	}
	int xMax = (Main.screenWidth / 16) + (Lighting.offScreenTiles * 2) + 10;
	int yMax = (Main.screenHeight / 16) + (Lighting.offScreenTiles * 2) + 10;
	for(int x=0;x<xMax;x++) {
		for(int y=0;y<yMax;y++) {
			if(R > Lighting.color2[x,y]) {
				Lighting.color2[x,y] = R;
			}
			if(G > Lighting.colorG2[x,y]) {
				Lighting.colorG2[x,y] = G;
			}
			if(B > Lighting.colorB2[x,y]) {
				Lighting.colorB2[x,y] = B;
			}
		}
	}
}

public static void Effects(Player p) {
	p.nightVision = true;
	if(Main.netMode != 2 && p.whoAmi == Main.myPlayer) {
		int x =(int)(Main.screenPosition.X / 16f);
		int y = (int)(Main.screenPosition.Y / 16f);
		int xMax = (int)(Main.screenPosition.X / 16f + Main.screenWidth / 16f);
		int yMax = (int)(Main.screenPosition.Y / 16f + Main.screenHeight/ 16f);
		AddLight(0.16f, 0, 0.24f);
	}
}

public static void VanityEffects(Player p) {
	Effects(p);
}
