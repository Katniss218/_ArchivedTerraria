public void UseItemEffect(Player player) 
{
    Lighting.addLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.5f, 0.0f, 0.3f);
}