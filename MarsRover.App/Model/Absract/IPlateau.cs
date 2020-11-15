
namespace MarsRover.App.Model.Absract
{
    public interface IPlateau
    {
        Position PlateauPosition { get; }
        bool IsHasWithinBounds(IPosition roverPosition);
    }
}