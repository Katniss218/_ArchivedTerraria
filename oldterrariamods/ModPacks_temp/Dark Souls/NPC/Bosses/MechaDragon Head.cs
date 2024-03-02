
public void AI()
{				
									
										this.npc.TargetClosest(true);
									
									if (Main.player[this.npc.target].dead && this.npc.timeLeft > 300)
									{
										this.npc.timeLeft = 300;
									}
									if (Main.netMode != 1)
									{
										if (this.npc.type == Config.npcDefs.byName["MechaDragon Head"].type && npc.ai[0] == 0f)
										{
											this.npc.ai[2] = (float)npc.whoAmI;
											this.npc.realLife = npc.whoAmI;
											int num96 = this.npc.whoAmI;
											for (int num97 = 0; num97 < 24; num97++)
											{
												int num98 = Config.npcDefs.byName["MechaDragon Body"].type;
												if (num97 == 4 || num97 == 9 || num97 == 14 || num97 == 19)
												{
													num98 = Config.npcDefs.byName["MechaDragon Legs"].type;
												}
												else
												{
													if (num97 == 21)
													{
														num98 = Config.npcDefs.byName["MechaDragon Body 2"].type;
													}
													else
													{
														if (num97 == 22)
														{
															num98 = Config.npcDefs.byName["MechaDragon Body 3"].type;
														}
														else
														{
															if (num97 == 23)
															{
																num98 = Config.npcDefs.byName["MechaDragon Tail"].type;
															}
														}
													}
												}
												int num99 = NPC.NewNPC((int)(this.npc.position.X + (float)(this.npc.width / 2)), (int)(this.npc.position.Y + (float)this.npc.height), num98, this.npc.whoAmI);
												Main.npc[num99].ai[2] = (float)this.npc.whoAmI;
												Main.npc[num99].realLife = this.npc.whoAmI;
												Main.npc[num99].ai[1] = (float)num96;
												Main.npc[num96].ai[0] = (float)num99;
												NetMessage.SendData(23, -1, -1, "", num99, 0f, 0f, 0f, 0);
												num96 = num99;
											}
										}
									
										npc.netUpdate=true;
										//NetMessage.SendData(28, -1, -1, "", this.npc.whoAmI, -1f, 0f, 0f, 0);
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

									if (npc.velocity.X < 0f)
									{
										npc.spriteDirection = 1;
									}
									if (npc.velocity.X > 0f)
									{
										npc.spriteDirection = -1;
									}
									
									float num115 = 16f;
									float num116 = 0.4f;
									
									Vector2 vector14 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
									float num118 = Main.rand.Next(-500,500)+Main.player[this.npc.target].position.X + (float)(Main.player[this.npc.target].width / 2);
									float num119 = Main.rand.Next(-500,500)+Main.player[this.npc.target].position.Y + (float)(Main.player[this.npc.target].height / 2);
									num118 = (float)((int)(num118 / 16f) * 16);
									num119 = (float)((int)(num119 / 16f) * 16);
									vector14.X = (float)((int)(vector14.X / 16f) * 16);
									vector14.Y = (float)((int)(vector14.Y / 16f) * 16);
									num118 -= vector14.X;
									num119 -= vector14.Y;
									float num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
									
										float num123 = Math.Abs(num118);
										float num124 = Math.Abs(num119);
										float num125 = num115 / num120;
										num118 *= num125;
										num119 *= num125;

										bool flag14 = false;
										if (((this.npc.velocity.X > 0f && num118 < 0f) || (this.npc.velocity.X < 0f && num118 > 0f) || (this.npc.velocity.Y > 0f && num119 < 0f) || (this.npc.velocity.Y < 0f && num119 > 0f)) && Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) > num116 / 2f && num120 < 300f)
										{
											flag14 = true;
											if (Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) < num115)
											{
												this.npc.velocity *= 1.1f;
											}
										}
										if (this.npc.position.Y > Main.player[this.npc.target].position.Y || Main.player[this.npc.target].dead)
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
								npc.netUpdate=true;

										}
									this.npc.rotation = (float)Math.Atan2((double)this.npc.velocity.Y, (double)this.npc.velocity.X) + 1.57f;
									
									Color color = new Color();
									int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, color, 1.0f);
									Main.dust[dust].noGravity = true;
}


public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){

int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 5.0f);
	Main.dust[dust].noGravity = true;

}
}


