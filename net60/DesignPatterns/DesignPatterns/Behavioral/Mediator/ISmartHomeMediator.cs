namespace DesignPatterns.Behavioral.Mediator
{
    public interface ISmartHomeMediator
    {
        string Update(string change, SmartThing caller);
    }

}
