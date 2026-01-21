// See https://aka.ms/new-console-template for more information

using KAI;

class TickTockClock
{
    static void Main(string[] args)
    {
        SimpleFSA fsa = new SimpleFSA();
        SimpleState tickState = new SimpleState("tick","Tick");
        SimpleState tockState = new SimpleState("tock","Tock");
        tickState.AddTransition(new SimpleTransition("pulse",tockState));
        tockState.AddTransition(new SimpleTransition("pulse",tickState));
        fsa.AddState("tick",tickState);
        fsa.AddState("tock",tockState);

        while (true)
        {
            fsa.DoMessage("pulse");
        }
    }
}
