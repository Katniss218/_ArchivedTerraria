public void Effects(Player player) {

int rainWidth = Main.screenWidth + 1000;
 
//Number of loops changes based on screen width to maintain more uniform rain density across various resolutions.
for(int i=0; i< rainWidth/300; i++){ //dividing rainWidth by a smaller value will increase rain density, a large value will decrease it.
 
int Xpos = Main.rand.Next(rainWidth) + (int)Main.screenPosition.X - 500;
int Ypos = (int)Main.screenPosition.Y;
int num5 = Dust.NewDust(new Vector2((float)Xpos, (float)Ypos), 10, 10, 14, 0f, 0f, 0, default(Color), (float)(Main.rand.Next(9,13)/10) );
Main.dust[num5].velocity.Y = (2.5f + (float)Main.rand.Next(30) * 0.8f) * Main.dust[num5].scale;
 
//Code for future wind addition?
//Main.dust[num5].velocity.X = Main.windSpeed + (float)Main.rand.Next(10) * 1.1f;

int x = (int)player.position.X;

if(Main.rand.Next(2)==0){
    x+=Main.rand.Next(4500);
}else{
    x-=Main.rand.Next(4500);
}

if(Main.rand.Next(30) == 0){
    int projname = Config.projDefs.byName["WaterParticle"].type;
    int water = Projectile.NewProjectile(x, (int)Main.screenPosition.Y, 0, 0, projname, 0, 0, 255)  ;
}



}

// Raining !
	
}			


		
		
