namespace memory.Entities
{
  public class Game
  {
    public virtual uint id { get; set; }
    public virtual User relatedUser { get; set; }
    public virtual Difficulty relatedDifficulty { get; set; }
    public virtual int misses { get; set; }
    public virtual int moves { get; set; }
  }
}