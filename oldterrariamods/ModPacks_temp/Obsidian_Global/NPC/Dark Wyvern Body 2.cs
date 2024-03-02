public void DealtNPC(double damage, Player player){

if(this.npc.name=="Dark Wyvern Body 2"|| this.npc.name=="Dark Wyvern Body"|| this.npc.name=="Dark Wyvern Body 3"|| this.npc.name=="Dark Wyvern Head"|| this.npc.name=="Dark Wyvern Tail" || this.npc.name=="Dark Wyvern Legs"){

if(Main.rand.Next(80)==0){
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
NPC.NewNPC((int)this.npc.position.X-300,(int) this.npc.position.Y-250, Config.npcDefs.byName["Harpy"].type, 0);
NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y-250, Config.npcDefs.byName["Harpy"].type, 0);

}else if(Main.rand.Next(50)==0){
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
int style = Config.projDefs.byName["WyvernSkill"].type;
int dmg = 25;

   Projectile.NewProjectile(this.npc.position.X-150, this.npc.position.Y-950, 2, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.npc.position.X-100, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X-50, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ; 

   Projectile.NewProjectile(this.npc.position.X, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  

   Projectile.NewProjectile(this.npc.position.X+50, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+100, this.npc.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.npc.position.X+150, this.npc.position.Y-550, -2, Main.rand.Next(10)+5, style, dmg, 0, Main.myPlayer)   ;  

}else if(Main.rand.Next(50)==0){
Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 0);
Projectile.NewProjectile(this.npc.position.X, this.npc.position.Y, 0, 5, Config.projDefs.byName["WyvernBomb"].type, 0, 0, Main.myPlayer)   ;  

}

}
}
public void AI(){
							
									
									
									if (this.npc.target < 0 || this.npc.target == 255 || Main.player[this.npc.target].dead)
									{
										this.npc.TargetClosest(true);
									}
									if (Main.player[this.npc.target].dead && this.npc.timeLeft > 300)
									{
										this.npc.timeLeft = 300;
									}
									if (Main.netMode != 1)
									{
										if (this.npc.type == Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.ai[0] == 0f)
										{
											this.npc.ai[3] = (float)this.npc.whoAmI;
											this.npc.realLife = this.npc.whoAmI;
											int num96 = this.npc.whoAmI;
											for (int num97 = 0; num97 < 24; num97++)
											{
//Main.NewText(" has awoken!"+num97, 175, 75, 255);
												int num98 = Config.npcDefs.byName["Dark Wyvern Body"].type;
												if (num97 == 4 || num97 == 9 || num97 == 14 || num97 == 19)
												{
													num98 = Config.npcDefs.byName["Dark Wyvern Legs"].type;
												}
												else
												{
													if (num97 == 21)
													{
														num98 = Config.npcDefs.byName["Dark Wyvern Body 2"].type;
													}
													else
													{
														if (num97 == 22)
														{
															num98 = Config.npcDefs.byName["Dark Wyvern Body 3"].type;
														}
														else
														{
															if (num97 == 23)
															{
																num98 = Config.npcDefs.byName["Dark Wyvern Tail"].type;
															}
														}
													}
												}
												int num99 = NPC.NewNPC((int)(this.npc.position.X + (float)(this.npc.width / 2)), (int)(this.npc.position.Y + (float)this.npc.height), num98, this.npc.whoAmI);
												Main.npc[num99].ai[3] = (float)this.npc.whoAmI;
												Main.npc[num99].realLife = this.npc.whoAmI;
												Main.npc[num99].ai[1] = (float)num96;
												Main.npc[num96].ai[0] = (float)num99;
												NetMessage.SendData(23, -1, -1, "", num99, 0f, 0f, 0f, 0);
												num96 = num99;
											}
										}
									
										
										if (!this.npc.active && Main.netMode == 2)
										{
											NetMessage.SendData(28, -1, -1, "", this.npc.whoAmI, -1f, 0f, 0f, 0);
										}
									}
									int num107 = (int)(this.npc.position.X / 16f) - 1;
									int num108 = (int)((this.npc.position.X + (float)this.npc.width) / 16f) + 2;
									int num109 = (int)(this.npc.position.Y / 16f) - 1;
									int num110 = (int)((this.npc.position.Y + (float)this.npc.height) / 16f) + 2;
									if (num107 < 0)
									{
										num107 = 0;
									}
									if (num108 > Main.maxTilesX)
									{
										num108 = Main.maxTilesX;
									}
									if (num109 < 0)
									{
										num109 = 0;
									}
									if (num110 > Main.maxTilesY)
									{
										num110 = Main.maxTilesY;
									}
									bool flag11 = false;
									if (this.npc.type >= Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.type <= Config.npcDefs.byName["Dark Wyvern Tail"].type)
									{
										flag11 = true;
									}
									if (!flag11)
									{
										for (int num111 = num107; num111 < num108; num111++)
										{
											for (int num112 = num109; num112 < num110; num112++)
											{
												if (Main.tile[num111, num112] != null && ((Main.tile[num111, num112].active && (Main.tileSolid[(int)Main.tile[num111, num112].type] || (Main.tileSolidTop[(int)Main.tile[num111, num112].type] && Main.tile[num111, num112].frameY == 0))) || Main.tile[num111, num112].liquid > 64))
												{
													Vector2 vector13;
													vector13.X = (float)(num111 * 16);
													vector13.Y = (float)(num112 * 16);
													if (this.npc.position.X + (float)this.npc.width > vector13.X && this.npc.position.X < vector13.X + 16f && this.npc.position.Y + (float)this.npc.height > vector13.Y && this.npc.position.Y < vector13.Y + 16f)
													{
														flag11 = true;
														if (Main.rand.Next(100) == 0 && this.npc.type != 117 && Main.tile[num111, num112].active)
														{
															WorldGen.KillTile(num111, num112, true, true, false);
														}
														if (Main.netMode != 1 && Main.tile[num111, num112].type == 2)
														{
															byte arg_6FE2_0 = (byte)Main.tile[num111, num112 - 1].type;
														}
													}
												}
											}
										}
									}

									if (this.npc.type >= Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.type <= Config.npcDefs.byName["Dark Wyvern Tail"].type)
									{
										if (this.npc.velocity.X < 0f)
										{
											this.npc.spriteDirection = 1;
										}
										else
										{
											if (this.npc.velocity.X > 0f)
											{
												this.npc.spriteDirection = -1;
											}
										}
									}
									float num115 = 8f;
									float num116 = 0.07f;
									if (this.npc.type == 95)
									{
										num115 = 5.5f;
										num116 = 0.045f;
									}
									if (this.npc.type == 10)
									{
										num115 = 6f;
										num116 = 0.05f;
									}
									if (this.npc.type == 13)
									{
										num115 = 10f;
										num116 = 0.07f;
									}
									if (this.npc.type == Config.npcDefs.byName["Dark Wyvern Head"].type)
									{
										num115 = 11f;
										num116 = 0.25f;
									}
									if (this.npc.type == 117 && Main.wof >= 0)
									{
										float num117 = (float)Main.npc[Main.wof].life / (float)Main.npc[Main.wof].lifeMax;
										if ((double)num117 < 0.5)
										{
											num115 += 1f;
											num116 += 0.1f;
										}
										if ((double)num117 < 0.25)
										{
											num115 += 1f;
											num116 += 0.1f;
										}
										if ((double)num117 < 0.1)
										{
											num115 += 2f;
											num116 += 0.1f;
										}
									}
									Vector2 vector14 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
									float num118 = Main.player[this.npc.target].position.X + (float)(Main.player[this.npc.target].width / 2);
									float num119 = Main.player[this.npc.target].position.Y + (float)(Main.player[this.npc.target].height / 2);
									num118 = (float)((int)(num118 / 16f) * 16);
									num119 = (float)((int)(num119 / 16f) * 16);
									vector14.X = (float)((int)(vector14.X / 16f) * 16);
									vector14.Y = (float)((int)(vector14.Y / 16f) * 16);
									num118 -= vector14.X;
									num119 -= vector14.Y;
									float num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
									if (this.npc.ai[1] > 0f && this.npc.ai[1] < (float)Main.npc.Length)
									{
										try
										{
											vector14 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
											num118 = Main.npc[(int)this.npc.ai[1]].position.X + (float)(Main.npc[(int)this.npc.ai[1]].width / 2) - vector14.X;
											num119 = Main.npc[(int)this.npc.ai[1]].position.Y + (float)(Main.npc[(int)this.npc.ai[1]].height / 2) - vector14.Y;
										}
										catch
										{
										}
										this.npc.rotation = (float)Math.Atan2((double)num119, (double)num118) + 1.57f;
										num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
										int num121 = this.npc.width;
										if (this.npc.type >= Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.type <= Config.npcDefs.byName["Dark Wyvern Tail"].type)
										{
											num121 = 42;
										}
										num120 = (num120 - (float)num121) / num120;
										num118 *= num120;
										num119 *= num120;
										this.npc.velocity = default(Vector2);
										this.npc.position.X = this.npc.position.X + num118;
										this.npc.position.Y = this.npc.position.Y + num119;
										if (this.npc.type >= Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.type <= Config.npcDefs.byName["Dark Wyvern Tail"].type)
										{
											if (num118 < 0f)
											{
												this.npc.spriteDirection = 1;
												return;
											}
											if (num118 > 0f)
											{
												this.npc.spriteDirection = -1;
												return;
											}
										}
									}
									else
									{
										if (!flag11)
										{
											this.npc.TargetClosest(true);
											this.npc.velocity.Y = this.npc.velocity.Y + 0.11f;
											if (this.npc.velocity.Y > num115)
											{
												this.npc.velocity.Y = num115;
											}
											if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num115 * 0.4)
											{
												if (this.npc.velocity.X < 0f)
												{
													this.npc.velocity.X = this.npc.velocity.X - num116 * 1.1f;
												}
												else
												{
													this.npc.velocity.X = this.npc.velocity.X + num116 * 1.1f;
												}
											}
											else
											{
												if (this.npc.velocity.Y == num115)
												{
													if (this.npc.velocity.X < num118)
													{
														this.npc.velocity.X = this.npc.velocity.X + num116;
													}
													else
													{
														if (this.npc.velocity.X > num118)
														{
															this.npc.velocity.X = this.npc.velocity.X - num116;
														}
													}
												}
												else
												{
													if (this.npc.velocity.Y > 4f)
													{
														if (this.npc.velocity.X < 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X + num116 * 0.9f;
														}
														else
														{
															this.npc.velocity.X = this.npc.velocity.X - num116 * 0.9f;
														}
													}
												}
											}
										}
										else
										{
											if (this.npc.type != Config.npcDefs.byName["Dark Wyvern Head"].type && this.npc.type != 117 && this.npc.soundDelay == 0)
											{
												float num122 = num120 / 40f;
												if (num122 < 10f)
												{
													num122 = 10f;
												}
												if (num122 > 20f)
												{
													num122 = 20f;
												}
												this.npc.soundDelay = (int)num122;
												Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 1);
											}
											num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
											float num123 = Math.Abs(num118);
											float num124 = Math.Abs(num119);
											float num125 = num115 / num120;
											num118 *= num125;
											num119 *= num125;

											bool flag14 = false;
											if (this.npc.type == Config.npcDefs.byName["Dark Wyvern Head"].type)
											{
												if (((this.npc.velocity.X > 0f && num118 < 0f) || (this.npc.velocity.X < 0f && num118 > 0f) || (this.npc.velocity.Y > 0f && num119 < 0f) || (this.npc.velocity.Y < 0f && num119 > 0f)) && Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) > num116 / 2f && num120 < 300f)
												{
													flag14 = true;
													if (Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) < num115)
													{
														this.npc.velocity *= 1.1f;
													}
												}
												if (this.npc.position.Y > Main.player[this.npc.target].position.Y || (double)(Main.player[this.npc.target].position.Y / 16f) > Main.worldSurface || Main.player[this.npc.target].dead)
												{
													flag14 = true;
													if (Math.Abs(this.npc.velocity.X) < num115 / 2f)
													{
														if (this.npc.velocity.X == 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X - (float)this.npc.direction;
														}
														this.npc.velocity.X = this.npc.velocity.X * 1.1f;
													}
													else
													{
														if (this.npc.velocity.Y > -num115)
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num116;
														}
													}
												}
											}
											if (!flag14)
											{
												if ((this.npc.velocity.X > 0f && num118 > 0f) || (this.npc.velocity.X < 0f && num118 < 0f) || (this.npc.velocity.Y > 0f && num119 > 0f) || (this.npc.velocity.Y < 0f && num119 < 0f))
												{
													if (this.npc.velocity.X < num118)
													{
														this.npc.velocity.X = this.npc.velocity.X + num116;
													}
													else
													{
														if (this.npc.velocity.X > num118)
														{
															this.npc.velocity.X = this.npc.velocity.X - num116;
														}
													}
													if (this.npc.velocity.Y < num119)
													{
														this.npc.velocity.Y = this.npc.velocity.Y + num116;
													}
													else
													{
														if (this.npc.velocity.Y > num119)
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num116;
														}
													}
													if ((double)Math.Abs(num119) < (double)num115 * 0.2 && ((this.npc.velocity.X > 0f && num118 < 0f) || (this.npc.velocity.X < 0f && num118 > 0f)))
													{
														if (this.npc.velocity.Y > 0f)
														{
															this.npc.velocity.Y = this.npc.velocity.Y + num116 * 2f;
														}
														else
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num116 * 2f;
														}
													}
													if ((double)Math.Abs(num118) < (double)num115 * 0.2 && ((this.npc.velocity.Y > 0f && num119 < 0f) || (this.npc.velocity.Y < 0f && num119 > 0f)))
													{
														if (this.npc.velocity.X > 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X + num116 * 2f;
														}
														else
														{
															this.npc.velocity.X = this.npc.velocity.X - num116 * 2f;
														}
													}
												}
												else
												{
													if (num123 > num124)
													{
														if (this.npc.velocity.X < num118)
														{
															this.npc.velocity.X = this.npc.velocity.X + num116 * 1.1f;
														}
														else
														{
															if (this.npc.velocity.X > num118)
															{
																this.npc.velocity.X = this.npc.velocity.X - num116 * 1.1f;
															}
														}
														if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num115 * 0.5)
														{
															if (this.npc.velocity.Y > 0f)
															{
																this.npc.velocity.Y = this.npc.velocity.Y + num116;
															}
															else
															{
																this.npc.velocity.Y = this.npc.velocity.Y - num116;
															}
														}
													}
													else
													{
														if (this.npc.velocity.Y < num119)
														{
															this.npc.velocity.Y = this.npc.velocity.Y + num116 * 1.1f;
														}
														else
														{
															if (this.npc.velocity.Y > num119)
															{
																this.npc.velocity.Y = this.npc.velocity.Y - num116 * 1.1f;
															}
														}
														if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num115 * 0.5)
														{
															if (this.npc.velocity.X > 0f)
															{
																this.npc.velocity.X = this.npc.velocity.X + num116;
															}
															else
															{
																this.npc.velocity.X = this.npc.velocity.X - num116;
															}
														}
													}
												}
											}
										}
										this.npc.rotation = (float)Math.Atan2((double)this.npc.velocity.Y, (double)this.npc.velocity.X) + 1.57f;
									}
								}