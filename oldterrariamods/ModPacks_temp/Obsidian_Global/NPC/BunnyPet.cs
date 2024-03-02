
int AIStyle = 0;
bool ok = true;
int timer =  0;
int timer2 = 0;

public void AI(){


if(timer<0){
timer--;
}

if(timer<-10){
timer=0;
}

for(int i=0; i<Main.npc.Length; i++){
float differenceXX = ((Main.npc[i].position.X )- this.npc.position.X);
float differenceYY = ((Main.npc[i].position.Y )-  this.npc.position.Y);

if( (differenceXX > 30f || differenceXX < -30f || differenceYY > 30f || differenceYY < -30f) ){

}else if ( Main.npc[i].type!=this.npc.type && Main.npc[i].type != 46 && Main.npc[i].townNPC == false ){

if(timer==0){
Main.npc[i].StrikeNPC(7,2, this.npc.direction);
timer--;
}

}
}

float differenceX = ((this.npc.position.X )- (Main.player[Main.myPlayer].position.X));
float differenceY = ((this.npc.position.Y )- (Main.player[Main.myPlayer].position.Y));
if(AIStyle != 3){
if( differenceX > 750f || differenceX < -750f && (differenceY > 10f || differenceY < -10f)){

AIStyle = 2;

}else if( differenceX > 15f || differenceX < -15f && (differenceY > 15f || differenceY < -15f)){

AIStyle = 0;
				
}else{

AIStyle =1;

}
}


if(Main.player[this.npc.target].velocity.X == 0 && Main.player[this.npc.target].velocity.Y == 0 && Main.rand.Next(200)==0){


AIStyle = 3;
}

if(AIStyle == 0){


if (this.npc.velocity.X == 0f)
								{
                                      this.npc.velocity.Y -= 0.5f;
                                   
                      
								}

	this.npc.TargetClosest(true);
   int num17 = 60;
						if (this.npc.type == 120)
						{
							num17 = 20;
							if (this.npc.ai[3] == -120f)
							{
								this.npc.velocity *= 0f;
								this.npc.ai[3] = 0f;
								Main.PlaySound(2, (int)this.npc.position.X, (int)this.npc.position.Y, 8);
								Vector2 vector4 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
								float num18 = this.npc.oldPos[2].X + (float)this.npc.width * 0.5f - vector4.X;
								float num19 = this.npc.oldPos[2].Y + (float)this.npc.height * 0.5f - vector4.Y;
								float num20 = (float)Math.Sqrt((double)(num18 * num18 + num19 * num19));
								num20 = 2f / num20;
								num18 *= num20;
								num19 *= num20;
								for (int j = 0; j < 20; j++)
								{
									Vector2 vector5 = this.npc.position;
									int num21 = this.npc.width;
									int num22 = this.npc.height;
									int num23 = 71;
									float speedX2 = num18;
									float speedY4 = num19;
									int num24 = 200;
									int num25 = Dust.NewDust(vector5, num21, num22, num23, speedX2, speedY4, num24, default(Color), 2f);
									Main.dust[num25].noGravity = true;
									Dust dust6 = Main.dust[num25];
									dust6.velocity.X = dust6.velocity.X * 2f;
								}
								for (int k = 0; k < 20; k++)
								{
									Vector2 vector6 = this.npc.oldPos[2];
									int num26 = this.npc.width;
									int num27 = this.npc.height;
									int num28 = 71;
									float speedX3 = -num18;
									float speedY5 = -num19;
									int num29 = 200;
									int num30 = Dust.NewDust(vector6, num26, num27, num28, speedX3, speedY5, num29, default(Color), 2f);
									Main.dust[num30].noGravity = true;
									Dust dust7 = Main.dust[num30];
									dust7.velocity.X = dust7.velocity.X * 2f;
								}
							}
						}
						bool flag2 = false;
						bool flag3 = true;
						if (this.npc.type == 47 || this.npc.type == 67 || this.npc.type == 109 || this.npc.type == 110 || this.npc.type == 111 || this.npc.type == 120)
						{
							flag3 = false;
						}
						if ((this.npc.type != 110 && this.npc.type != 111) || this.npc.ai[2] <= 0f)
						{
							if (this.npc.velocity.Y == 0f && ((this.npc.velocity.X > 0f && this.npc.direction < 0) || (this.npc.velocity.X < 0f && this.npc.direction > 0)))
							{
								flag2 = true;
							}
							if (this.npc.position.X == this.npc.oldPosition.X || this.npc.ai[3] >= (float)num17 || flag2)
							{
								this.npc.ai[3] += 1f;
							}
							else
							{
								if ((double)Math.Abs(this.npc.velocity.X) > 0.9 && this.npc.ai[3] > 0f)
								{
									this.npc.ai[3] -= 1f;
								}
							}
							if (this.npc.ai[3] > (float)(num17 * 10))
							{
								this.npc.ai[3] = 0f;
							}
							if (this.npc.justHit)
							{
								this.npc.ai[3] = 0f;
							}
							if (this.npc.ai[3] == (float)num17)
							{
								this.npc.netUpdate = true;
							}
						}
						if ((!Main.dayTime || (double)this.npc.position.Y > Main.worldSurface * 16.0 || this.npc.type == 26 || this.npc.type == 27 || this.npc.type == 28 || this.npc.type == 31 || this.npc.type == 47 || this.npc.type == 67 || this.npc.type == 73 || true || this.npc.type == 78 || this.npc.type == 79 || this.npc.type == 80 || this.npc.type == 110 || this.npc.type == 111 || this.npc.type == 120) && this.npc.ai[3] < (float)num17)
						{
							this.npc.TargetClosest(true);
						}
						else
						{
							if ((this.npc.type != 110 && this.npc.type != 111) || this.npc.ai[2] <= 0f)
							{
								
								if (this.npc.velocity.X == 0f)
								{
									if (this.npc.velocity.Y == 0f)
									{
										this.npc.ai[0] += 1f;
										if (this.npc.ai[0] >= 2f)
										{
											this.npc.direction *= -1;
											this.npc.spriteDirection = this.npc.direction;
											this.npc.ai[0] = 0f;
										}
									}
								}
								else
								{
									this.npc.ai[0] = 0f;
								}
								if (this.npc.direction == 0)
								{
									this.npc.direction = 1;
								}
							}
						}
						if (this.npc.type == 120)
						{
							if (this.npc.velocity.X < -3f || this.npc.velocity.X > 3f)
							{
								if (this.npc.velocity.Y == 0f)
								{
									this.npc.velocity *= 0.8f;
								}
							}
							else
							{
								if (this.npc.velocity.X < 3f && this.npc.direction == 1)
								{
									if (this.npc.velocity.Y == 0f && this.npc.velocity.X < 0f)
									{
										this.npc.velocity.X = this.npc.velocity.X * 0.99f;
									}
									this.npc.velocity.X = this.npc.velocity.X + 0.07f;
									if (this.npc.velocity.X > 3f)
									{
										this.npc.velocity.X = 3f;
									}
								}
								else
								{
									if (this.npc.velocity.X > -3f && this.npc.direction == -1)
									{
										if (this.npc.velocity.Y == 0f && this.npc.velocity.X > 0f)
										{
											this.npc.velocity.X = this.npc.velocity.X * 0.99f;
										}
										this.npc.velocity.X = this.npc.velocity.X - 0.07f;
										if (this.npc.velocity.X < -3f)
										{
											this.npc.velocity.X = -3f;
										}
									}
								}
							}
						}
						else
						{
							if (this.npc.type == 27 || true || this.npc.type == 104)
							{
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
							}
							else
							{
								if (this.npc.type == 109)
								{
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
											this.npc.velocity.X = this.npc.velocity.X + 0.04f;
											if (this.npc.velocity.X > 2f)
											{
												this.npc.velocity.X = 2f;
											}
										}
										else
										{
											if (this.npc.velocity.X > -2f && this.npc.direction == -1)
											{
												this.npc.velocity.X = this.npc.velocity.X - 0.04f;
												if (this.npc.velocity.X < -2f)
												{
													this.npc.velocity.X = -2f;
												}
											}
										}
									}
								}
								else
								{
									if (this.npc.type == 21 || this.npc.type == 26 || this.npc.type == 31 || this.npc.type == 47 || this.npc.type == 73 || this.npc.type == 140)
									{
										if (this.npc.velocity.X < -1.5f || this.npc.velocity.X > 1.5f)
										{
											if (this.npc.velocity.Y == 0f)
											{
												this.npc.velocity *= 0.8f;
											}
										}
										else
										{
											if (this.npc.velocity.X < 1.5f && this.npc.direction == 1)
											{
												this.npc.velocity.X = this.npc.velocity.X + 0.07f;
												if (this.npc.velocity.X > 1.5f)
												{
													this.npc.velocity.X = 1.5f;
												}
											}
											else
											{
												if (this.npc.velocity.X > -1.5f && this.npc.direction == -1)
												{
													this.npc.velocity.X = this.npc.velocity.X - 0.07f;
													if (this.npc.velocity.X < -1.5f)
													{
														this.npc.velocity.X = -1.5f;
													}
												}
											}
										}
									}
									else
									{
										if (this.npc.type == 67)
										{
											if (this.npc.velocity.X < -0.5f || this.npc.velocity.X > 0.5f)
											{
												if (this.npc.velocity.Y == 0f)
												{
													this.npc.velocity *= 0.7f;
												}
											}
											else
											{
												if (this.npc.velocity.X < 0.5f && this.npc.direction == 1)
												{
													this.npc.velocity.X = this.npc.velocity.X + 0.03f;
													if (this.npc.velocity.X > 0.5f)
													{
														this.npc.velocity.X = 0.5f;
													}
												}
												else
												{
													if (this.npc.velocity.X > -0.5f && this.npc.direction == -1)
													{
														this.npc.velocity.X = this.npc.velocity.X - 0.03f;
														if (this.npc.velocity.X < -0.5f)
														{
															this.npc.velocity.X = -0.5f;
														}
													}
												}
											}
										}
										else
										{
											if (this.npc.type == 78 || this.npc.type == 79 || this.npc.type == 80)
											{
												float num31 = 1f;
												float num32 = 0.05f;
												if (this.npc.life < this.npc.lifeMax / 2)
												{
													num31 = 2f;
													num32 = 0.1f;
												}
												if (this.npc.type == 79)
												{
													num31 *= 1.5f;
												}
												if (this.npc.velocity.X < -num31 || this.npc.velocity.X > num31)
												{
													if (this.npc.velocity.Y == 0f)
													{
														this.npc.velocity *= 0.7f;
													}
												}
												else
												{
													if (this.npc.velocity.X < num31 && this.npc.direction == 1)
													{
														this.npc.velocity.X = this.npc.velocity.X + num32;
														if (this.npc.velocity.X > num31)
														{
															this.npc.velocity.X = num31;
														}
													}
													else
													{
														if (this.npc.velocity.X > -num31 && this.npc.direction == -1)
														{
															this.npc.velocity.X = this.npc.velocity.X - num32;
															if (this.npc.velocity.X < -num31)
															{
																this.npc.velocity.X = -num31;
															}
														}
													}
												}
											}
											else
											{
												if (this.npc.type != 110 && this.npc.type != 111)
												{
													if (this.npc.velocity.X < -1f || this.npc.velocity.X > 1f)
													{
														if (this.npc.velocity.Y == 0f)
														{
															this.npc.velocity *= 0.8f;
														}
													}
													else
													{
														if (this.npc.velocity.X < 1f && this.npc.direction == 1)
														{
															this.npc.velocity.X = this.npc.velocity.X + 0.07f;
															if (this.npc.velocity.X > 1f)
															{
																this.npc.velocity.X = 1f;
															}
														}
														else
														{
															if (this.npc.velocity.X > -1f && this.npc.direction == -1)
															{
																this.npc.velocity.X = this.npc.velocity.X - 0.07f;
																if (this.npc.velocity.X < -1f)
																{
																	this.npc.velocity.X = -1f;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (this.npc.type == 110 || this.npc.type == 111)
						{
							if (this.npc.confused)
							{
								this.npc.ai[2] = 0f;
							}
							else
							{
								if (this.npc.ai[1] > 0f)
								{
									this.npc.ai[1] -= 1f;
								}
								if (this.npc.justHit)
								{
									this.npc.ai[1] = 30f;
									this.npc.ai[2] = 0f;
								}
								int num33 = 70;
								if (this.npc.type == 111)
								{
									num33 = 180;
								}
								if (this.npc.ai[2] > 0f)
								{
									this.npc.TargetClosest(true);
									if (this.npc.ai[1] == (float)(num33 / 2))
									{
										float num34 = 11f;
										if (this.npc.type == 111)
										{
											num34 = 9f;
										}
										Vector2 vector7 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
										float num35 = Main.player[this.npc.target].position.X + (float)Main.player[this.npc.target].width * 0.5f - vector7.X;
										float num36 = Math.Abs(num35) * 0.1f;
										float num37 = Main.player[this.npc.target].position.Y + (float)Main.player[this.npc.target].height * 0.5f - vector7.Y - num36;
										num35 += (float)Main.rand.Next(-40, 41);
										num37 += (float)Main.rand.Next(-40, 41);
										float num38 = (float)Math.Sqrt((double)(num35 * num35 + num37 * num37));
										this.npc.netUpdate = true;
										num38 = num34 / num38;
										num35 *= num38;
										num37 *= num38;
										int num39 = 35;
										if (this.npc.type == 111)
										{
											num39 = 11;
										}
										int num40 = 82;
										if (this.npc.type == 111)
										{
											num40 = 81;
										}
										vector7.X += num35;
										vector7.Y += num37;
										if (Main.netMode != 1)
										{
											Projectile.NewProjectile(vector7.X, vector7.Y, num35, num37, num40, num39, 0f, Main.myPlayer);
										}
										if (Math.Abs(num37) > Math.Abs(num35) * 2f)
										{
											if (num37 > 0f)
											{
												this.npc.ai[2] = 1f;
											}
											else
											{
												this.npc.ai[2] = 5f;
											}
										}
										else
										{
											if (Math.Abs(num35) > Math.Abs(num37) * 2f)
											{
												this.npc.ai[2] = 3f;
											}
											else
											{
												if (num37 > 0f)
												{
													this.npc.ai[2] = 2f;
												}
												else
												{
													this.npc.ai[2] = 4f;
												}
											}
										}
									}
									if (this.npc.velocity.Y != 0f || this.npc.ai[1] <= 0f)
									{
										this.npc.ai[2] = 0f;
										this.npc.ai[1] = 0f;
									}
									else
									{
										this.npc.velocity.X = this.npc.velocity.X * 0.9f;
										this.npc.spriteDirection = this.npc.direction;
									}
								}
								if (this.npc.ai[2] <= 0f && this.npc.velocity.Y == 0f && this.npc.ai[1] <= 0f && !Main.player[this.npc.target].dead && Collision.CanHit(this.npc.position, this.npc.width, this.npc.height, Main.player[this.npc.target].position, Main.player[this.npc.target].width, Main.player[this.npc.target].height))
								{
									float num41 = 10f;
									Vector2 vector8 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
									float num42 = Main.player[this.npc.target].position.X + (float)Main.player[this.npc.target].width * 0.5f - vector8.X;
									float num43 = Math.Abs(num42) * 0.1f;
									float num44 = Main.player[this.npc.target].position.Y + (float)Main.player[this.npc.target].height * 0.5f - vector8.Y - num43;
									num42 += (float)Main.rand.Next(-40, 41);
									num44 += (float)Main.rand.Next(-40, 41);
									float num45 = (float)Math.Sqrt((double)(num42 * num42 + num44 * num44));
									if (num45 < 700f)
									{
										this.npc.netUpdate = true;
										this.npc.velocity.X = this.npc.velocity.X * 0.5f;
										num45 = num41 / num45;
										num42 *= num45;
										num44 *= num45;
										this.npc.ai[2] = 3f;
										this.npc.ai[1] = (float)num33;
										if (Math.Abs(num44) > Math.Abs(num42) * 2f)
										{
											if (num44 > 0f)
											{
												this.npc.ai[2] = 1f;
											}
											else
											{
												this.npc.ai[2] = 5f;
											}
										}
										else
										{
											if (Math.Abs(num42) > Math.Abs(num44) * 2f)
											{
												this.npc.ai[2] = 3f;
											}
											else
											{
												if (num44 > 0f)
												{
													this.npc.ai[2] = 2f;
												}
												else
												{
													this.npc.ai[2] = 4f;
												}
											}
										}
									}
								}
								if (this.npc.ai[2] <= 0f)
								{
									if (this.npc.velocity.X < -1f || this.npc.velocity.X > 1f)
									{
										if (this.npc.velocity.Y == 0f)
										{
											this.npc.velocity *= 0.8f;
										}
									}
									else
									{
										if (this.npc.velocity.X < 1f && this.npc.direction == 1)
										{
											this.npc.velocity.X = this.npc.velocity.X + 0.07f;
											if (this.npc.velocity.X > 1f)
											{
												this.npc.velocity.X = 1f;
											}
										}
										else
										{
											if (this.npc.velocity.X > -1f && this.npc.direction == -1)
											{
												this.npc.velocity.X = this.npc.velocity.X - 0.07f;
												if (this.npc.velocity.X < -1f)
												{
													this.npc.velocity.X = -1f;
												}
											}
										}
									}
								}
							}
						}
						if (this.npc.type == 109 && Main.netMode != 1 && !Main.player[this.npc.target].dead)
						{
							if (this.npc.justHit)
							{
								this.npc.ai[2] = 0f;
							}
							this.npc.ai[2] += 1f;
							if (this.npc.ai[2] > 450f)
							{
								Vector2 vector9 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f - (float)(this.npc.direction * 24), this.npc.position.Y + 4f);
								int num46 = 3 * this.npc.direction;
								int num47 = -5;
								int num48 = Projectile.NewProjectile(vector9.X, vector9.Y, (float)num46, (float)num47, 75, 0, 0f, Main.myPlayer);
								Main.projectile[num48].timeLeft = 300;
								this.npc.ai[2] = 0f;
							}
						}
						bool flag4 = false;
						if (this.npc.velocity.Y == 0f)
						{
							int num49 = (int)(this.npc.position.Y + (float)this.npc.height + 8f) / 16;
							int num50 = (int)this.npc.position.X / 16;
							int num51 = (int)(this.npc.position.X + (float)this.npc.width) / 16;
							for (int l = num50; l <= num51; l++)
							{
								if (Main.tile[l, num49] == null)
								{
									return;
								}
								if (Main.tile[l, num49].active && Main.tileSolid[(int)Main.tile[l, num49].type])
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							int num52 = (int)((this.npc.position.X + (float)(this.npc.width / 2) + (float)(15 * this.npc.direction)) / 16f);
							int num53 = (int)((this.npc.position.Y + (float)this.npc.height - 15f) / 16f);
							if (this.npc.type == 109)
							{
								num52 = (int)((this.npc.position.X + (float)(this.npc.width / 2) + (float)((this.npc.width / 2 + 16) * this.npc.direction)) / 16f);
							}
							if (Main.tile[num52, num53] == null)
							{
								Main.tile[num52, num53] = new Tile();
							}
							if (Main.tile[num52, num53 - 1] == null)
							{
								Main.tile[num52, num53 - 1] = new Tile();
							}
							if (Main.tile[num52, num53 - 2] == null)
							{
								Main.tile[num52, num53 - 2] = new Tile();
							}
							if (Main.tile[num52, num53 - 3] == null)
							{
								Main.tile[num52, num53 - 3] = new Tile();
							}
							if (Main.tile[num52, num53 + 1] == null)
							{
								Main.tile[num52, num53 + 1] = new Tile();
							}
							if (Main.tile[num52 + this.npc.direction, num53 - 1] == null)
							{
								Main.tile[num52 + this.npc.direction, num53 - 1] = new Tile();
							}
							if (Main.tile[num52 + this.npc.direction, num53 + 1] == null)
							{
								Main.tile[num52 + this.npc.direction, num53 + 1] = new Tile();
							}
							if (Main.tile[num52, num53 - 1].active && Main.tile[num52, num53 - 1].type == 10 && flag3)
							{
								this.npc.ai[2] += 1f;
								this.npc.ai[3] = 0f;
								if (this.npc.ai[2] >= 60f)
								{
									if (!Main.bloodMoon && (this.npc.type == 3 || this.npc.type == 132))
									{
										this.npc.ai[1] = 0f;
									}
									this.npc.velocity.X = 0.5f * -(float)this.npc.direction;
									this.npc.ai[1] += 1f;
									if (this.npc.type == 27)
									{
										this.npc.ai[1] += 1f;
									}
									if (this.npc.type == 31)
									{
										this.npc.ai[1] += 6f;
									}
									this.npc.ai[2] = 0f;
									bool flag5 = false;
									if (this.npc.ai[1] >= 10f)
									{
										flag5 = true;
										this.npc.ai[1] = 10f;
									}
									WorldGen.KillTile(num52, num53 - 1, true, false, false);
									if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
									{
										if (this.npc.type == 26)
										{
											WorldGen.KillTile(num52, num53 - 1, false, false, false);
											if (Main.netMode == 2)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num52, (float)(num53 - 1), 0f, 0);
											}
										}
										else
										{
											bool flag6 = WorldGen.OpenDoor(num52, num53, this.npc.direction);
											if (!flag6)
											{
												this.npc.ai[3] = (float)num17;
												this.npc.netUpdate = true;
											}
											if (Main.netMode == 2 && flag6)
											{
												NetMessage.SendData(19, -1, -1, "", 0, (float)num52, (float)num53, (float)this.npc.direction, 0);
											}
										}
									}
								}
							}
							else
							{
								if ((this.npc.velocity.X < 0f && this.npc.spriteDirection == -1) || (this.npc.velocity.X > 0f && this.npc.spriteDirection == 1))
								{
									if (Main.tile[num52, num53 - 2].active && Main.tileSolid[(int)Main.tile[num52, num53 - 2].type])
									{
										if (Main.tile[num52, num53 - 3].active && Main.tileSolid[(int)Main.tile[num52, num53 - 3].type])
										{
											this.npc.velocity.Y = -8f;
											this.npc.netUpdate = true;
										}
										else
										{
											this.npc.velocity.Y = -7f;
											this.npc.netUpdate = true;
										}
									}
									else
									{
										if (Main.tile[num52, num53 - 1].active && Main.tileSolid[(int)Main.tile[num52, num53 - 1].type])
										{
											this.npc.velocity.Y = -6f;
											this.npc.netUpdate = true;
										}
										else
										{
											if (Main.tile[num52, num53].active && Main.tileSolid[(int)Main.tile[num52, num53].type])
											{
												this.npc.velocity.Y = -5f;
												this.npc.netUpdate = true;
											}
											else
											{
												if (this.npc.directionY < 0 && this.npc.type != 67 && (!Main.tile[num52, num53 + 1].active || !Main.tileSolid[(int)Main.tile[num52, num53 + 1].type]) && (!Main.tile[num52 + this.npc.direction, num53 + 1].active || !Main.tileSolid[(int)Main.tile[num52 + this.npc.direction, num53 + 1].type]))
												{
													this.npc.velocity.Y = -8f;
													this.npc.velocity.X = this.npc.velocity.X * 1.5f;
													this.npc.netUpdate = true;
												}
												else
												{
													if (flag3)
													{
														this.npc.ai[1] = 0f;
														this.npc.ai[2] = 0f;
													}
												}
											}
										}
									}
								}
								if ((this.npc.type == 31 || this.npc.type == 47 || true || this.npc.type == 104) && this.npc.velocity.Y == 0f && Math.Abs(this.npc.position.X + (float)(this.npc.width / 2) - (Main.player[this.npc.target].position.X + (float)(Main.player[this.npc.target].width / 2))) < 100f && Math.Abs(this.npc.position.Y + (float)(this.npc.height / 2) - (Main.player[this.npc.target].position.Y + (float)(Main.player[this.npc.target].height / 2))) < 50f && ((this.npc.direction > 0 && this.npc.velocity.X >= 1f) || (this.npc.direction < 0 && this.npc.velocity.X <= -1f)))
								{
									this.npc.velocity.X = this.npc.velocity.X * 2f;
									if (this.npc.velocity.X > 3f)
									{
										this.npc.velocity.X = 3f;
									}
									if (this.npc.velocity.X < -3f)
									{
										this.npc.velocity.X = -3f;
									}
									this.npc.velocity.Y = -4f;
									this.npc.netUpdate = true;
								}
								if (this.npc.type == 120 && this.npc.velocity.Y < 0f)
								{
									this.npc.velocity.Y = this.npc.velocity.Y * 1.1f;
								}
							}
						}
						else
						{
							if (flag3)
							{
								this.npc.ai[1] = 0f;
								this.npc.ai[2] = 0f;
							}
						}
						if (Main.netMode != 1 && this.npc.type == 120 && this.npc.ai[3] >= (float)num17)
						{
							int num54 = (int)Main.player[this.npc.target].position.X / 16;
							int num55 = (int)Main.player[this.npc.target].position.Y / 16;
							int num56 = (int)this.npc.position.X / 16;
							int num57 = (int)this.npc.position.Y / 16;
							int num58 = 20;
							int num59 = 0;
							bool flag7 = false;
							if (Math.Abs(this.npc.position.X - Main.player[this.npc.target].position.X) + Math.Abs(this.npc.position.Y - Main.player[this.npc.target].position.Y) > 2000f)
							{
								num59 = 100;
								flag7 = true;
							}
							while (!flag7)
							{
								if (num59 >= 100)
								{
									return;
								}
								num59++;
								int num60 = Main.rand.Next(num54 - num58, num54 + num58);
								int num61 = Main.rand.Next(num55 - num58, num55 + num58);
								for (int m = num61; m < num55 + num58; m++)
								{
									if ((m < num55 - 4 || m > num55 + 4 || num60 < num54 - 4 || num60 > num54 + 4) && (m < num57 - 1 || m > num57 + 1 || num60 < num56 - 1 || num60 > num56 + 1) && Main.tile[num60, m].active)
									{
										bool flag8 = true;
										if (this.npc.type == 32 && Main.tile[num60, m - 1].wall == 0)
										{
											flag8 = false;
										}
										else
										{
											if (Main.tile[num60, m - 1].lava)
											{
												flag8 = false;
											}
										}
										if (flag8 && Main.tileSolid[(int)Main.tile[num60, m].type] && !Collision.SolidTiles(num60 - 1, num60 + 1, m - 4, m - 1))
										{
											this.npc.position.X = (float)(num60 * 16 - this.npc.width / 2);
											this.npc.position.Y = (float)(m * 16 - this.npc.height);
											this.npc.netUpdate = true;
											this.npc.ai[3] = -120f;
										}
									}
								}
							}
							return;
						}

			
										
}else if(AIStyle == 1){


if(Main.rand.Next(500)==0){
this.npc.velocity.Y -= 3;
//AIStyle = 0;
}

}else if(AIStyle ==2){
int num = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
						Dust dust = Main.dust[num];
						Dust expr_1A2 = dust;
						expr_1A2.velocity *= 0.3f;
this.npc.position.X = Main.player[Main.myPlayer].position.X;
this.npc.position.Y = Main.player[Main.myPlayer].position.Y - 20;
int num2 = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
						Dust dust2 = Main.dust[num2];
						Dust expr_1A22 = dust2;
						expr_1A22.velocity *= 0.3f;
}else if(AIStyle == 3){


Main.player[this.npc.target].statLife += 5;
Main.player[this.npc.target].HealEffect(5);

Main.PlaySound(3, (int)this.npc.position.X, (int)this.npc.position.Y, 5);


AIStyle = 0;

}else if(AIStyle == 4){

timer2 ++;

if(timer2 == 1){
this.npc.velocity.Y -= 1f;
}else{


if(timer2 == 50 || timer2 == 55 || timer2 == 60){
this.npc.velocity.Y = 0;
int style = Config.projDefs.byName["Flaming Arrow"].type;
int dmg = 15;
int proj = Projectile.NewProjectile(this.npc.position.X, this.npc.position.Y, 10*this.npc.direction, -5, style, dmg, 0, Main.myPlayer)   ;  
}

if(timer2 == 80){
AIStyle = 0;
timer2=0;
}

}

}
}



public void Initialize(){


this.npc.displayName = SetName();

if(this.npc.displayName == "Obsidian"){
this.npc.scale += 0.2f;
this.npc.lifeMax += 25;
this.npc.life += 25;
}

if(ModPlayer.hasPet == false){

ModPlayer.pet = this.npc;
ModPlayer.hasPet = true;
}else{

ModPlayer.pet.StrikeNPC(999,2, this.npc.direction);
ModPlayer.pet = this.npc;
ModPlayer.hasPet = true;

}

}

public void NPCLoot(){
//Main.NewText("dead");
ModPlayer.hasPet = false;

if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Bunny Pet Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Bunny Pet Gore 2", 1f, -1);
}
}



public static string SetName() {
int x = Main.rand.Next(5);
if(x == 0)
	return "Spike";
if(x == 1)
	return "Toby";
if(x == 2)
	return "Rex";
if(x == 3)
	return "Obsidian";
if(x == 4)
	return "Finn";

return "Your Pet !";
}

