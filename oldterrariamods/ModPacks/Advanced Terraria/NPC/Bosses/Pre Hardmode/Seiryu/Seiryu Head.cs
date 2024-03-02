#region AI
public void AI()
{				
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
										if (this.npc.type == Config.npcDefs.byName["Seiryu Head"].type && npc.ai[0] == 0f)
										{
											this.npc.ai[2] = (float)npc.whoAmI;
											this.npc.realLife = npc.whoAmI;
											int num96 = this.npc.whoAmI;
											for (int num97 = 0; num97 < 24; num97++)
											{
												int num98 = Config.npcDefs.byName["Seiryu Body"].type;
												if (num97 == 4 || num97 == 9 || num97 == 14 || num97 == 19)
												{
													num98 = Config.npcDefs.byName["Seiryu Legs"].type;
												}
												else
												{
													if (num97 == 21)
													{
														num98 = Config.npcDefs.byName["Seiryu Body 2"].type;
													}
													else
													{
														if (num97 == 22)
														{
															num98 = Config.npcDefs.byName["Seiryu Body 3"].type;
														}
														else
														{
															if (num97 == 23)
															{
																num98 = Config.npcDefs.byName["Seiryu Tail"].type;
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
									this.npc.rotation = (float)Math.Atan2((double)this.npc.velocity.Y, (double)this.npc.velocity.X) + 1.57f;									
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 59, 0, 0, 50, Color.White, 2f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Seiryu Gore 4", 1f, -1);
        }
}
#endregion