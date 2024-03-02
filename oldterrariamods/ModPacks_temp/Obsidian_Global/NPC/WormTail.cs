int timer =  0;

public void AI() {
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

}else if ( Main.npc[i].type!=Config.npcDefs.byName["WormHead"].type &&  Main.npc[i].type!=Config.npcDefs.byName["WormBody"].type && Main.npc[i].type!=Config.npcDefs.byName["WormTail"].type && Main.npc[i].townNPC == false ){


if(timer==0){
Main.npc[i].StrikeNPC(5,5, this.npc.direction);
timer--;
}
}
}

if (this.npc.type == 117 && this.npc.localAI[1] == 0f)
									{
										this.npc.localAI[1] = 1f;
										Main.PlaySound(4, (int)this.npc.position.X, (int)this.npc.position.Y, 13);
										int num138 = 1;
										if (this.npc.velocity.X < 0f)
										{
											num138 = -1;
										}
										for (int num139 = 0; num139 < 20; num139++)
										{
											Vector2 vector24 = new Vector2(this.npc.position.X - 20f, this.npc.position.Y - 20f);
											int num140 = this.npc.width + 40;
											int num141 = this.npc.height + 40;
											int num142 = 5;
											float speedX8 = (float)(num138 * 8);
											float speedY12 = -1f;
											int num143 = 0;
											Color newColor8 = default(Color);
											Dust.NewDust(vector24, num140, num141, num142, speedX8, speedY12, num143, newColor8, 1f);
										}
									}
									if (this.npc.type >= 13 && this.npc.type <= 15)
									{
										this.npc.realLife = -1;
									}
									else
									{
										if (this.npc.ai[3] > 0f)
										{
											this.npc.realLife = (int)this.npc.ai[3];
										}
									}
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
										
										if ((this.npc.type == 7 || this.npc.type == 8 || this.npc.type == 10 || this.npc.type == Config.npcDefs.byName["WormBody"].type || this.npc.type == 13 || this.npc.type == 14 || this.npc.type == 39 || this.npc.type == 40 || this.npc.type == 95 || this.npc.type == 96 || this.npc.type == 98 || this.npc.type == 99 || this.npc.type == 117 || this.npc.type == 118) && this.npc.ai[0] == 0f)
										{
											if (this.npc.type == 7 || this.npc.type == 10 || this.npc.type == 13 || this.npc.type == 39 || this.npc.type == 95 || this.npc.type == 98 || this.npc.type == 117)
											{
												if (this.npc.type < 13 || this.npc.type > 15)
												{
													this.npc.ai[3] = (float)this.npc.whoAmI;
													this.npc.realLife = this.npc.whoAmI;
												}
												this.npc.ai[2] = (float)Main.rand.Next(8, 13);
												if (this.npc.type == 10)
												{
													this.npc.ai[2] = (float)Main.rand.Next(4, 7);
												}
												if (this.npc.type == 13)
												{
													this.npc.ai[2] = (float)Main.rand.Next(45, 56);
												}
												if (this.npc.type == 39)
												{
													this.npc.ai[2] = (float)Main.rand.Next(13, 19);
												}
												if (this.npc.type == 95)
												{
													this.npc.ai[2] = (float)Main.rand.Next(6, 13);
												}
												if (this.npc.type == 98)
												{
													this.npc.ai[2] = (float)Main.rand.Next(20, 26);
												}
												if (this.npc.type == 117)
												{
													this.npc.ai[2] = (float)Main.rand.Next(3, 6);
												}
												this.npc.ai[0] = (float)NPC.NewNPC((int)(this.npc.position.X + (float)(this.npc.width / 2)), (int)(this.npc.position.Y + (float)this.npc.height),  Config.npcDefs.byName["WormBody"].type, this.npc.whoAmI);
											}
											else
											{
												if ((this.npc.type == 8 || this.npc.type == Config.npcDefs.byName["WormBody"].type || this.npc.type == 14 || this.npc.type == 40 || this.npc.type == 96 || this.npc.type == 99 || this.npc.type == 118) && this.npc.ai[2] > 0f)
												{
													this.npc.ai[0] = (float)NPC.NewNPC((int)(this.npc.position.X + (float)(this.npc.width / 2)), (int)(this.npc.position.Y + (float)this.npc.height),  Config.npcDefs.byName["WormBody"].type, this.npc.whoAmI);
												}
												else
												{
													this.npc.ai[0] = (float)NPC.NewNPC((int)(this.npc.position.X + (float)(this.npc.width / 2)), (int)(this.npc.position.Y + (float)this.npc.height), Config.npcDefs.byName["WormTail"].type, this.npc.whoAmI);
												}
											}
											if (this.npc.type < 13 || this.npc.type > 15)
											{
												Main.npc[(int)this.npc.ai[0]].ai[3] = this.npc.ai[3];
												Main.npc[(int)this.npc.ai[0]].realLife = this.npc.realLife;
											}
											Main.npc[(int)this.npc.ai[0]].ai[1] = (float)this.npc.whoAmI;
											Main.npc[(int)this.npc.ai[0]].ai[2] = this.npc.ai[2] - 1f;
											this.npc.netUpdate = true;
										}
										if ((this.npc.type == 8 || this.npc.type == 9 || this.npc.type == Config.npcDefs.byName["WormBody"].type || this.npc.type == Config.npcDefs.byName["WormTail"].type || this.npc.type == 40 || this.npc.type == 41 || this.npc.type == 96 || this.npc.type == 97 || this.npc.type == 99 || this.npc.type == 100 || (this.npc.type > 87 && this.npc.type <= 92) || this.npc.type == 118 || this.npc.type == 119) && (!Main.npc[(int)this.npc.ai[1]].active || Main.npc[(int)this.npc.ai[1]].aiStyle != this.npc.aiStyle))
										{
											this.npc.life = 0;
											this.npc.HitEffect(0, 10.0);
											this.npc.active = false;
										}
										if ((this.npc.type == 7 || this.npc.type == 8 || this.npc.type == 10 || this.npc.type == Config.npcDefs.byName["WormBody"].type || this.npc.type == 39 || this.npc.type == 40 || this.npc.type == 95 || this.npc.type == 96 || this.npc.type == 98 || this.npc.type == 99 || (this.npc.type >= 87 && this.npc.type < 92) || this.npc.type == 117 || this.npc.type == 118) && (!Main.npc[(int)this.npc.ai[0]].active || Main.npc[(int)this.npc.ai[0]].aiStyle != this.npc.aiStyle))
										{
											this.npc.life = 0;
											this.npc.HitEffect(0, 10.0);
											this.npc.active = false;
										}
										if (this.npc.type == 13 || this.npc.type == 14 || this.npc.type == 15)
										{
											if (!Main.npc[(int)this.npc.ai[1]].active && !Main.npc[(int)this.npc.ai[0]].active)
											{
												this.npc.life = 0;
												this.npc.HitEffect(0, 10.0);
												this.npc.active = false;
											}
											if (this.npc.type == 13 && !Main.npc[(int)this.npc.ai[0]].active)
											{
												this.npc.life = 0;
												this.npc.HitEffect(0, 10.0);
												this.npc.active = false;
											}
											if (this.npc.type == 15 && !Main.npc[(int)this.npc.ai[1]].active)
											{
												this.npc.life = 0;
												this.npc.HitEffect(0, 10.0);
												this.npc.active = false;
											}
											if (this.npc.type == 14 && (!Main.npc[(int)this.npc.ai[1]].active || Main.npc[(int)this.npc.ai[1]].aiStyle != this.npc.aiStyle))
											{
												this.npc.type = 13;
												int num148 = this.npc.whoAmI;
												float num149 = (float)this.npc.life / (float)this.npc.lifeMax;
												float num150 = this.npc.ai[0];
												this.npc.SetDefaults(this.npc.type, -1f, false);
												this.npc.life = (int)((float)this.npc.lifeMax * num149);
												this.npc.ai[0] = num150;
												this.npc.TargetClosest(true);
												this.npc.netUpdate = true;
												this.npc.whoAmI = num148;
											}
											if (this.npc.type == 14 && (!Main.npc[(int)this.npc.ai[0]].active || Main.npc[(int)this.npc.ai[0]].aiStyle != this.npc.aiStyle))
											{
												int num151 = this.npc.whoAmI;
												float num152 = (float)this.npc.life / (float)this.npc.lifeMax;
												float num153 = this.npc.ai[1];
												this.npc.SetDefaults(this.npc.type, -1f, false);
												this.npc.life = (int)((float)this.npc.lifeMax * num152);
												this.npc.ai[1] = num153;
												this.npc.TargetClosest(true);
												this.npc.netUpdate = true;
												this.npc.whoAmI = num151;
											}
											if (this.npc.life == 0)
											{
												bool flag10 = true;
												for (int num154 = 0; num154 < 200; num154++)
												{
													if (Main.npc[num154].active && (Main.npc[num154].type == 13 || Main.npc[num154].type == 14 || Main.npc[num154].type == 15))
													{
														flag10 = false;
														break;
													}
												}
												if (flag10)
												{
													this.npc.boss = true;
													this.npc.NPCLoot();
												}
											}
										}
										if (!this.npc.active && Main.netMode == 2)
										{
											NetMessage.SendData(28, -1, -1, "", this.npc.whoAmI, -1f, 0f, 0f, 0);
										}
									}
									int num155 = (int)(this.npc.position.X / 16f) - 1;
									int num156 = (int)((this.npc.position.X + (float)this.npc.width) / 16f) + 2;
									int num157 = (int)(this.npc.position.Y / 16f) - 1;
									int num158 = (int)((this.npc.position.Y + (float)this.npc.height) / 16f) + 2;
									if (num155 < 0)
									{
										num155 = 0;
									}
									if (num156 > Main.maxTilesX)
									{
										num156 = Main.maxTilesX;
									}
									if (num157 < 0)
									{
										num157 = 0;
									}
									if (num158 > Main.maxTilesY)
									{
										num158 = Main.maxTilesY;
									}
									bool flag11 = false;
									if (this.npc.type >= 87 && this.npc.type <= 92)
									{
										flag11 = true;
									}
									if (!flag11)
									{
										for (int num159 = num155; num159 < num156; num159++)
										{
											for (int num160 = num157; num160 < num158; num160++)
											{
												if (Main.tile[num159, num160] != null && ((Main.tile[num159, num160].active && (Main.tileSolid[(int)Main.tile[num159, num160].type] || (Main.tileSolidTop[(int)Main.tile[num159, num160].type] && Main.tile[num159, num160].frameY == 0))) || Main.tile[num159, num160].liquid > 64))
												{
													Vector2 vector25;
													vector25.X = (float)(num159 * 16);
													vector25.Y = (float)(num160 * 16);
													if (this.npc.position.X + (float)this.npc.width > vector25.X && this.npc.position.X < vector25.X + 16f && this.npc.position.Y + (float)this.npc.height > vector25.Y && this.npc.position.Y < vector25.Y + 16f)
													{
														flag11 = true;
														if (Main.rand.Next(100) == 0 && this.npc.type != 117 && Main.tile[num159, num160].active)
														{
															WorldGen.KillTile(num159, num160, true, true, false);
														}
														if (Main.netMode != 1 && Main.tile[num159, num160].type == 2)
														{
															byte arg_7474_0 = (byte)Main.tile[num159, num160 - 1].type;
														}
													}
												}
											}
										}
									}
									if (!flag11 && (this.npc.type == 7 || this.npc.type == 10 || this.npc.type == 13 || this.npc.type == 39 || this.npc.type == 95 || this.npc.type == 98 || this.npc.type == 117))
									{
										Rectangle rectangle = new Rectangle((int)this.npc.position.X, (int)this.npc.position.Y, this.npc.width, this.npc.height);
										int num161 = 1000;
										bool flag12 = true;
										for (int num162 = 0; num162 < 255; num162++)
										{
											if (Main.player[num162].active)
											{
												Rectangle rectangle2 = new Rectangle((int)Main.player[num162].position.X - num161, (int)Main.player[num162].position.Y - num161, num161 * 2, num161 * 2);
												if (rectangle.Intersects(rectangle2))
												{
													flag12 = false;
													break;
												}
											}
										}
										if (flag12)
										{
											flag11 = true;
										}
									}
									if (this.npc.type >= 87 && this.npc.type <= 92)
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
									float num163 = 8f;
									float num164 = 0.07f;
									if (this.npc.type == 95)
									{
										num163 = 5.5f;
										num164 = 0.045f;
									}
									if (this.npc.type == 10)
									{
										num163 = 6f;
										num164 = 0.05f;
									}
									if (this.npc.type == 13)
									{
										num163 = 10f;
										num164 = 0.07f;
									}
									if (this.npc.type == 87)
									{
										num163 = 11f;
										num164 = 0.25f;
									}
									if (this.npc.type == 117 && Main.wof >= 0)
									{
										float num165 = (float)Main.npc[Main.wof].life / (float)Main.npc[Main.wof].lifeMax;
										if ((double)num165 < 0.5)
										{
											num163 += 1f;
											num164 += 0.1f;
										}
										if ((double)num165 < 0.25)
										{
											num163 += 1f;
											num164 += 0.1f;
										}
										if ((double)num165 < 0.1)
										{
											num163 += 2f;
											num164 += 0.1f;
										}
									}
									Vector2 vector26 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
									float num166 = Main.player[this.npc.target].position.X + (float)(Main.player[this.npc.target].width / 2);
									float num167 = Main.player[this.npc.target].position.Y + (float)(Main.player[this.npc.target].height / 2);
									num166 = (float)((int)(num166 / 16f) * 16);
									num167 = (float)((int)(num167 / 16f) * 16);
									vector26.X = (float)((int)(vector26.X / 16f) * 16);
									vector26.Y = (float)((int)(vector26.Y / 16f) * 16);
									num166 -= vector26.X;
									num167 -= vector26.Y;
									float num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
									if (this.npc.ai[1] > 0f && this.npc.ai[1] < (float)Main.npc.Length)
									{
										try
										{
											vector26 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
											num166 = Main.npc[(int)this.npc.ai[1]].position.X + (float)(Main.npc[(int)this.npc.ai[1]].width / 2) - vector26.X;
											num167 = Main.npc[(int)this.npc.ai[1]].position.Y + (float)(Main.npc[(int)this.npc.ai[1]].height / 2) - vector26.Y;
										}
										catch
										{
										}
										this.npc.rotation = (float)Math.Atan2((double)num167, (double)num166) + 1.57f;
										num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
										int num169 = this.npc.width;
										if (this.npc.type >= 87 && this.npc.type <= 92)
										{
											num169 = 42;
										}
										num168 = (num168 - (float)num169) / num168;
										num166 *= num168;
										num167 *= num168;
										this.npc.velocity = default(Vector2);
										this.npc.position.X = this.npc.position.X + num166;
										this.npc.position.Y = this.npc.position.Y + num167;
										if (this.npc.type >= 87 && this.npc.type <= 92)
										{
											if (num166 < 0f)
											{
												this.npc.spriteDirection = 1;
												return;
											}
											if (num166 > 0f)
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
											if (this.npc.velocity.Y > num163)
											{
												this.npc.velocity.Y = num163;
											}
											if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num163 * 0.4)
											{
												if (this.npc.velocity.X < 0f)
												{
													this.npc.velocity.X = this.npc.velocity.X - num164 * 1.1f;
												}
												else
												{
													this.npc.velocity.X = this.npc.velocity.X + num164 * 1.1f;
												}
											}
											else
											{
												if (this.npc.velocity.Y == num163)
												{
													if (this.npc.velocity.X < num166)
													{
														this.npc.velocity.X = this.npc.velocity.X + num164;
													}
													else
													{
														if (this.npc.velocity.X > num166)
														{
															this.npc.velocity.X = this.npc.velocity.X - num164;
														}
													}
												}
												else
												{
													if (this.npc.velocity.Y > 4f)
													{
														if (this.npc.velocity.X < 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X + num164 * 0.9f;
														}
														else
														{
															this.npc.velocity.X = this.npc.velocity.X - num164 * 0.9f;
														}
													}
												}
											}
										}
										else
										{
											if (this.npc.type != 87 && this.npc.type != 117 && this.npc.soundDelay == 0)
											{
												float num170 = num168 / 40f;
												if (num170 < 10f)
												{
													num170 = 10f;
												}
												if (num170 > 20f)
												{
													num170 = 20f;
												}
												this.npc.soundDelay = (int)num170;
												Main.PlaySound(15, (int)this.npc.position.X, (int)this.npc.position.Y, 1);
											}
											num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
											float num171 = Math.Abs(num166);
											float num172 = Math.Abs(num167);
											float num173 = num163 / num168;
											num166 *= num173;
											num167 *= num173;
											if ((this.npc.type == 13 || this.npc.type == 7) && !Main.player[this.npc.target].zoneEvil)
											{
												bool flag13 = true;
												for (int num174 = 0; num174 < 255; num174++)
												{
													if (Main.player[num174].active && !Main.player[num174].dead && Main.player[num174].zoneEvil)
													{
														flag13 = false;
													}
												}
												if (flag13)
												{
													if (Main.netMode != 1 && (double)(this.npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
													{
														this.npc.active = false;
														int num175 = (int)this.npc.ai[0];
														while (num175 > 0 && num175 < 200 && Main.npc[num175].active && Main.npc[num175].aiStyle == this.npc.aiStyle)
														{
															int num176 = (int)Main.npc[num175].ai[0];
															Main.npc[num175].active = false;
															this.npc.life = 0;
															if (Main.netMode == 2)
															{
																NetMessage.SendData(23, -1, -1, "", num175, 0f, 0f, 0f, 0);
															}
															num175 = num176;
														}
														if (Main.netMode == 2)
														{
															NetMessage.SendData(23, -1, -1, "", this.npc.whoAmI, 0f, 0f, 0f, 0);
														}
													}
													num166 = 0f;
													num167 = num163;
												}
											}
											bool flag14 = false;
											if (this.npc.type == 87)
											{
												if (((this.npc.velocity.X > 0f && num166 < 0f) || (this.npc.velocity.X < 0f && num166 > 0f) || (this.npc.velocity.Y > 0f && num167 < 0f) || (this.npc.velocity.Y < 0f && num167 > 0f)) && Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) > num164 / 2f && num168 < 300f)
												{
													flag14 = true;
													if (Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) < num163)
													{
														this.npc.velocity *= 1.1f;
													}
												}
												if (this.npc.position.Y > Main.player[this.npc.target].position.Y || (double)(Main.player[this.npc.target].position.Y / 16f) > Main.worldSurface || Main.player[this.npc.target].dead)
												{
													flag14 = true;
													if (Math.Abs(this.npc.velocity.X) < num163 / 2f)
													{
														if (this.npc.velocity.X == 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X - (float)this.npc.direction;
														}
														this.npc.velocity.X = this.npc.velocity.X * 1.1f;
													}
													else
													{
														if (this.npc.velocity.Y > -num163)
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num164;
														}
													}
												}
											}
											if (!flag14)
											{
												if ((this.npc.velocity.X > 0f && num166 > 0f) || (this.npc.velocity.X < 0f && num166 < 0f) || (this.npc.velocity.Y > 0f && num167 > 0f) || (this.npc.velocity.Y < 0f && num167 < 0f))
												{
													if (this.npc.velocity.X < num166)
													{
														this.npc.velocity.X = this.npc.velocity.X + num164;
													}
													else
													{
														if (this.npc.velocity.X > num166)
														{
															this.npc.velocity.X = this.npc.velocity.X - num164;
														}
													}
													if (this.npc.velocity.Y < num167)
													{
														this.npc.velocity.Y = this.npc.velocity.Y + num164;
													}
													else
													{
														if (this.npc.velocity.Y > num167)
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num164;
														}
													}
													if ((double)Math.Abs(num167) < (double)num163 * 0.2 && ((this.npc.velocity.X > 0f && num166 < 0f) || (this.npc.velocity.X < 0f && num166 > 0f)))
													{
														if (this.npc.velocity.Y > 0f)
														{
															this.npc.velocity.Y = this.npc.velocity.Y + num164 * 2f;
														}
														else
														{
															this.npc.velocity.Y = this.npc.velocity.Y - num164 * 2f;
														}
													}
													if ((double)Math.Abs(num166) < (double)num163 * 0.2 && ((this.npc.velocity.Y > 0f && num167 < 0f) || (this.npc.velocity.Y < 0f && num167 > 0f)))
													{
														if (this.npc.velocity.X > 0f)
														{
															this.npc.velocity.X = this.npc.velocity.X + num164 * 2f;
														}
														else
														{
															this.npc.velocity.X = this.npc.velocity.X - num164 * 2f;
														}
													}
												}
												else
												{
													if (num171 > num172)
													{
														if (this.npc.velocity.X < num166)
														{
															this.npc.velocity.X = this.npc.velocity.X + num164 * 1.1f;
														}
														else
														{
															if (this.npc.velocity.X > num166)
															{
																this.npc.velocity.X = this.npc.velocity.X - num164 * 1.1f;
															}
														}
														if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num163 * 0.5)
														{
															if (this.npc.velocity.Y > 0f)
															{
																this.npc.velocity.Y = this.npc.velocity.Y + num164;
															}
															else
															{
																this.npc.velocity.Y = this.npc.velocity.Y - num164;
															}
														}
													}
													else
													{
														if (this.npc.velocity.Y < num167)
														{
															this.npc.velocity.Y = this.npc.velocity.Y + num164 * 1.1f;
														}
														else
														{
															if (this.npc.velocity.Y > num167)
															{
																this.npc.velocity.Y = this.npc.velocity.Y - num164 * 1.1f;
															}
														}
														if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num163 * 0.5)
														{
															if (this.npc.velocity.X > 0f)
															{
																this.npc.velocity.X = this.npc.velocity.X + num164;
															}
															else
															{
																this.npc.velocity.X = this.npc.velocity.X - num164;
															}
														}
													}
												}
											}
										}
										this.npc.rotation = (float)Math.Atan2((double)this.npc.velocity.Y, (double)this.npc.velocity.X) + 1.57f;
										if (this.npc.type == 7 || this.npc.type == 10 || this.npc.type == 13 || this.npc.type == 39 || this.npc.type == 95 || this.npc.type == 98 || this.npc.type == 117)
										{
											if (flag11)
											{
												if (this.npc.localAI[0] != 1f)
												{
													this.npc.netUpdate = true;
												}
												this.npc.localAI[0] = 1f;
											}
											else
											{
												if (this.npc.localAI[0] != 0f)
												{
													this.npc.netUpdate = true;
												}
												this.npc.localAI[0] = 0f;
											}
											if (((this.npc.velocity.X > 0f && this.npc.oldVelocity.X < 0f) || (this.npc.velocity.X < 0f && this.npc.oldVelocity.X > 0f) || (this.npc.velocity.Y > 0f && this.npc.oldVelocity.Y < 0f) || (this.npc.velocity.Y < 0f && this.npc.oldVelocity.Y > 0f)) && !this.npc.justHit)
											{
												this.npc.netUpdate = true;
												return;
											}
										}
									}
}