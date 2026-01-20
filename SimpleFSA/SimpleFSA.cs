namespace KAI;

public class Transition(string message, SimpleState newState)
{
    internal string message = message;

    internal SimpleState newState = newState;
    
}

public class SimpleState(string name,string description)
{
    private string name = name;
    private string decription = description;
    private Dictionary<string, Transition> transitions;

    public void AddTransition(string name,Transition to)
    {
        transitions.Add(name, to);
    }

    public SimpleState DoTransition(string message)
    {
        if (transitions.ContainsKey(message))
        {
            Transition transition = transitions[message];
            SimpleState newstate = transition.newState;
            Console.WriteLine(newstate.decription);
            return newstate;
        } else 
        { // no change
            return this;
        }
        
       
    } 
}

public class SimpleFSA()
{
    private Dictionary<string, SimpleState> stateDictionary;
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
