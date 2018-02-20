namespace EpitaSpaceProgram.ACDC
{
    // Represents an entity of a scene.
    public interface IEntity : Json.ISerializableList
    {
        // Entities must implement an update method, that takes in the time delta since the last update.
        void Update(double delta);
    }
}