
namespace MarsRover.App.Model.Absract
{
    public interface IRover
    {
        IPlateau RoverPlateau { get; set; }
        IPosition RoverPosition { get; set; }
        Direction RoverDirection { get; set; }
        void Run(string commands);
        string LastRoverPosition();
    }
}
