public static void DrawChain(Vector2 start, Vector2 end, string name, SpriteBatch spriteBatch){
start -= Main.screenPosition;
end -= Main.screenPosition;

int linklength=Main.goreTexture[Config.goreID[name]].Height;
Vector2 chain = end - start;

float length = (float)chain.Length();
int numlinks = (int)Math.Ceiling(length/linklength);
Vector2[] links = new Vector2[numlinks];
float rotation = (float)Math.Atan2(chain.Y, chain.X);

for (int i = 0; i < numlinks; i++){
    links[i] =start + chain/numlinks * i;
}
 
for (int i = 0; i < numlinks; i++){
Color color = Lighting.GetColor((int)((links[i].X+Main.screenPosition.X)/16), (int)((links[i].Y+Main.screenPosition.Y)/16));
spriteBatch.Draw(Main.goreTexture[Config.goreID[name]],
new Rectangle((int)links[i].X, (int)links[i].Y, Main.goreTexture[Config.goreID[name]].Width, linklength), null,
color, rotation+1.57f, new Vector2(Main.goreTexture[Config.goreID[name]].Width/2f, linklength), SpriteEffects.None, 1f);
}
}