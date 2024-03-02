public void Update(int x, int y)
{
    Lighting.addLight((int)(x), (int)(y), 1f, 1f, 1f);
    if (Main.rand.Next(4)==0)
    {
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) x*16f, (float) y*16f), 16, 16, 25, 0, 0, 6, color, 1.0f);
    }
}