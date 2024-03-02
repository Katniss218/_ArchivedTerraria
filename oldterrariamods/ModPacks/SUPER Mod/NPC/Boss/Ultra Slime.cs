int AIStyle =0;
int AISubStyle =0;
int timer=70;
int timer2=60;
int timer3=40;
int timer4=7;
int tofire = 7;
int Hard = 1;
int done = 0;
int roll = 15;
int jump = 180;
int fire = 150;


public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.snowTiles >= 20)
					{

	   if( Main.rand.Next(100000)==1) return true;
    return false;
    }
return false;
}



public void AI(){

					Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					Vector2 arg_244_0 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_244_1 = this.npc.width;
					int arg_244_2 = this.npc.height;
					int arg_244_3 = 6;
					float arg_244_4 = this.npc.velocity.X * 0.2f;
					float arg_244_5 = this.npc.velocity.Y * 0.2f;
					int arg_244_6 = 100;
					Color newColor = default(Color);
					int num2 = Dust.NewDust(arg_244_0, arg_244_1, arg_244_2, arg_244_3, arg_244_4, arg_244_5, arg_244_6, newColor, 1.7f);
					Main.dust[num2].noGravity = true;

if(AIStyle==0){

if(Hard>0 && this.npc.life < 1000){
AIStyle=3;
}
                        if(AISubStyle==1){


                            this.npc.rotation += (float)1.57/12;
                            }

if(this.npc.rotation>(4*1.57) || this.npc.velocity.Y == 0f){
this.npc.rotation=0;
done = 0;
AISubStyle=0;
}

/////
if(this.npc.rotation>(2*1.57) && done==0){
////
int style = Config.projDefs.byName["Slimes"].type;
int dmg = 35;

if(Main.hardMode==true){
dmg = 55;
}
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) 10, 0, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) -10, 0, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) 0, 10, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) 0, -10, style, dmg, 0, Main.myPlayer)  ;


Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) 10, -10, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) -10, -10, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) -10, 10, style, dmg, 0, Main.myPlayer)  ;
Projectile.NewProjectile((int)this.npc.position.X, (int)this.npc.position.Y,(float) 10, 10, style, dmg, 0, Main.myPlayer)  ;




done=1;
}
								
				
float num225 = (float)this.npc.life / (float)this.npc.lifeMax;
																		num225 = num225 * 0.5f + 1.5f;
				

																		if (num225 != this.npc.scale)
																		{
																			this.npc.position.X = this.npc.position.X + (float)(this.npc.width / 2);
																			this.npc.position.Y = this.npc.position.Y + (float)this.npc.height;
																			this.npc.scale = num225;
																			this.npc.width = (int)(108f * this.npc.scale);
																			this.npc.height = (int)(102f * this.npc.scale);
																			this.npc.position.X = this.npc.position.X - (float)(this.npc.width / 2);
																			this.npc.position.Y = this.npc.position.Y - (float)this.npc.height;
																		}


				if (this.npc.ai[2] > 1f)
				{
					this.npc.ai[2] -= 1f;
				}

				this.npc.aiAction = 0;
				if (this.npc.ai[2] == 0f)
				{
					this.npc.ai[0] = -100f;
					this.npc.ai[2] = 1f;
					this.npc.TargetClosest(true);
				}
				if (this.npc.velocity.Y == 0f)
				{
					if (this.npc.ai[3] == this.npc.position.X)
					{
						this.npc.direction *= -1;
						this.npc.ai[2] = 200f;
					}
					this.npc.ai[3] = 0f;
					this.npc.velocity.X = this.npc.velocity.X * 0.9f;
					if ((double)this.npc.velocity.X > -0.1 && (double)this.npc.velocity.X < 0.1)
					{
						this.npc.velocity.X = 0f;
					}

						this.npc.ai[0] += 3f;
				
					if (this.npc.ai[0] >= 0f)
					{
						this.npc.netUpdate = true;
						if (this.npc.ai[2] == 1f)
						{
							this.npc.TargetClosest(true);
						}


                          if(Main.rand.Next(roll)==0){

                         AISubStyle=1;
                        }
                        



						if (this.npc.ai[1] == 2f)
						{
                           
							this.npc.velocity.Y = -10f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(7 * this.npc.direction);
							this.npc.ai[0] = -200f;
							this.npc.ai[1] = 0f;
							this.npc.ai[3] = this.npc.position.X;
						}
						else
						{
    
							this.npc.velocity.Y = -7.5f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(5 * this.npc.direction);
							this.npc.ai[0] = -120f;
							this.npc.ai[1] += 1f;
						}
	
					}
					else
					{
                    
						if (this.npc.ai[0] >= -30f)
						{
                            if(Main.rand.Next(jump)==0){
AIStyle=1;
}
                            if(Main.rand.Next(fire)==0){
  //if(Main.rand.Next(130)==0){
AIStyle=2;
}
							this.npc.aiAction = 1;
							return;
						}
					}
				}
				else
				{
					if (this.npc.target < 255 && ((this.npc.direction == 1 && this.npc.velocity.X < 3f) || (this.npc.direction == -1 && this.npc.velocity.X > -3f)))
					{
						if ((this.npc.direction == -1 && (double)this.npc.velocity.X < 0.1) || (this.npc.direction == 1 && (double)this.npc.velocity.X > -0.1))
						{

							this.npc.velocity.X = this.npc.velocity.X + 0.2f * (float)this.npc.direction;
							return;
						}
						this.npc.velocity.X = this.npc.velocity.X * 0.93f;
						return;
					}
				}
}
else if (AIStyle == 1){

this.npc.velocity.Y = -7.5f;

timer--;

if(timer<0){
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
timer2--;
this.npc.velocity.Y = +13.5f;

if(timer2<0){

int style = Config.projDefs.byName["LavaSlimes"].type;
int dmg = 40;
if(Main.hardMode==true){
dmg = 60;
}
   Projectile.NewProjectile(this.npc.position.X-350-Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.npc.position.X-150-Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X-50-Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ; 

   Projectile.NewProjectile(this.npc.position.X, this.npc.position.Y+550, 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ;  

   Projectile.NewProjectile(this.npc.position.X+50+Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+150+Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+350+Main.rand.Next(100), this.npc.position.Y+350+Main.rand.Next(100), 0, -(Main.rand.Next(5)+5), style, dmg, 0, Main.myPlayer)   ;  


timer=70;
timer2=60;
AIStyle=0;
}
}
}else if(AIStyle == 2){
timer3--;
if(timer3<0){

timer4--;
if(timer4<0 && tofire>0){

int style = Config.projDefs.byName["Slimes"].type;
int dmg = 35;
if(Main.hardMode==true){
dmg = 65;
}

Projectile.NewProjectile(this.npc.position.X+this.npc.height/2, this.npc.position.Y+this.npc.width/2, 8*(this.npc.direction) , Main.rand.Next(-4,2), style, dmg, 0, Main.myPlayer)  ;

tofire-=1;
timer4=7;
}

if(tofire<=0){
timer3=0;
timer4=0;
tofire=Main.rand.Next(5)+5;
AIStyle=0;
}
}
}
else if (AIStyle == 3){
					Vector2 arg_244_01 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_244_11 = this.npc.width;
					int arg_244_21 = this.npc.height;
					int arg_244_31 = 6;
					float arg_244_41 = this.npc.velocity.X * 0.2f;
					float arg_244_51 = this.npc.velocity.Y * 0.2f;
					int arg_244_61 = 100;
					Color newColor2 = default(Color);
					int aa = Dust.NewDust(arg_244_01, arg_244_11, arg_244_21, arg_244_31, arg_244_41, arg_244_51, arg_244_61, newColor2, 1.7f);
					Main.dust[aa].noGravity = true;

					Vector2 arg_24412 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_24413 = this.npc.width;
					int arg_24414 = this.npc.height;
					int arg_24415 = 6;
					float arg_24416 = this.npc.velocity.X * 0.2f;
					float arg_24417 = this.npc.velocity.Y * 0.2f;
					int arg_24418 = 100;
					Color newColor1 = default(Color);
					int a = Dust.NewDust(arg_24412, arg_24413, arg_24414, arg_24415, arg_24416, arg_24417, arg_24418, newColor1, 1.7f);
					Main.dust[a].noGravity = true;


this.npc.velocity.Y =0;
this.npc.velocity.X =0;

if(Main.hardMode == true){
this.npc.defense = 42;
this.npc.lifeMax = 80000;
this.npc.name = "Hardmode Ultra Slime";

}else{ 
this.npc.defense = 30;
this.npc.lifeMax = 7000;
this.npc.name = "Giga Slime";
}
if(this.npc.life<this.npc.lifeMax){
float num225 = (float)this.npc.life / (float)this.npc.lifeMax;
																		num225 = num225 * 0.5f + 1.5f;
this.npc.scale = num225;
this.npc.life+=80;
}else{

roll=10;
jump=150;
fire=110;

Hard--;
AIStyle=0;
}
}
}

public void DealtNPC(double damage, Player player){
if(Main.hardMode==true){
if(Main.rand.Next(100)==0){
NPC.NewNPC((int)this.npc.position.X+this.npc.height/2, (int)this.npc.position.Y+this.npc.width/2, Config.npcDefs.byName["Corrupt Slime"].type, 0);
}
if(Main.rand.Next(140)==0){
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
int style = Config.projDefs.byName["Slimes"].type;
int dmg = 45;

   Projectile.NewProjectile(this.npc.position.X-150, this.npc.position.Y-950, 2, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.npc.position.X-100, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X-50, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ; 

   Projectile.NewProjectile(this.npc.position.X, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  

   Projectile.NewProjectile(this.npc.position.X+50, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+100, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+150, this.npc.position.Y-550, -2, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  

}
}
}