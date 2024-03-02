int resetcooldown = 0;
int index = -1;
int flagcolor = 0;
public void AI()
{

this.npc.dontTakeDamage = true;
//this.npc.timeLeft = 2; //keeps it from dissappearing

Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 0.3f, 0.9f, 0.3f);  


#region alive check
if(!ModWorld.stationExists[1] || ModWorld.stationPosX[1] == -1 || ModWorld.stationPosY[1] == -1)
{
        ModWorld.stationExists[1] = false;
        ModWorld.stationPosX[1] = -1;
        ModWorld.stationPosY[1] = -1;
        this.npc.active = false;
        return;
}
#endregion

#region direction
this.npc.noTileCollide= false;
if(index > -1)
{
    this.npc.spriteDirection = Main.player[index].direction * -1;
}
else
{
if(this.npc.velocity.X > 0f)
{
this.npc.spriteDirection = -1;
}
else
{
if (this.npc.velocity.X < 0f)
{
this.npc.spriteDirection = 1;
}
}
}
#endregion
#region gravity reversal
if(index > -1)
{
    if(Main.player[index].gravDir == -1)
    {
        this.npc.rotation=(float)(Math.PI);
        this.npc.spriteDirection *= -1;
    }
else
{
    this.npc.rotation =0;
}
}
else
{
    this.npc.rotation =0;
}
#endregion

#region check for nonscore
bool noscore=false;
if(index > -1)
{
                                int numz0r = 1;
    
                                Vector2 vectorbunny = new Vector2(ModWorld.stationPosX[numz0r]*16,ModWorld.stationPosY[numz0r]*16);
                                float num196 = this.npc.position.X + (float)(this.npc.width/ 2) - vectorbunny.X;
                                float num195 = this.npc.position.Y + (float)(this.npc.height / 2) - vectorbunny.Y;
                                float num194 = (float)Math.Sqrt((double)(num196 * num196 + num195 * num195));
                                if(num194 < ModWorld.PointBlockRange)
                                    noscore = true;
                                
}
#endregion

#region something

#region checkz0rs
if(index > -1)
{
#region should detach
// teams are 1 , 2 , 3 , 4 for colors , 0 is neutral
if(!Main.player[index].active || Main.player[index].dead || (!Main.player[index].hostile || (Main.player[index].team == 2 || Main.player[index].team == 0)))
{
this.npc.spriteDirection = 1;
this.npc.velocity.X = Main.player[index].direction * 5;
index = -1;
resetcooldown=0;
}
#endregion
}
else
{
#region look for an owner
float range = 500f;
foreach (Player N in Main.player)
{
if (N.active)
{
if (N.hostile)
{
if (!N.dead)
{
if (N.team != 2 && N.team != 0)
{
                                Vector2 vectorbunny = new Vector2(N.position.X + (float)N.width * 0.5f, N.position.Y + (float)N.height * 0.5f);
                                float num196 = this.npc.position.X + (float)(this.npc.width/ 2) - vectorbunny.X;
                                float num195 = this.npc.position.Y + (float)(this.npc.height / 2) - vectorbunny.Y;
                                float num194 = (float)Math.Sqrt((double)(num196 * num196 + num195 * num195));
                                if (num194 <= range)
                                {

                                    range = num194;
                                    if (num194 <= ModWorld.RangeToScore)
                                    {
                                        index=N.whoAmi;
                                    }
                                }
}
}
}
}
}
if(index > -1)
    Main.NewText(""+Main.player[index].name+" Has Captured the Green Flag!");
#endregion
}
#endregion

#region movements
if(index > -1)
{
#region if has a player
this.npc.position.X=Main.player[index].position.X-(22.5f/2);
this.npc.position.Y=Main.player[index].position.Y-15;
#region add this
if (this.npc.spriteDirection == 1)
this.npc.position.X-=22;
#endregion
#region add this
if ((Main.player[index].direction == -1 && Main.player[index].gravDir == 1) || (Main.player[index].direction == 1 && Main.player[index].gravDir == -1))
this.npc.position.X+=Main.player[index].width;
this.npc.position.Y-=15;
#endregion
#region and this
if(Main.player[index].gravDir == -1)
{
this.npc.position.Y+=45;
}
#endregion
this.npc.velocity.X=0;
this.npc.velocity.Y=0;
#endregion
bool shit = false;
#region Check for scoring!
if(!noscore)
{
for (int i = 0; i < 4; i++)
{
if (i != 1 && i == Main.player[index].team-1 && ModWorld.stationExists[i])
    {
			                    Vector2 vectorbunny = new Vector2(ModWorld.stationPosX[i]*16f,ModWorld.stationPosY[i]*16f);
                                float num196 = this.npc.position.X + (float)(this.npc.width/ 2) - vectorbunny.X;
                                float num195 = this.npc.position.Y + (float)(this.npc.height / 2) - vectorbunny.Y;
                                float num194 = (float)Math.Sqrt((double)(num196 * num196 + num195 * num195));
                                if (num194 <= 50)
                                {
shit = true;
#region announce score!
ModWorld.stationScore[i]++;
string text = "The ";
if (i == 0) text+= "Red";
if (i == 1) text+= "Green";
if (i == 2) text+= "Blue";
if (i == 3) text+= "Yellow";
text+=" Team has Scored! " + ModWorld.stationScore[i];
Main.NewText(text);
#endregion

                                }
    }
}
if(shit)
{
index = -1;
resetcooldown = 0;
this.npc.position.X = ModWorld.stationPosX[1]*16;
this.npc.position.Y = ModWorld.stationPosY[1]*16;
#region add this
if (this.npc.spriteDirection == -1)
this.npc.position.X+=20;
this.npc.position.Y-=15;
#endregion
}
}
#endregion
}
else
{
#region has no player
if(resetcooldown==ModWorld.TimeFree)
{
    #region reset flag to station
this.npc.spriteDirection = 1;
resetcooldown = -1;
this.npc.position.X = ModWorld.stationPosX[1]*16;
this.npc.position.Y = ModWorld.stationPosY[1]*16;
#region add this
if (this.npc.spriteDirection == -1)
this.npc.position.X+=20;
this.npc.position.Y-=15;
#endregion
#endregion
}
else
{
    if(resetcooldown > -1)
{
    resetcooldown++;
    #region fall to ground
#region gravity affects this one!
                    this.npc.velocity.Y = this.npc.velocity.Y + 0.4f;
                    if (this.npc.velocity.Y > 10f)
                    {
                        this.npc.velocity.Y = 10f;
                    }
#endregion
#region make a slowdown to a full stop
                            this.npc.velocity.X = this.npc.velocity.X * 0.9f;
                            if ((double)this.npc.velocity.X >= -0.08 && (double)this.npc.velocity.X <= 0.08)
                            {
                                this.npc.velocity.X = 0f;
                            }
                            #endregion
#endregion
}
}
#endregion
}
#endregion

#endregion

//this.npc.velocity.X = 0f;
//this.npc.velocity.Y = 0f;
return;
}

public void Kill()
{
    if(ModWorld.stationExists[1])
    NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Green Flag",0);
}