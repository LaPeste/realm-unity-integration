namespace Platformer.Model
{
    public class LevelModel
    {
        public string Name { get; }

        public LevelModel()
        {
            // TODO find a better way to name this
            Name = "BlueCity";//SceneManager.GetActiveScene().name;
        }
    }
}