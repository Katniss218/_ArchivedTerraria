bool jump = false;
bool jump1 = false;
int jumped = 0;
int blocked = 0;
int anticheat = 0;
int layegg = 500;
int anticheat2 = 0;
int anticheat3 = 0;

public void AI(){
int num5 = 60;
layegg--;			
						bool flag2 = false;
						bool flag3 = true;


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

if(anticheat == 3 && anticheat2<180){
anticheat = 0;
jump1 = true;
}




						if(jump){

                        if(jump1){
						
                          //JUMP
							this.npc.velocity.Y = -14f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(3 * this.npc.direction);
                            jumped = 75;
                            jump = false;
                            jump1 = false;
                            
						}
						else
						{
                          //JUMP
							this.npc.velocity.Y = -9.5f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(6 * this.npc.direction);

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
						
						
}


#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mini Spider Gore 1", 0.4f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mini Spider Gore 2", 0.4f, -1);
}
}
#endregion