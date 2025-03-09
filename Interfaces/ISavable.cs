namespace MyGame.Interfaces
{
    public interface ISavable
    {
        System.Tuple<string, object> Save();
        void Load(System.Tuple<string, object> data);
    }
}
