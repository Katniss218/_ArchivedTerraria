public void DrawBeforeLegs(Player P,SpriteBatch SP,ref bool LetDraw,ref Color Legs,ref Color Shoes,ref Color Grieves) 
{
        Grieves = Legs; //makes the armor have the color of the shirt
        EasyDraw(P,SP,"RC Tibian Male Archer Boots",2,0,0,0,0,Shoes,true);
}

//public void DrawAfterLegs(Player P,SpriteBatch SP,ref bool LetDraw,ref Color Legs,ref Color Shoes,ref Color Grieves) 
//{
//        EasyDraw(P,SP,"RC Tibian Archer Boots",1,0,0,0,0,Shoes,true);
//}


#region EasyDraw p sp n k 

public void EasyDraw(Player P , SpriteBatch SP , string Name , int kind,int xoff = 0,int yoff = 0,int xextend = 0,int xmuster = 0,Color b = default(Color),bool over = false)
{
    //Vector2 OffsetOf =new Vector2(P.direction*2,0);
    Vector2 OffsetOf =new Vector2(P.direction*xoff,P.gravDir*yoff);
    Texture2D QB =  Main.goreTexture[Config.goreID[Name]];
    Rectangle CompareReference = P.legFrame;
    if(kind == 0) CompareReference = P.headFrame;
    if(kind == 1) CompareReference = P.bodyFrame;
    if(kind == 2) CompareReference = P.legFrame;
    CompareReference.Width+=xextend;
    CompareReference.X+= xmuster;
    SpriteEffects effects;
    if (P.gravDir == 1f)
    {
        if (P.direction == 1)
        {
            effects = SpriteEffects.None;
        }
        else
        {
            effects = SpriteEffects.FlipHorizontally;
        }
    }
    else
    {
        if (P.direction == 1)
        {
            effects = SpriteEffects.FlipVertically;
        }
        else
        {
            effects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
        }
    }                        
    if(b == default(Color) && !over) b = Color.White;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    Vector2 ID = new Vector2(QB.Width,QB.Height);
    Color Lighter = P.GetImmuneAlpha(Lighting.GetColor((int)PC.X / 16, (int)PC.Y / 16, b));
    if(over) Lighter = b;
    Vector2 origin = new Vector2((float)CompareReference.Width * 0.5f, (float)CompareReference.Height * 0.5f);

    Vector2 Offset = new Vector2(-0*P.direction,0);
    SP.Draw(
    QB, 
    new Vector2((int)(PC.X - Main.screenPosition.X - CompareReference.Width / 2), 
    (int)(P.position.Y - Main.screenPosition.Y + P.height - CompareReference.Height + 4f))
    + P.bodyPosition +Offset +OffsetOf
    + new Vector2((float)(CompareReference.Width / 2), (float)(CompareReference.Height / 2)),
    new Rectangle?(CompareReference), 
    Lighter, 
    P.bodyRotation, 
    origin, 
    1f, 
    effects, 
    0f);
}
#endregion