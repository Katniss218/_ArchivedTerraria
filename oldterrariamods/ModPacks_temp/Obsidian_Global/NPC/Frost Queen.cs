bool jump = false;
bool jump1 = false;
int jumped = 0;
int blocked = 0;
int anticheat = 0;
int layegg = 500;
int anticheat2 = 0;
int anticheat3 = 0;
int AIstyle = 0;
int timer = 45;
int timer3 = 40;
int timer4 = 7;
int tofire = 15;
int tofire2 = 35;
bool ok = false;
int fired = 0;
int tofire3 = 6;

public void AI(){
if(AIstyle == 0){
int num5 = 60;
layegg--;			
fired --;
						bool flag2 = false;
						bool flag3 = true;

if(this.npc.velocity.X != 0){
anticheat = 0;
if(layegg<0){
this.npc.velocity.X=0;
this.npc.velocity.Y=-1;
NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Egg"].type, 0);

layegg=180+Main.rand.Next(180);
}

if(Main.rand.Next(550)==0 && this.npc.velocity.Y == 0){
AIstyle = 1;
}
}

if(Main.rand.Next(1250)==0 ){
AIstyle = 2;
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
}

if(this.npc.velocity.Y != 0 || jumped > 0){
jump=false;
}

if(this.npc.velocity.X == 0){
blocked++;
}

if(blocked == 75){
anticheat += 1;
blocked = 0;
}

if(anticheat == 2){

anticheat3++;
anticheat = 0;
jump1 = true;
if(Main.rand.Next(4) == 0){
AIstyle = 2;
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
}
}

if(anticheat3 >3){
anticheat2++;
}

if(anticheat2 == 180){
Main.NewText("She's angry...");

// Displays a message about how the ice queen is angry...
}

if(anticheat2 > 420){
anticheat2 = -200;
anticheat3 = 0;
AIstyle = 4;

// Summons a rain of explosive ice bombs between you and her, destroying everything.

}

						if(jump){

                        if(jump1){
						
                          //JUMP
							this.npc.velocity.Y = -17f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(10 * this.npc.direction);
                            jumped = 75;
                            jump = false;
                            jump1 = false;
                            
						}
						else
						{
                          //JUMP
							this.npc.velocity.Y = -12.5f;
							this.npc.velocity.X = this.npc.velocity.X + (float)((10+Main.rand.Next(-2,2)) * this.npc.direction);

                            jumped = 75;
                            jump=false;
						}
}

jumped --;
if(jumped < 0){
jumped = 0;
}


							if (this.npc.velocity.Y == 0f && ((this.npc.velocity.X > 0f && this.npc.direction < 0) || (this.npc.velocity.X < 0f && this.npc.direction > 0)))
							{
// TURNBACK
								flag2 = true;
							}
							if (this.npc.position.X == this.npc.oldPosition.X || this.npc.ai[3] >= (float)num5 || flag2)
							{
								this.npc.ai[3] += 1f;
// BLOCK                        
                                jump = true;
							}
							else
							{
								if ((double)Math.Abs(this.npc.velocity.X) > 0.9 && this.npc.ai[3] > 0f)
								{
									this.npc.ai[3] -= 1f;
								}
							}
							if (this.npc.ai[3] > (float)(num5 * 10))
							{
								this.npc.ai[3] = 0f;
							}
							if (this.npc.justHit)
							{
								this.npc.ai[3] = 0f;
							}
							if (this.npc.ai[3] == (float)num5)
							{
								this.npc.netUpdate = true;
							}
						
					
	// TARGETING
							this.npc.TargetClosest(true);
					
	if(((Math.Abs(this.npc.position.X - Main.player[Main.myPlayer].position.X)) >  780) && fired <0){
AIstyle = 3;
anticheat2 ++;
}
							
								
									
										if (this.npc.velocity.X < -2.5f || this.npc.velocity.X > 2.5f)
										{
											if (this.npc.velocity.Y == 0f)
											{
												this.npc.velocity *= 0.8f;
											}
										}
										else
										{
											if (this.npc.velocity.X < 2.5f && this.npc.direction == 1)
											{
												this.npc.velocity.X = this.npc.velocity.X + 0.07f;
												if (this.npc.velocity.X > 2.5f)
												{
//FALLING
													this.npc.velocity.X = 2.5f;
												}
											}
											else
											{
												if (this.npc.velocity.X > -2.5f && this.npc.direction == -1)
												{
													this.npc.velocity.X = this.npc.velocity.X - 0.07f;
													if (this.npc.velocity.X < -2.5f)
													{
//FALLING
														this.npc.velocity.X = -2.5f;
													}
												}
											}
										}
									
										
											
												
													if (this.npc.velocity.X < -2f || this.npc.velocity.X > 2f)
													{
														if (this.npc.velocity.Y == 0f)
														{
															this.npc.velocity *= 0.8f;
														}
													}
													else
													{
														if (this.npc.velocity.X < 2f && this.npc.direction == 1)
														{
															this.npc.velocity.X = this.npc.velocity.X + 0.07f;
															if (this.npc.velocity.X > 2f)
															{
																this.npc.velocity.X = 2f;
															}
														}
														else
														{
															if (this.npc.velocity.X > -2f && this.npc.direction == -1)
															{
																this.npc.velocity.X = this.npc.velocity.X - 0.07f;
																if (this.npc.velocity.X < -2f)
																{
																	this.npc.velocity.X = -2f;
																}
															}
														}
													}
											
											
										
									

					
						bool flag4 = false;
						if (this.npc.velocity.Y == 0f)
						{
							int num29 = (int)(this.npc.position.Y + (float)this.npc.height + 8f) / 16;
							int num30 = (int)this.npc.position.X / 16;
							int num31 = (int)(this.npc.position.X + (float)this.npc.width) / 16;
							for (int l = num30; l <= num31; l++)
							{
								if (Main.tile[l, num29] == null)
								{
									return;
								}
								if (Main.tile[l, num29].active && Main.tileSolid[(int)Main.tile[l, num29].type])
								{
									flag4 = true;

									break;
								}
							}
						}
}else if(AIstyle==1){						
timer3--;
if(timer3<0){

timer4--;
if(timer4<0 && tofire>0){

int style = Config.projDefs.byName["IceBlock"].type;
int dmg = 20;

Projectile.NewProjectile(this.npc.position.X+Main.rand.Next(-200,200), this.npc.position.Y-950, Main.rand.Next(5,15)*this.npc.direction, Main.rand.Next(12)+22, style, dmg, 0, Main.myPlayer)   ;  


tofire-=1;
timer4=7;
}
}

if(tofire<=0){
timer3=0;
timer4=0;
tofire=Main.rand.Next(20)+15;
AIstyle=0;
}
						
}else if(AIstyle==2){						
timer3--;
if(timer3<0){

timer4--;
if(timer4<0 && tofire2>0){

int style = Config.projDefs.byName["IceBlock"].type;
int dmg = 15;

int proj = Projectile.NewProjectile(this.npc.position.X+32, this.npc.position.Y-32, 12*this.npc.direction, Main.rand.Next(-8,8), style, dmg, 0, Main.myPlayer)   ;  
Main.projectile[proj].scale =(float) (Main.rand.Next(8,25)/10);

tofire2-=1;
timer4=7;
}
}

if(tofire2<=0){
timer3=0;
timer4=0;
tofire2=20;
AIstyle=0;
}
						
}else if(AIstyle==3){

timer--;						
int style = Config.projDefs.byName["CobwebBall"].type;
int dmg = 0;

if(!ok){
Projectile.NewProjectile(this.npc.position.X+32, this.npc.position.Y-32, 0, -15, style, dmg, 0, Main.myPlayer)   ;  
ok = true;
}

if(timer<0){

 style = Config.projDefs.byName["IceCobweb"].type;
dmg = 15;
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200) + 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 800, Main.rand.Next(-2,2), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200) + 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 800, Main.rand.Next(-2,2), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200) + 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 800, Main.rand.Next(-2,2), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200) + 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 800, Main.rand.Next(-2,2), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200) + 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 800, Main.rand.Next(-2,2), 35, style, dmg, 0, Main.myPlayer)   ;  

Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1000, Main.rand.Next(-3,3), 35, style, dmg, 0, Main.myPlayer)   ;  

Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X + Main.rand.Next(-200,200)+ 150*this.npc.direction,Main.player[Main.myPlayer].position.Y - 1300, Main.rand.Next(-4,4), 35, style, dmg, 0, Main.myPlayer)   ;  

 AIstyle=0;
ok = false;
timer = 45;
fired = 240;
}
			
}else if(AIstyle==4){		
				
timer3--;
if(timer3<0){

timer4--;
if(timer4<0 && tofire3>0){

int style = Config.projDefs.byName["IceBomb"].type;
int dmg = 25;

int diff = (int)(Math.Abs(this.npc.position.X - Main.player[Main.myPlayer].position.X))/2;
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
Projectile.NewProjectile(this.npc.position.X + Main.rand.Next(0,diff)*this.npc.direction, this.npc.position.Y-400, 0, 10, style, dmg, 0, Main.myPlayer)   ;  
Projectile.NewProjectile(Main.player[Main.myPlayer].position.X+ Main.rand.Next(0,diff)*(-this.npc.direction), this.npc.position.Y-400, 0, 10, style, dmg, 0, Main.myPlayer)   ;  

tofire3-=1;
timer4=7;
}
}

if(tofire3<=0){
timer3=0;
timer4=0;
tofire3=6;
AIstyle=0;
}
						
}
}

#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost Queen Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost Queen Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost Queen Gore 3", 1f, -1);
}
}
#endregion