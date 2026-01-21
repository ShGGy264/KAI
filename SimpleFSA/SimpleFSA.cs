namespace KAI;

public class SimpleTransition(string name, SimpleState to)
{
    public string _name = name;
    public SimpleState _to = to;

    public virtual SimpleState Do(SimpleState from)
    {
        Console.WriteLine(_to.decription);
        return _to;
    }
}

public class SimpleState(string name,string description)
{
    internal string name = name;
    internal string decription = description;
    internal Dictionary<string, SimpleTransition> transitions = 
        new Dictionary<string, SimpleTransition>();


    public virtual void AddTransition(SimpleTransition st)
    {
        transitions.Add(st._name, st);
    }

    public virtual SimpleState DoTransition(string message)
    {
        if (transitions.ContainsKey(message))
        {
            return transitions[message].Do(this);
        } else 
        { // no change
            return this;
        }
    } 
}

public class SimpleFSA()
{
    private Dictionary<string, SimpleState> stateDictionary = 
        new Dictionary<string, SimpleState>();
    private SimpleState currentState = null;
   
    public void AddState(string name, SimpleState state)
    {
        stateDictionary.Add(name, state);
        if (currentState==null){
            currentState = state;
        }
    }
    
    public SimpleState GetState(string name)
    {
        return stateDictionary[name];
    }
    
    public void SetCurrentState(SimpleState newState){
        currentState = newState;
    }
    

    public SimpleState DoMessage(string message)
    {
        if (currentState == null)
        {
            Console.WriteLine("No current state in DoMessage");
        }
        else
        {
            currentState = currentState.DoTransition(message);
        }

        return currentState;

    }
    
}
